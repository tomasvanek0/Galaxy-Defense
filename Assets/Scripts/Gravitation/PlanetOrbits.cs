using UnityEngine;

public class PlanetOrbits : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform center;
    public float speed;
    public float radius;

    void FixedUpdate()
    {
        Vector2 centerPosition = center.position;

        Vector2 offset = rb.position - centerPosition;

        float angle = speed * Mathf.Deg2Rad * Time.fixedDeltaTime;

        Vector2 newOffset = new Vector2(
            offset.x * Mathf.Cos(angle) - offset.y * Mathf.Sin(angle),
            offset.x * Mathf.Sin(angle) + offset.y * Mathf.Cos(angle)
        );

        rb.MovePosition(centerPosition + newOffset);
    }
}