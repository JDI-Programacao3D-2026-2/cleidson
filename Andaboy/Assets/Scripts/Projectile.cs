using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;

    private Vector3 direction;
    private ShootPool shootPool;

    private float lifeTimer;

    public void StartProjectile(Vector3 direction, ShootPool shooter)
    {
        this.direction = direction.normalized;
        this.shootPool = shooter;
        lifeTimer = lifeTime;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0f)
        {
            ReturnToPool();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        ReturnToPool();
    }

    void ReturnToPool()
    {
        if (shootPool != null && gameObject.activeSelf)
        {
            shootPool.ReturnProjectile(gameObject);
        }
    }
}
