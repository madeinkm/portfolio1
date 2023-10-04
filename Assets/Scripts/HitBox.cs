using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eHitType
{
    PlayerCheck,
    WeaponCheck,
}
public class HitBox : MonoBehaviour
{
    private Player player;
    [SerializeField] private eHitType hitType;
        

    void Start()
    {
        player = GetComponentInParent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.TriggerEnter(hitType, collision);
    }
}
