using UnityEngine;

public class LaserTower : MonoBehaviour
{
    public EnemyDetection enemyDetection;
    public LineRenderer Laser;

    public float attackInterval = 0.5f;
    public int damage = 1;

    private float timer;

    void Start()
    {
        Laser.positionCount = 2;
        Laser.enabled = false;
    }

    void Update()
    {
        timer += Time.deltaTime;

        GameObject closestEnemy = null;
        float closestDistance = float.MaxValue;

        foreach (GameObject enemy in enemyDetection.enemiesInRange)
        {
            if (enemy == null)
                continue;

            float distance = Vector2.Distance(
                transform.position,
                enemy.transform.position
            );

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy == null)
        {
            Laser.enabled = false;
            return;
        }

        Laser.enabled = true;
        Laser.SetPosition(0, transform.position);
        Laser.SetPosition(1, closestEnemy.transform.position);

        // Útok v pravidelném intervalu
        if (timer >= attackInterval)
        {
            timer = 0f;

            EnemyHealth enemyHealth =
                closestEnemy.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.health -= damage;
                Debug.Log("Enemy Health: " + enemyHealth.health);
            }
        }
    }
}