using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    //ü��
    [SerializeField]
    private int hp;
    private int currentHp;

    //���׹̳�
    [SerializeField]
    private int sp;
    private int currentSp;

    //���׹̳� ������
    [SerializeField]
    private int spIncreaseSpeed;

    //���׹̳� ��ȸ�� ������
    [SerializeField]
    private int spRechargeTime;
    private int currentSpRechargeTime;

    //���׹̳� ���� ����
    private bool spUsed;

    //����
    [SerializeField]
    private int dp;
    private int currentDp;

    //�����
    [SerializeField]
    private int hungry;
    private int currentHungry;

    //������� �پ��� �ӵ�
    [SerializeField]
    private int hungryDecreaseTime;
    private int currentHungryDecreaseTime;

    //�񸶸�
    [SerializeField]
    private int thirsty;
    private int currentThirsty;

    [SerializeField]
    private int thirstyDecreaseTime;
    private int currentThirstyDecreaseTime;

    [SerializeField]
    private int satisfy;
    private int currentSatisfy;

    [SerializeField]
    private Image[] images_Gauge;

    private const int HP = 0, DP = 1, SP = 2, HUNGRY = 3, THIRSTY = 4, SATISFY = 5;

    void Start()
    {
        currentSp = sp;
        currentHp = hp;
        currentDp = dp;
        currentHungry = hungry;
        currentThirsty = thirsty;
        currentSatisfy = satisfy;
    }


    void Update()
    {
        Hungry();
        Thirsty();
        SPRechargeTime();
        SPRecover();
        GaugeUpdate();
    }

    void SPRechargeTime()
    {
        if(spUsed)
        {
            if (currentSpRechargeTime < spRechargeTime)
            {
                currentSpRechargeTime++;
            }
            else
                spUsed = false;
        }
    }

    void SPRecover()
    {
        if(!spUsed && currentSp < sp)
        {
            currentSp += spIncreaseSpeed;
        }
    }

    void Hungry()
    {
        if (currentHungry > 0)
        {
            if (currentHungryDecreaseTime <= hungryDecreaseTime)
            {
                currentHungryDecreaseTime++;
            }
            else
            {
                currentHungry--;
                currentHungryDecreaseTime = 0;
            }
        }
        else Debug.Log("����� ��ġ�� 0");
    }

    void Thirsty()
    {
        if (currentThirsty > 0)
        {
            if (currentThirstyDecreaseTime <= thirstyDecreaseTime)
            {
                currentThirstyDecreaseTime++;
            }
            else
            {
                currentThirsty--;
                currentThirstyDecreaseTime = 0;
            }
        }
        else Debug.Log("�񸶸� ��ġ�� 0");
    }

    void GaugeUpdate()
    {
        images_Gauge[HP].fillAmount = (float)currentHp / hp;
        images_Gauge[DP].fillAmount = (float)currentDp / dp;
        images_Gauge[SP].fillAmount = (float)currentSp / sp;
        images_Gauge[HUNGRY].fillAmount = (float)currentHungry / hungry;
        images_Gauge[THIRSTY].fillAmount = (float)currentThirsty / thirsty;
        images_Gauge[SATISFY].fillAmount = (float)currentSatisfy / satisfy;
    }

    public void IncreaseHP(int count)
    {
        if (currentHp + count < hp)
        {
            currentHp += count;
        }
        else currentHp = hp;
    }

    public void DecreaseHP(int count)
    {
        if(currentDp >0)
        {
            DecreaseDP(count);
            return;
        }
        currentHp -= count;
        if (currentHp <= 0)
            Debug.Log("ĳ������ HP�� 0�� �Ǿ����ϴ�.");
    }

    public void IncreaseDP(int count)
    {
        if (currentDp + count < dp)
        {
            currentDp += count;
        }
        else currentDp = dp;
    }

    public void DecreaseDP(int count)
    {
        currentDp -= count;
        if (currentDp <= 0)
            Debug.Log("����(DP)�� 0�� �Ǿ����ϴ�.");
    }

    public void IncreaseHungry(int count)
    {
        if (currentHungry + count < hungry)
        {
            currentHungry += count;
        }
        else currentHungry = hungry;
    }

    public void DecreaseHungry(int count)
    {
        if(currentHungry - count < 0)
        {
            currentHungry = 0;
        }
        else
            currentHungry -= count;
    }

    public void IncreaseThirsty(int count)
    {
        if (currentThirsty + count < thirsty)
        {
            currentThirsty += count;
        }
        else currentThirsty = thirsty;
    }

    public void DecreaseThirsty(int count)
    {
        if (currentThirsty - count < 0)
        {
            currentThirsty = 0;
        }
        else
            currentThirsty -= count;
    }

    public void DecreaseStamina(int count)
    {
        spUsed = true;
        currentSpRechargeTime = 0;

        if (currentSp - count > 0)
            currentSp -= count;
        else
            currentSp = 0;
    }

    public int GetCurrentSP()
    {
        return currentSp;
    }
}