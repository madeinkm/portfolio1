using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("플레이어스텟")]
    [SerializeField] private float m_Speed;
    [SerializeField] private int m_MaxHp = 10;
    [SerializeField] private int m_attack = 1;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        moving();
    }

    private void moving()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float vertical = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        transform.position += new Vector3(horizontal, vertical) * m_Speed;

    }
}
