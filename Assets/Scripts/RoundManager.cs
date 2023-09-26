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
        checkround();
        checkRoundTimer();
        enemycount = GameManager.Instance.EnemyCount();
        //Debug.Log(enemycount);

    }
    public void Setround(int _cur_round, int _max_round)
    {
        roundFront.fillAmount = (float)_cur_round / _max_round;
    }

    private void checkround()
    {
        Setround(cur_round, max_round);

        if (GameManager.Instance.isPrepared() == true)
        {
            if (cur_round < max_round && enemycount <= 0)
            {
                cur_round ++;
                Setround(cur_round, max_round);
            }            
        }

        else if (cur_round >= max_round)
        {
            //스테이지가 넘어가면서 roundbar는 다시 초기화.
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
