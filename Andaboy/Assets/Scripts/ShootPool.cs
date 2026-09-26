using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.InputSystem;

public class ShootPool : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;

    [Header("Pool")]
    public int poolSize = 20;

    [Header("Munição")]
    public int maxAmmo = 20;
    public int currentAmmo;

    private int activeProjectiles = 0;
    private ObjectPool<GameObject> pool;

    void Awake()
    {
        currentAmmo = maxAmmo;

        pool = new ObjectPool<GameObject>(
            () => Instantiate(projectilePrefab),
            projectile => projectile.SetActive(true),
            projectile => projectile.SetActive(false),
            projectile => Destroy(projectile),
            false,
            poolSize,
            poolSize
        );
    }

    void Update()
    {
        // Atirar com botão esquerdo
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }

        // Recarregar com Espaço OU botão direito
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Reload();
        }

        if (Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame)
        {
            Reload();
        }
    }

    public void Shoot()
    {
        if (currentAmmo <= 0)
        {
            Debug.Log("Sem munição! Aperte ESPAÇO ou botão direito para recarregar.");
            return;
        }

        if (activeProjectiles >= poolSize)
        {
            Debug.Log("Todas as balas do Pool estão em uso.");
            return;
        }

        GameObject projectile = pool.Get();

        currentAmmo--;
        activeProjectiles++;

        projectile.transform.SetPositionAndRotation(
            firePoint.position,
            firePoint.rotation
        );

        Projectile projectileScript = projectile.GetComponent<Projectile>();

        if (projectileScript != null)
        {
            projectileScript.StartProjectile(
                firePoint.forward,
                this
            );
        }
    }

    public void Reload()
    {
        currentAmmo = maxAmmo;

        Debug.Log("Recarregou! Munição: " + currentAmmo);
    }

    public void ReturnProjectile(GameObject projectile)
    {
        activeProjectiles--;
        pool.Release(projectile);
    }
}
