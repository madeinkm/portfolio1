using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Gold,
        Exp,        
    }

    private float speed;
    private Transform trsPlayer;

    void Start()
    {
        trsPlayer = GameManager.Instance.GetPlayerTransform();
    }
       
    void Update()
    {
        getItem();
    }

    private void getItem()
    {
        //Vector3 playerPos = trsPlayer.position;
        
    }
}
