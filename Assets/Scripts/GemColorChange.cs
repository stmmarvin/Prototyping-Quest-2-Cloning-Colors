using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemColorChange : MonoBehaviour
{
    [SerializeField] private Color gemcolor = Color.white;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        {
            SpriteRenderer myspriterenderer = other.GetComponent<SpriteRenderer>();
            if (myspriterenderer != null)
            {
                myspriterenderer.color = gemcolor;
            }
        }
    }
}
