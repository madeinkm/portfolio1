using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1); // 시간을 지정 가능
    }
}
