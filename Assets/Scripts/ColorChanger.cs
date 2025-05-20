// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;

    public enum BlockColor
    {
        Red,
        Yellow,
        Blue
    }

    [SerializeField]
    private BlockColor startColor = BlockColor.Red;

    void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>(); // Haal de SpriteRenderer op
    }

    private void Start()
    {
        ChangeColor(startColor); // Verander de kleur bij het starten
    }

    public void ChangeColor(BlockColor color)
    {
        switch (color)
        {
            case BlockColor.Red:
                mySpriteRenderer.color = Color.red;
                break;
            case BlockColor.Yellow:
                mySpriteRenderer.color = Color.yellow;
                break;
            case BlockColor.Blue:
                mySpriteRenderer.color = Color.blue;
                break;
        }
    }
}
