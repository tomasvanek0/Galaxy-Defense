using UnityEngine;

public class MotherShipSpawn : MonoBehaviour
{
    public Transform ship;
    public Transform[] spawnPoints;

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
                int pos = Random.Range(0, spawnPoints.Length);
                Instantiate(ship);
            }
            else
            {
                return;
            }
            

        }
        
        
    }
}
