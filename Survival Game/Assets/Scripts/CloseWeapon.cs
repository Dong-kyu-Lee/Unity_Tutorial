using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWeapon : MonoBehaviour
{
    public string closeWeaponName; // 너클이나 맨손 구분

    public bool isHand;
    public bool isAxe;
    public bool isPickaxe;

    public float range; // 공격 범위
    public int damage; // 공격력
    public float workSpeed; //작업속도
    public float attackDelay; //공격딜레이
    public float attackDelayA; //공격 활성화 시점
    public float attackDelayB; //공격 비활성화 시점

    public Animator anim;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
