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
        checkHpBar();        

    }
    //private void checkPosition() // ĵ�������� screenSpace - Overlay�� ����Ͽ� ��ġ �����ϴ°����� ����
    //{
    //    transform.position = trsPlayer.position + new Vector3(-8.0f, 5.0f, 0);
    //}
    private void checkHpBar()
    {
        if (HpFront.fillAmount < HpBack.fillAmount)// HP�� ���̸� HP�ٰ� �پ��� �� �� ���⵵ ���� �پ��
        {
            HpBack.fillAmount -= Time.deltaTime * 0.5f;
            if (HpBack.fillAmount <= HpFront.fillAmount) // ������ ���������� ������(������ ���ߴ� �뵵)
            {
                HpBack.fillAmount = HpFront.fillAmount;
            }
        }
        else if (HpFront.fillAmount > HpBack.fillAmount) //���������� ������ Hp�� �ʱ�ȭ�Ǹ� �ڿ� ���⵵ �ʱ�ȭ
        {
            HpBack.fillAmount = HpFront.fillAmount;
        }
    }

    public void SetPlayerHp(int _curHp, int _maxHp)
    { 
        HpFront.fillAmount = (float)_curHp / _maxHp;
    }
}
