// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private GameHandler gameHandler;
    private SpriteRenderer hazardRenderer;

    void Start()
    {
        gameHandler = FindObjectOfType<GameHandler>();
        hazardRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            SpriteRenderer blockRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            if (blockRenderer == null || hazardRenderer == null)
                return;

            // Only destroy if the color is different from the hazard
            if (!ColorsAreEqual(blockRenderer.color, hazardRenderer.color))
            {
                if (collision.gameObject.GetComponent<BlockMovement>().isActiveBool)
                {
                    Destroy(collision.gameObject);
                    gameHandler.AllPlayerBlocksArrayUpdate();
                    gameHandler.DestroyedBlockUpdate();
                }
                else
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }

    // Helper to compare colors with tolerance
    // Tolerance ensures that small, invisible differences between colors are ignored when comparing.

    private bool ColorsAreEqual(Color a, Color b, float tolerance = 0.05f)
    {
        return Mathf.Abs(a.r - b.r) < tolerance &&
               Mathf.Abs(a.g - b.g) < tolerance &&
               Mathf.Abs(a.b - b.b) < tolerance;
    }
}
