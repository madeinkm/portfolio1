using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [SerializeField] private List<GameObject> listEnemy;
    private Transform spawnPoint;
    [SerializeField] private Transform trsDynamicObject;

    private int round = 1;
    private int checkSpawnLimit = 16;
    private int checkSpwan = 0; // 적 개체수 확인


    void Start()
    {
        spawnPoint = transform.GetChild(0);

    }

    void Update()
    {
        //checkspwan = trsDynamicObject.childCount;
        if (checkSpwan < checkSpawnLimit)
        { 
            spawnEnmemy();
        }

    }

    private void setRound(int _round)
    {
        round = _round;
        checkSpawnLimit = 10 * _round;
    }

    private void spawnEnmemy() //몬스터 생성
    {
        int iRand = Random.Range(0, listEnemy.Count);
        GameObject objEnemy = listEnemy[iRand];

        float fRand_x = Random.Range(-7.0f, 7.0f); // 몬스터 랜덤 X 위치
        float fRand_y = Random.Range(-4.0f, 4.0f); // 몬스터 랜덤 Y 위치
        Vector3 spawnPosition = spawnPoint.position;
        spawnPosition.x += fRand_x;
        spawnPosition.y += fRand_y;

        GameObject obj = Instantiate(objEnemy, spawnPosition, Quaternion.identity, trsDynamicObject);
        checkSpwan++;
    }
}
