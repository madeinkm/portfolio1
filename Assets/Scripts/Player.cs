 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    
    [Header("플레이어스텟")]
    [SerializeField] private float m_speed = 5.0f;
    [SerializeField] private int m_maxHp = 100;
    private int m_curHp;

    [Header("플레이어공격")]
    [SerializeField]private Transform trsHands;

    [Header("Hp연출")]
    [SerializeField] private PlayerHp playerHp;
    Weapon weaponsc;

    
    void Start()
    {
        trsHands.localEulerAngles = Vector3.zero;
        anim = GetComponent<Animator>();

        m_curHp = m_maxHp;
        playerHp.SetPlayerHp(m_curHp, m_maxHp);
        weaponsc = GetComponentInChildren<Weapon>();
    }

    
    void Update()
    {
        moving();
        attack();
        doanim();
    }
    public void Hit(int _damage)
    {
        m_curHp -= _damage;
        playerHp.SetPlayerHp(m_curHp, m_maxHp);

        if (m_curHp <= 0)
        {
            //묘비 애니메이션 동작 예정. GAME OVER 되는 코드 작성 예정.
            Destroy(gameObject);
        }

    }
    public void TriggerEnter(eHitType _type, Collider2D _coll) // 플레이어와 무기에 둘다 콜라이더가 있어서 hitbox로 분리해줌
    {
        switch (_type)
        {
            case eHitType.PlayerCheck:
                if (_coll.gameObject.tag == "Enemy")
                {
                    Enemy sc = _coll.gameObject.GetComponent<Enemy>();
                    int damage = sc.GetDamge();
                    Hit(damage);
                }
                break;
            case eHitType.WeaponCheck:
                if (_coll.gameObject.tag == "Enemy")
                {                                        
                    Enemy sc = _coll.gameObject.GetComponent<Enemy>();
                    float damage = weaponsc.WeaponDamage();
                    sc.EnemyHit(damage);
                }
                break;
        }
    }    

    private void moving() // 플레이어 수동움직임
    {
        float move_x = Input.GetAxisRaw("Horizontal") * Time.deltaTime; //입력키 설정
        float move_y = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        transform.position += new Vector3(move_x, move_y) * m_speed;

        if (move_x > 0) // 입력 방향에 따른 캐릭터 방향설정
        {
           transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else if (move_x < 0)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }

    private void attack() // 플레이어 수동공격
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            trsHands.localEulerAngles = new Vector3(0, 0, -50.0f);        
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            trsHands.localEulerAngles = Vector3.zero;
        }
    }
    private void doanim()
    {
        float move_x = Input.GetAxisRaw("Horizontal");
        float move_y = Input.GetAxisRaw("Vertical");
        anim.SetInteger("move_x", (int)move_x);
        anim.SetInteger("move_y", (int)move_y);        
    }    
}
