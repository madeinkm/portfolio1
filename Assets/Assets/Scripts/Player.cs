using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("플레이어스텟")]
    [SerializeField] private float m_Speed;
    [SerializeField] private int m_MaxHp = 10;
    [SerializeField] private int m_Attack = 1;

    private Transform trsHands;

        
    void Start()
    {
        
    }

    
    void Update()
    {
        moving();
        
    }

    private void moving()
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

    private void attack()
    {
        
    }
}
