using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public float projectileSpeed  = 30;

    public void ShootProjectile()
    {
        InstantiateProjectile(firePoint);
    }

    void InstantiateProjectile(Transform firePoint)
    {
        var projectileObject = Instantiate(projectile, firePoint.position, firePoint.rotation) as GameObject;
        projectileObject.GetComponent<Rigidbody>().velocity = -firePoint.forward * projectileSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player");
        }
    }
}
