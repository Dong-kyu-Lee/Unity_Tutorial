using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public string gunName;
    public float range;
    public float accuracy; //��Ȯ��
    public float fireRate; //����ӵ�
    public float reloadTime; //������ �ӵ�

    public int damage;

    public int reloadBulletCount; //�Ѿ� ������ ����
    public int currentBulletCount; //źâ�� ���� �Ѿ� ����
    public int maxBulletCount; //�ִ� ���� ���� �Ѿ� ����
    public int carryBulletCount; // �����ϰ� �ִ� �Ѿ� ����

    public float retroActionForce; //�ݵ� ����
    public float retroActionFineSightForce; //������ �� �ݵ� ����

    public Vector3 fineSightOriginPos;
    public Animator anim;
    public ParticleSystem muzzleFlash;
    public AudioClip fire_Sound;


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
