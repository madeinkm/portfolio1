using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    private Image roundFront;
    private float gameoverTimer = 60.0f;
    private TMP_Text textTimer;    

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
        checkTimer();
    }

    private void checkround()
    {

    }
    private void checkTimer()
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
