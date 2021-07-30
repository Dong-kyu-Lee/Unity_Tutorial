using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Craft
{
    public string craftName;
    public GameObject go_Prefab; //실제 설치될 프리펩
    public GameObject go_PreviewPrefab; //미리보기 프리펩
}

public class CraftManual : MonoBehaviour
{
    private bool isActivated = false;
    private bool isPreviewActivated = false;

    [SerializeField]
    private GameObject go_BaseUI;

    [SerializeField]
    private Craft[] crafts_fire; //모닥불용 탭

    private GameObject go_Preview; //미리보기 프리팹을 담을 변수
    private GameObject go_Prefab; //실제 생성될 프리팹을 담을 변수

    [SerializeField]
    private Transform tf_Player; //플레이어 위치

    //RayCast 필요 변수 선언
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
                Vector3 _location = hitInfo.point; // 레이저를 쏴서 맞은 곳의 좌표 반환
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
