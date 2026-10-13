using UnityEngine;

public class PlanetsGravity : MonoBehaviour
{
    public float planetMass;
    private float gravityConst = 0.05f;
    public float maxDistance;
    public float minDistance;
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
            gravityConst * planetMass / (distance * distance);

        Vector2 force = direction * acceleration;

        rb.AddForce(force);
    }
}