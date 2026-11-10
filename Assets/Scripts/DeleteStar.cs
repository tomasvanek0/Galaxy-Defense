using UnityEngine;

public class DeleteStar : MonoBehaviour
{
    public GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.Instance;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Star"))
        {
            Debug.LogWarning($"Collision with {collision.gameObject.name}");
            Destroy(collision.gameObject);
            gameManager.PlayerHealth -= 1;
            if (gameManager.PlayerHealth <= 0)
            {
                gameManager.GameState = false;
                Debug.Log("Game Over");
                Destroy(gameObject);
            }

        }




    }
}
