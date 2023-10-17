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


    private void Awake()
    {
        Button[] arrayBtn = GetComponentsInChildren<Button>(true);
        arrayBtn[0].onClick.AddListener(exit);
        arrayBtn[1].onClick.AddListener(callstatus);
        arrayBtn[2].onClick.AddListener(callinventory);
        arrayBtn[3].onClick.AddListener(callskill);
        arrayBtn[4].onClick.AddListener(calldungeon);

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

}
