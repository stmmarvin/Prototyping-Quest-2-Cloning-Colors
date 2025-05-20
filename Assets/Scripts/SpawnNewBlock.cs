// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewBlock : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;
    [SerializeField] Transform spawnPosition;

    public void SpawnBlock()
    {
        GameObject newBlock = Instantiate(blockPrefab, spawnPosition.position, Quaternion.identity);

        SpriteRenderer spriteRenderer = newBlock.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.color = GetRandomColor();
        }
    }

    private Color GetRandomColor()
    {
        return new Color(
            Random.Range(0f, 1f),  // Red
            Random.Range(0f, 1f),  // Green
            Random.Range(0f, 1f)   // Blue
        );
    }
}

