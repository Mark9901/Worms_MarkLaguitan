using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private float weaponDamage;
    [SerializeField] private Color rayColor;
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private LineRenderer lineRenderer;

    HealthBar healthBar;
    private WeaponPickup currentWeapon;
    private float rayDelay;
    // Start is called before the first frame update

    private void Start()
    {
        healthBar = GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rayDelay> 0 )
        {
            rayDelay -= Time.deltaTime;
            if(rayDelay <= 0)
            {
                lineRenderer.enabled = false;
            }
        }
        
    }

    public float GetDamage()
    {
        if(currentWeapon != null)
        {
            return currentWeapon.GetDamage();
        }
        return weaponDamage;
    }
    public Color GetColor()
    {
        if(currentWeapon != null)
        {
            return currentWeapon.GetColor();
        }
        return rayColor;
    }
    public void ShootLaser()
    {
        RaycastHit result;
        bool thereWasHit = Physics.Raycast(weaponHolder.position, transform.forward, out result, Mathf.Infinity);

        lineRenderer.startColor = GetColor();
        lineRenderer.endColor = GetColor();
        lineRenderer.SetPosition(0, weaponHolder.position);
        lineRenderer.enabled = true;
        rayDelay = 0.25f;

        if(thereWasHit)
        {
            HealthBar playerHealth = result.collider.GetComponent<HealthBar>();
            {

            healthBar.TakeDamage(10);
            }
            lineRenderer.SetPosition(1, result.point);

        }
        else
        {
            lineRenderer.SetPosition(1, weaponHolder.position + transform.forward * 50);
        }
    }
}
