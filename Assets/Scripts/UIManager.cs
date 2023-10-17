using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManager;

    [SerializeField] private GameObject objStatus;
    [SerializeField] private GameObject objInventory;
    [SerializeField] private GameObject objSkill;
    [SerializeField] private GameObject objDungeon;

    private bool isAuto = false;


    private void Awake()
    {
        Button[] arrayBtn = GetComponentsInChildren<Button>(true);
        arrayBtn[0].onClick.AddListener(exit);
        arrayBtn[1].onClick.AddListener(callstatus);
        arrayBtn[2].onClick.AddListener(callinventory);
        arrayBtn[3].onClick.AddListener(callskill);
        arrayBtn[4].onClick.AddListener(calldungeon);
        arrayBtn[5].onClick.AddListener(Auto);
        //arrayBtn[6].onClick.AddListener(Skill1);
        //arrayBtn[7].onClick.AddListener(Skill2);
        //arrayBtn[8].onClick.AddListener(Skill3);
        //arrayBtn[9].onClick.AddListener(Skill4);
        //arrayBtn[10].onClick.AddListener(Skill5);
        //arrayBtn[11].onClick.AddListener(Skill6);
        //arrayBtn[12].onClick.AddListener(Skill7);
        //arrayBtn[13].onClick.AddListener(Skill8);

    }
    public bool IsAuto()
    {
        return isAuto;
    }

    private void Start()
    {
        objStatus.SetActive(false);
        objInventory.SetActive(false);
        objSkill.SetActive(false);
    }
    private void exit()
    {
        objStatus.SetActive(false);
        objInventory.SetActive(false);
        objSkill.SetActive(false);
    }
    private void callstatus()
    {
        objStatus.SetActive(true);
    } 
    private void callinventory()
    {
        objInventory.SetActive(true);
    }
    private void callskill()
    {
        objSkill.SetActive(true);
    }
    private void calldungeon() 
    {

    }
    private void Auto()
    {
        if (isAuto == false)
        {
            isAuto = true;

        }
        else if (isAuto == true)
        {
            isAuto = false;
        }
    }
}
