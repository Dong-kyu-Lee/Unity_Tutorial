using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range; //���� ���� ����

    private bool pickupActivate; //���� ��������

    private RaycastHit hitInfo;

    //������ ���̾�� �����ϵ��� ��
    [SerializeField]
    private LayerMask LayerMask;

    //�ʿ��� ������Ʈ
    [SerializeField]
    private Text actionText;
    [SerializeField]
    private Inventory inventory;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckItem();
        TryAction();
    }

    void TryAction()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();
            CanPickUp();
        }
    }

    void CanPickUp()
    {
        if(pickupActivate)
        {
            if (hitInfo.transform != null)
            {
                inventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickup>().item);
                Destroy(hitInfo.transform.gameObject);
                InfoDisappear();
            }
        }
    }

    void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, LayerMask))
        {
            if (hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
            }

        }
        else
            InfoDisappear();
    }

    void ItemInfoAppear()
    {
        pickupActivate = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickup>().item.itemName + "ȹ��" + "<color=yellow>" + "(E)" + "</color>";
    }

    void InfoDisappear()
    {
        pickupActivate = false;
        actionText.gameObject.SetActive(false);
    }
}
