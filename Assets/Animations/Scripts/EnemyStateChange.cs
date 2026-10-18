using System.Collections;
using UnityEngine;

public class EnemyStateChange : MonoBehaviour
{

    public Sprite[] sprites;
    public float changeInterval = 0.5f;
    private SpriteRenderer spriteRenderer;
    private int index = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeSprite());
    }

    IEnumerator ChangeSprite()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeInterval);

            index = (index + 1) % sprites.Length;
            spriteRenderer.sprite = sprites[index];
        }
    }
}
