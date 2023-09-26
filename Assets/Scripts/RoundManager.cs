using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    private Image roundFront;

    private float gameoverTimer = 60.0f;
    private TMP_Text textTimer;

    private int round = 0;
    private int max_round = 3;
    private int cur_round;

    private void Awake()
    {
        roundFront = transform.GetChild(1).GetComponent<Image>();
        textTimer = transform.GetChild(2).GetComponent<TMP_Text>();
        
    }
    void Start()
    {

    }

    void Update()
    {
        checkroundBar();
        checkTimer();
    }
    public void Setround(int _cur_round, int _max_round)
    {
        roundFront.fillAmount = _cur_round / _max_round;
    }
    private void checkroundBar()
    {
        
    }    

    private void checkTimer()
    {
        if (gameoverTimer > 0)
        {
            gameoverTimer -= Time.deltaTime;

            if (gameoverTimer <= 0)
            {
                //Gameover �� ���� �ٽ� ����� �ڵ� �ۼ�
            }

            textTimer.text = $"{(int)gameoverTimer}s";
        }
    }
    
}
