 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;

    [Header("�÷��̾��")]
    [SerializeField] private float m_Speed;
    [SerializeField] private int m_MaxHp = 100;
    private int m_curHp;

    [Header("�÷��̾����")]
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

    private void moving() // �÷��̾� ����������
    {
        float move_x = Input.GetAxisRaw("Horizontal") * Time.deltaTime; //�Է�Ű ����
        float move_y = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        transform.position += new Vector3(move_x, move_y) * m_Speed;

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
