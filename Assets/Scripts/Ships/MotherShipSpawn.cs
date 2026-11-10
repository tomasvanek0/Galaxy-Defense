using UnityEngine;

public class MotherShipSpawn : MonoBehaviour
{
    public Transform ship;
    public Transform spawnPoint;
    public Transform EnemyParrent;

    public float spawnTime = 1f;
    private float timer = 0f;
    int i = 0;
    void Start()
    {
        
    }

    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            if ( i < 100)
            {
                i++;
                timer = 0f;
                Instantiate(ship, spawnPoint.position, spawnPoint.rotation, EnemyParrent);
                
            }
            else
            {
                GameManager.Instance.GameState = false;
                GameManager.Instance.TowerPlacementMode = true;

            }
            

        }
        
        
    }
}
