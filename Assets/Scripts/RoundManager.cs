using System;
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

    private int max_round = 3;
    private int cur_round = 0;

    private int enemycount;

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
        checkRoundTimer();
        enemycount = GameManager.Instance.EnemyCount();

    }
    public void Setround(int _cur_round, int _max_round)
    {
        roundFront.fillAmount = (float)_cur_round / _max_round;
    }

    public void checkround()
    {     
        if (GameManager.Instance.isPrepared() == true && cur_round < max_round)
        {
            cur_round++;
            Setround(cur_round, max_round);

            if (cur_round >= max_round) //3round 종료시 초기화
            {
                cur_round = 0;
                Setround(cur_round, max_round);
            }
        }                
    }    

    private void checkRoundTimer()
    {
        if (gameoverTimer > 0)
        {
            gameoverTimer -= Time.deltaTime;

            if (gameoverTimer <= 0)
            {
                //Gameover 후 게임 다시 재시작 코드 작성
            }

            textTimer.text = $"{(int)gameoverTimer}s";
        }
    }    
}
