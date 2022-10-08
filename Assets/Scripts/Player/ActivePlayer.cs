using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayer : MonoBehaviour
{
    private PlayerManager manager;
    Projectile projectile;

    private void Start()
    {
        projectile = GetComponent<Projectile>();
    }
    public void AssignManager(PlayerManager theManager)
    {
        manager = theManager;
    }
    public void FireProjectile()
    {
        manager.ChangeTurn();
        projectile.ShootProjectile();
    }
}
