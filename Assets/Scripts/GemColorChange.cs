using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemColorChange : MonoBehaviour
{
    // Removed invalid field 'Spritecolor RandomColor'

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        {
            SpriteRenderer mySpriteRenderer = other.GetComponent<SpriteRenderer>();
            if (mySpriteRenderer != null)
            {
                // Assign a random color to the block's SpriteRenderer
                mySpriteRenderer.color = new Color(
                    Random.Range(0f, 1f),
                    Random.Range(0f, 1f),
                    Random.Range(0f, 1f)
                );
            }
        }
    }
}
