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
        arrayBtn[0].onClick.AddListener(callstatus);
        arrayBtn[1].onClick.AddListener(callinventory);
        arrayBtn[2].onClick.AddListener(callskill);
        arrayBtn[3].onClick.AddListener(calldungeon);
        
    }
    private void Start()
    {
        objStatus.SetActive(false);
        objInventory.SetActive(false);
        objSkill.SetActive(false);
    }
    private void callstatus()
    {
        
    }
    private void callinventory()
    {
        
    }
    private void callskill()
    {
        
    }
    private void calldungeon() 
    {
    }


}
