using UnityEngine;

public class DeleteStar : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Star"))
        {
            Debug.LogWarning($"Collision with {collision.gameObject.name}");
            Destroy(collision.gameObject);
        }




    }
}
