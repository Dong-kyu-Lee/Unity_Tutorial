using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    //체력
    [SerializeField]
    private int hp;
    private int currentHp;

    //스테미나
    [SerializeField]
    private int sp;
    private int currentSp;

    //스테미나 증가량
    [SerializeField]
    private int spIncreaseSpeed;

    //스테미나 재회복 딜레이
    [SerializeField]
    private int spRechargeTime;
    private int currentSpRechargeTime;

    //스테미나 감소 여부
    private bool spUsed;

    //방어력
    [SerializeField]
    private int dp;
    private int currentDp;

    //배고픔
    [SerializeField]
    private int hungry;
    private int currentHungry;

    //배고픔이 줄어드는 속도
    [SerializeField]
    private int hungryDecreaseTime;
    private int currentHungryDecreaseTime;

    //목마름
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
        else Debug.Log("배고픔 수치가 0");
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
        else Debug.Log("목마름 수치가 0");
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
            Debug.Log("캐릭터의 HP가 0이 되었습니다.");
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
            Debug.Log("방어력(DP)이 0이 되었습니다.");
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
