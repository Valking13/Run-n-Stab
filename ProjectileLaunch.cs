using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchTransform;

    public void FireProjectile()
    {
        GameObject projectileInstance = Instantiate(projectilePrefab, launchTransform.position, projectilePrefab.transform.rotation);

        Projectile projectile = projectileInstance.GetComponent<Projectile>();

        // need to flip the projectiles directin if char is fliped
        if (gameObject.transform.localScale.x > 0)
        {

            projectile.Fire(Vector2.right);
        } else
        {
            projectile.Fire(Vector2.left);
        }
    }
}
