using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayer : MonoBehaviour
{
    private PlayerManager manager;
    ActiveWeapon activeWeapon;

    private void Start()
    {
        activeWeapon = GetComponent<ActiveWeapon>();

    }
    public void AssignManager(PlayerManager theManager)
    {
        manager = theManager;
    }
    public void FireProjectile()
    {
        manager.ChangeTurn();
        activeWeapon.ShootLaser();
    }
}
