 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("�÷��̾��")]
    [SerializeField] private float m_Speed;
    [SerializeField] private int m_MaxHp = 100;
    private int m_curHp;

    [Header("�÷��̾����")]
    [SerializeField]private Transform trsHands;

        
    void Start()
    {
        trsHands.localEulerAngles = Vector3.zero;
    }

    
    void Update()
    {
        moving();
        attack();


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
}
