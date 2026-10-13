using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.LowLevelPhysics;
using UnityEngine.SocialPlatforms.GameCenter;

public class StarGravity : MonoBehaviour
{
    public float starMass;
    public float maxDistance = 50f;
    public float minDistance = 1f;
    private float gravityConst = 0.05f;

    public PhysicsMoveToTarget targetScript;

    private void OnTriggerStay2D(Collider2D collision)
    {
        PhysicsMoveToTarget targetScript =
            collision.GetComponent<PhysicsMoveToTarget>();

        if (targetScript == null)
            return;

        Rigidbody2D rb =
            collision.GetComponent<Rigidbody2D>();

        if (rb == null)
            return;

        Vector2 direction =
            (Vector2)transform.position - rb.position;

        float distance = direction.magnitude;

        if (distance < minDistance || distance > maxDistance)
            return;

        direction.Normalize();

        float acceleration =
            gravityConst * starMass / (distance * distance);

        Vector2 force = direction * acceleration;

        

        rb.AddForce(direction * 10f);
    }
}
    

