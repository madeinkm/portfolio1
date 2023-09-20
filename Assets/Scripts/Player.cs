 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;

    [Header("플레이어스텟")]
    [SerializeField] private float m_Speed;
    [SerializeField] private int m_MaxHp = 100;
    private int m_curHp;

    [Header("플레이어공격")]
    [SerializeField]private Transform trsHands;

        
    void Start()
    {
        trsHands.localEulerAngles = Vector3.zero;
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        moving();
        attack();
        doanim();
    }

    private void moving() // 플레이어 수동움직임
    {
        float move_x = Input.GetAxisRaw("Horizontal") * Time.deltaTime; //입력키 설정
        float move_y = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        transform.position += new Vector3(move_x, move_y) * m_Speed;

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
