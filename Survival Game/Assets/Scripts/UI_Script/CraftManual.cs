using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Craft
{
    public string craftName;
    public GameObject go_Prefab; //���� ��ġ�� ������
    public GameObject go_PreviewPrefab; //�̸����� ������
}

public class CraftManual : MonoBehaviour
{
    private bool isActivated = false;
    private bool isPreviewActivated = false;

    [SerializeField]
    private GameObject go_BaseUI;

    [SerializeField]
    private Craft[] crafts_fire; //��ںҿ� ��

    private GameObject go_Preview; //�̸����� �������� ���� ����
    private GameObject go_Prefab; //���� ������ �������� ���� ����

    [SerializeField]
    private Transform tf_Player; //�÷��̾� ��ġ

    //RayCast �ʿ� ���� ����
    private RaycastHit hitInfo;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float range;

    void Start()
    {
        
    }

    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && !isPreviewActivated)
        {
            Window();
        }
        if(isPreviewActivated)
        {
            PreviewPositionUpdate();
        }
        if(Input.GetButtonDown("Fire1"))
        {
            Build();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cancel();
        }
    }

    void Build()
    { 
        if(isPreviewActivated)
        {
            Instantiate(go_Prefab, hitInfo.point, Quaternion.identity);
            Destroy(go_Preview);
            isActivated = false;
            isPreviewActivated = false;
            go_Prefab = null;
            go_Preview = null;
        }
    }

    void PreviewPositionUpdate()
    {
        if(Physics.Raycast(tf_Player.position, tf_Player.forward, out hitInfo, range, layerMask))
        {
            if(hitInfo.transform != null)
            {
                Vector3 _location = hitInfo.point; // �������� ���� ���� ���� ��ǥ ��ȯ
                go_Preview.transform.position = _location;
            }
        }
    }

    void Cancel()
    {
        if (isPreviewActivated)
            Destroy(go_Preview);

        isActivated = false;
        isPreviewActivated = false;
        go_Preview = null;
        go_Prefab = null;

        go_BaseUI.SetActive(false);
    }

    public void SlotClick(int _slotNumber)
    {
        go_Preview = Instantiate(crafts_fire[_slotNumber].go_PreviewPrefab,
                tf_Player.position + tf_Player.forward, Quaternion.identity);
        go_Prefab = crafts_fire[_slotNumber].go_Prefab;
        isPreviewActivated = true;
        go_BaseUI.SetActive(false);
    }
    
    void Window()
    {
        if (!isActivated)
            OpenWindow();
        else
            CloseWindow();
    }

    void OpenWindow()
    {
        isActivated = true;
        go_BaseUI.SetActive(true);
    }

    void CloseWindow()
    {
        isActivated = false;
        go_BaseUI.SetActive(false);
    }
}
