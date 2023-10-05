 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    
    [Header("�÷��̾��")]
    [SerializeField] private float m_speed = 5.0f;
    [SerializeField] private int m_maxHp = 100;
    private int m_curHp;

    [Header("�÷��̾����")]
    [SerializeField]private Transform trsHands;

    [Header("Hp����")]
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
            //���� �ִϸ��̼� ���� ����. GAME OVER �Ǵ� �ڵ� �ۼ� ����.
            Destroy(gameObject);
        }

    }
    public void TriggerEnter(eHitType _type, Collider2D _coll) // �÷��̾�� ���⿡ �Ѵ� �ݶ��̴��� �־ hitbox�� �и�����
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

    private void moving() // �÷��̾� ����������
    {
        float move_x = Input.GetAxisRaw("Horizontal") * Time.deltaTime; //�Է�Ű ����
        float move_y = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        transform.position += new Vector3(move_x, move_y) * m_speed;

        if (move_x > 0) // �Է� ���⿡ ���� ĳ���� ���⼳��
        {
           transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else if (move_x < 0)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }

    private void attack() // �÷��̾� ��������
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
