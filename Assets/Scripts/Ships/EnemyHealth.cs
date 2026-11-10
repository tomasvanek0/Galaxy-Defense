using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            gameManager.PlayerMoney += 10; // Přidání peněz hráči

        }
    }
}





