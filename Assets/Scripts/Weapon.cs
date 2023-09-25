using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float damage = 1.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy sc = collision.gameObject.GetComponent<Enemy>();
            sc.EnemyHit(damage);
        }
    }
    public float WeaponDamage()
    {
        return damage;
    }
}
