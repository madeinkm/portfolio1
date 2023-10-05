using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    private RoundManager roundManager;

    [SerializeField] private List<GameObject> listEnemy;
    private Transform spawnPoint;
    [SerializeField] private Transform trsDynamicObject;
            
    private int checkSpawnLimit = 16;
    private int checkSpwan = 0; // 적 개체수 확인
    private int enemycount; //
    private bool prepared = false;

    [Header("아이템")]
    [SerializeField] private List<GameObject> listItem;

    private Transform trsplayer;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        spawnPoint = transform.GetChild(0);
        roundManager = FindAnyObjectByType<RoundManager>();
    }

    void Update()
    {
        spawnEnmemy();            
        
    }    
    public void InHitSpawnCount()
    {
        checkSpwan = 0;
    }
    public void spawnEnmemy() //몬스터 생성
    {
        if (checkSpwan < checkSpawnLimit)
        {
            int iRand = Random.Range(0, listEnemy.Count);
            GameObject objEnemy = listEnemy[iRand];

            float fRand_x = Random.Range(-7.0f, 7.0f); // 몬스터 랜덤 X 위치
            float fRand_y = Random.Range(-4.0f, 4.0f); // 몬스터 랜덤 Y 위치
            Vector3 spawnPosition = spawnPoint.position;
            spawnPosition.x += fRand_x;
            spawnPosition.y += fRand_y;

            GameObject obj = Instantiate(objEnemy, spawnPosition, Quaternion.identity, trsDynamicObject);
            prepared = false;

            checkSpwan++;

        }
        else if (prepared == false)
        {
            prepared = true;
        }
        else if (EnemyCount() == 0)
        {
            roundManager.checkround();
            checkSpwan = 0;
        }        
    }
    public void CreatItem(Vector3 _pos)
    {
        int rand = Random.Range(0, listItem.Count);
        GameObject instObj = listItem[rand];
        Instantiate(instObj, _pos, Quaternion.Euler(Vector3.zero), trsDynamicObject);
    }

    public int EnemyCount()
    {
        return trsDynamicObject.childCount;
    }

    public bool isPrepared()
    { 
        return prepared;
    }
    public Transform GetPlayerTransform()
    {
        return trsplayer;
    }
}
