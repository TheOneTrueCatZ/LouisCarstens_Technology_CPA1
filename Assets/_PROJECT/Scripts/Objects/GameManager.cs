using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public ObjectPool bulletPool;
    public float bulletSpeed = 20f;
    
    public Transform firePoint;

    public void Shoot(InputAction.CallbackContext context)
    {
        Fire();
    }

    void Fire()
    {
        GameObject bullet = bulletPool.GetObject();
        
        if (firePoint != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
        }
        
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = bullet.transform.forward * bulletSpeed;
        }
        StartCoroutine(DeactivateBullet(bullet));
    }

    IEnumerator DeactivateBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(2f);
        bulletPool.ReturnObject(bullet);
    }
}