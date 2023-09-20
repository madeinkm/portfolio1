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

    [Header("적스텟")]
    [SerializeField] private float enemyhp = 5.0f;
    [SerializeField] private float enemyspeed = 1.0f;

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

        transform.position += new Vector3( move_x , move_y ,0) * enemyspeed * Time.deltaTime;

    }
}
