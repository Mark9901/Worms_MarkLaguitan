
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{

    public int damageAmount = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.name == "PlayerOne" || collision.transform.gameObject.name == "PlayerTwo")
        {
            Debug.Log("Hit player");

        }
    }
}
