using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    private Image HpBack;
    private Image HpFront;

    private void Awake()
    {
        HpBack = transform.GetChild(1).GetComponent<Image>();
        HpFront = transform.GetChild(2).GetComponent<Image>();
    }

    void Update()
    {
        CheckHpBar();
        
    }
    private void CheckHpBar()
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
}
