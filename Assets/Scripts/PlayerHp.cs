using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    private Image HpBack;
    private Image HpFront;

    private Transform trsPlayer;

    private void Awake()
    {
        HpBack = transform.GetChild(1).GetComponent<Image>();
        HpFront = transform.GetChild(2).GetComponent<Image>();
        trsPlayer = FindObjectOfType<Player>().transform;
}

    void Update()
    {
        //checkPosition();
        checkHpBar();        

    }

    public void SetPlayerHp(int _curHp, int _maxHp)
    {
        HpFront.fillAmount = (float)_curHp / _maxHp;
    }

    //private void checkPosition()
    //{
    //    transform.position = trsPlayer.position + new Vector3(-8.0f, 5.0f, 0); // 캔버스를 overlay로 하면 고정된 위치에 있음
    //}
    private void checkHpBar()
    {
        if (HpFront.fillAmount < HpBack.fillAmount)// HP가 깎이면 HP바가 줄어들고 그 뒤 연출도 같이 줄어듬
        {
            HpBack.fillAmount -= Time.deltaTime * 0.5f;
            if (HpBack.fillAmount <= HpFront.fillAmount) // 연출이 따라잡으면 같아짐(연출을 멈추는 용도)
            {
                HpBack.fillAmount = HpFront.fillAmount;
            }
        }
        else if (HpFront.fillAmount > HpBack.fillAmount) //스테이지가 끝나고 Hp가 초기화되면 뒤에 연출도 초기화
        {
            HpBack.fillAmount = HpFront.fillAmount;
        }
    }  
}
