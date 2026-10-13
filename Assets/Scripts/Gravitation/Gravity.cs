using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float mass;
    private float gravity = 3f;
    public float minDistance;
    public float maxDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector2 GravityEffect(Transform collision)
    {
        Vector2 direction = transform.position - collision.position;

        float distance = direction.magnitude;

        if (distance < minDistance || distance > maxDistance)
            return Vector2.zero;

        direction.Normalize();

        float acceleration = (gravity * mass) / (distance * distance);
        Vector2 force = direction * acceleration;



        return force;
    }
}
