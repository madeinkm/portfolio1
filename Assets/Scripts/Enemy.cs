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
    private Rigidbody2D rigid;
    private PolygonCollider2D coll;

    [Header("������")]
    [SerializeField] private float enemyHp = 5.0f;
    [SerializeField] private float enemySpeed = 1.0f;
    [SerializeField] private int enemyDamage = 5;
    

    private Transform trsplayer;
    
    private void Awake()
    {
        trsplayer = FindObjectOfType<Player>().transform;
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<PolygonCollider2D>();
    }
    
    void Update()
    {
        moving();
       
    }
    private void moving() //��������, �÷��̾�� �ٰ���
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

        transform.position += new Vector3( move_x , move_y ,0) * enemySpeed * Time.deltaTime;

    }
    public int GetDamge()
    {
        return enemyDamage;
    }

}
