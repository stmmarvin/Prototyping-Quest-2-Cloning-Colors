using System.Collections;
using UnityEngine;

public class FlashyCoin : MonoBehaviour
{
    [SerializeField] private int scoreValue = 1; // Amount to add to score
    private SpriteRenderer coinRenderer;
    private GameHandler gameHandler;

    private void Start()
    {
        coinRenderer = GetComponent<SpriteRenderer>();
        gameHandler = FindObjectOfType<GameHandler>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        {
            SpriteRenderer blockRenderer = other.GetComponent<SpriteRenderer>();
            if (blockRenderer == null || coinRenderer == null)
                return;

            if (ColorsAreEqual(blockRenderer.color, coinRenderer.color))
            {
                // Add score and destroy coin
                // You need to implement AddScore(int) in GameHandler if not present
                if (gameHandler != null)
                {
                    gameHandler.SendMessage("AddScore", scoreValue, SendMessageOptions.DontRequireReceiver);
                }
                Destroy(gameObject);
            }
            else
            {
                // Start transparency animation on the player block
                StartCoroutine(FlashTransparency(blockRenderer));
            }
        }
    }
    
    private IEnumerator FlashTransparency(SpriteRenderer blockRenderer)
    {
        float originalAlpha = blockRenderer.color.a;
        Color c = blockRenderer.color;
        c.a = 0.3f;
        blockRenderer.color = c;
        yield return new WaitForSeconds(0.2f);
        c.a = originalAlpha;
        blockRenderer.color = c;
    }

    // Helper to compare colors with tolerance
    private bool ColorsAreEqual(Color a, Color b, float tolerance = 0.05f)
    {
        return Mathf.Abs(a.r - b.r) < tolerance &&
               Mathf.Abs(a.g - b.g) < tolerance &&
               Mathf.Abs(a.b - b.b) < tolerance;
    }
}
