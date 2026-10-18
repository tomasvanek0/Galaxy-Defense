using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
   
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Destroying enemy: " + gameObject.name);
        }
    }
}





