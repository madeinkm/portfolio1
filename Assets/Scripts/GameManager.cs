using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [SerializeField] private List<GameObject> listEnemy;
    private Transform spawnPoint;
    [SerializeField] private Transform trsDynamicObject;
            
    private int checkSpawnLimit = 16;
    private int checkSpwan = 0; // �� ��ü�� Ȯ��
    private int enemycount; //
    private bool prepared = false;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        spawnPoint = transform.GetChild(0);

    }

    void Update()
    {
        spawnEnmemy();            
        
    }    

    public void spawnEnmemy() //���� ����
    {
        if(checkSpwan < checkSpawnLimit)
        {
            int iRand = Random.Range(0, listEnemy.Count);
            GameObject objEnemy = listEnemy[iRand];

            float fRand_x = Random.Range(-7.0f, 7.0f); // ���� ���� X ��ġ
            float fRand_y = Random.Range(-4.0f, 4.0f); // ���� ���� Y ��ġ
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
    }

    public int EnemyCount()
    {
        return trsDynamicObject.childCount;
    }

    public bool isPrepared()
    { 
        return prepared;
    }
}
