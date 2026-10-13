using UnityEngine;

public class PhysicsMoveToTarget : MonoBehaviour
{
    public Transform[] target;
    public float speed = 3f;
    public Rigidbody2D rb;
    public Vector2 direction;

    void Start()
    {
        speed = Random.Range(1f, 8f);

        GameObject[] gos = GameObject.FindGameObjectsWithTag("SpawnSpot");

        target = new Transform[gos.Length];

        for (int i = 0; i < gos.Length; i++)
        {
            target[i] = gos[i].transform;
        }

        int pos = Random.Range(0, target.Length);

        rb = GetComponent<Rigidbody2D>();

        direction =
            (target[pos].position - transform.position).normalized;

        rb.linearVelocity = direction * speed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Gravity gravity = collision.GetComponent<Gravity>();

        if (gravity != null)
        {
            Vector2 pullForce = gravity.GravityEffect(transform);

            if (collision.CompareTag("Player"))
            {
                // Zastavení pohybu objektu, pokud je v kolizi s objektem "SpawnSpot"
                Debug.Log($"Působí síla: {pullForce} na objekt {gameObject.name}");

            }
            // Kontrolní výpis do konzole:

            rb.AddForce(pullForce, ForceMode2D.Force);
        }
    }

    private void Update()
    {
        if (transform.position.y < -10f || transform.position.y > 10f || transform.position.x < -10f || transform.position.x > 10f)
        {
            rb.linearVelocity = Vector2.zero;
            direction = (target[Random.Range(0, target.Length)].position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
        }
    }
}