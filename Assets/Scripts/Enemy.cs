using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyType
    {
        EnemyA, 
        EnemyB, 
        EnemyC, 
        EnemyD ,
        EnemyBoss
    }

    [SerializeField] private EnemyType enemyType;

    [SerializeField] Sprite[] arrSprite;
    private SpriteRenderer Sr;

    [Header("적스텟")]
    [SerializeField] private float enemyHp = 5.0f;
    [SerializeField] private float enemySpeed = 1.0f;
    [SerializeField] private int enemyDamage = 1;
    
    private Transform trsplayer;
    



    private void Awake()
    {
        Sr = GetComponent<SpriteRenderer>();
        trsplayer = FindObjectOfType<Player>().transform;
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        moving();
       
    }
    public void EnemyHit(float _damage)
    {
        enemyHp -= _damage;

        if (enemyHp <= 0)
        {
            Destroy(gameObject);
        }

        else
        {
            Sr.sprite = arrSprite[1];
            Invoke("defaultSprite", 0.1f);
        }

    }
    private void moving() //적움직임, 플레이어에게 다가감
    {
        if (trsplayer == null)
        {
            return;
        }

        Vector3 playerPos = trsplayer.position;     

        float move_x = (playerPos.x - transform.position.x);
        float move_y = (playerPos.y - transform.position.y);
        if (move_x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (move_x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        float distance = Vector3.Distance(transform.position, playerPos);

        if (distance > 1)
        {
            transform.position += new Vector3( move_x , move_y ,0) * enemySpeed * Time.deltaTime;
        }
    }
    public int GetEnemyDamage()
    {
        return enemyDamage;
    }
}
