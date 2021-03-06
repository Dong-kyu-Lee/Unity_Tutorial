using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private GunController theGunController;
    private Gun currentGun;

    // 필요하면 HUD호출 아니면 HUD 비활성화
    [SerializeField]
    private GameObject go_BulletHUD;

    [SerializeField]
    private Text[] text_Bullet;


    // Update is called once per frame
    void Update()
    {
        CheckBullet();
    }

    void CheckBullet()
    {
        currentGun = theGunController.GetGun();
        text_Bullet[0].text = currentGun.carryBulletCount.ToString();
        text_Bullet[1].text = currentGun.reloadBulletCount.ToString();
        text_Bullet[2].text = currentGun.currentBulletCount.ToString();
    }
}
