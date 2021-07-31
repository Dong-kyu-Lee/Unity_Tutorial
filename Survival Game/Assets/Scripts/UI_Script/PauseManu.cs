using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManu : MonoBehaviour
{
    [SerializeField] private GameObject go_BaseUI;
    [SerializeField] private SaveAndLoad theSaveAndLoad;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (!GameManager.isPause)
            {
                CallMenu();
            }
            else CloaseMenu();
        }
    }

    void CallMenu()
    {
        GameManager.isPause = true;
        go_BaseUI.SetActive(true);
        Time.timeScale = 0f; //�ð� ����
    }

    void CloaseMenu()
    {
        GameManager.isPause = false;
        go_BaseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ClickSave()
    {
        Debug.Log("���̺�");
        theSaveAndLoad.SaveData();
    }
    public void ClickLoad()
    {
        Debug.Log("�ε�");
        theSaveAndLoad.LoadData();
    }
    public void ClickExit()
    {
        Debug.Log("��������");
        Application.Quit();
    }
}
