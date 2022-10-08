using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private Color rayColor;
    [SerializeField] private string weaponName;

    private void OnTriggerEnter(Collider other)
    {
        ActiveWeapon playerWeapon = other.GetComponent<ActiveWeapon>();
        if(playerWeapon != null)
        {
            gameObject.SetActive(false);
        }
    }

    public float GetDamage()
    {
        return damage;
    }
    public Color GetColor()
    {
        return rayColor;
    }

    public string GetWeaponName()
    {
        return weaponName;
    }

}
