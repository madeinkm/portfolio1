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
    [SerializeField] private float enemyHp = 5.0f;
    [SerializeField] private float enemySpeed = 1.0f;
    [SerializeField] private int enemyDamage = 5;

    [SerializeField] private GameObject objDead;
    private Animator anim;


    private Transform trsplayer;
    
    private void Awake()
    {
        trsplayer = FindObjectOfType<Player>().transform;
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Weapon")
    //    {
    //        Weapon sc = collision.GetComponent<Weapon>();
    //        float damage = sc.WeaponDamage();
    //        EnemyHit(damage);
    //    }
    //    //else if (collision.gameObject.tag == "Player")
    //    //{
    //    //한번 시도해보기 Event와 script 중 누가 먼저 동작할지 확인해보자

    //    //}
    //}

    void Update()
    {
        moving();       


    }
    public int GetDamge()
    {
        return enemyDamage;
    }
    public void EnemyHit(float _damage)
    {
        if(enemyHp > 0)
        {
            enemyHp -= _damage;
            doHitAnim();
        }       
        
        if (enemyHp <= 0)
        {
            DeadEnemy();
            GameManager.Instance.CreatItem(transform.position);
            
        }       
    }
    public void DeadEnemy()
    {
        Destroy(gameObject);

        GameObject obj = Instantiate(objDead, transform.position, Quaternion.identity, transform.parent);
        EnemyDead sc = obj.GetComponent<EnemyDead>();
    }
   

    private void moving() //적움직임, 플레이어에게 다가감
    {
        if (trsplayer == null)
        {
            return;
        }

        Vector3 playerPos = trsplayer.position;     
        float distance = Vector3.Distance(playerPos, transform.position);      

        float move_x = (playerPos.x - transform.position.x);
        float move_y = (playerPos.y - transform.position.y);

        if (move_x < 0) //몬스터 방향 전환
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (move_x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if(distance > 2) // 몬스터와 플레이어간 거리유지
        {
            transform.position += new Vector3( move_x , move_y ,0) * enemySpeed * Time.deltaTime;
        }
    }
    private void doHitAnim()
    {
        anim.SetTrigger("Hit");
        //if (isHit == true)
        //{
        //}
        //else if(isHit == false)
        //{
        //    anim.SetBool("Hit", false);
        //}        
    }
}
