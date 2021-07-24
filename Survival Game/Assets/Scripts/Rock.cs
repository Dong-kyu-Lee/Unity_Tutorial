using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    private int hp;

    [SerializeField]
    private float destroytime; //파편 제거 time

    [SerializeField]
    private SphereCollider col;

    [SerializeField]
    private GameObject go_rock; //일반 바위
    [SerializeField]
    private GameObject go_debris; //깨진 바위
    [SerializeField]
    private GameObject go_effect_prefab;

    [SerializeField]
    private string strike_Sound;
    [SerializeField]
    private string destroy_Sound;

    private void Start()
    {
        
    }

    public void Mining()
    {
        SoundManager.instance.PlaySE(strike_Sound);

        var clone = Instantiate(go_effect_prefab, col.bounds.center, Quaternion.identity);
        Destroy(clone, 3f);

        hp--;
        if(hp <= 0)
        {
            Destruction();
        }
    }

    private void Destruction()
    {
        SoundManager.instance.PlaySE(destroy_Sound);

        col.enabled = false;
        Destroy(go_rock);
        go_debris.SetActive(true);
        Destroy(go_debris, destroytime);
    }
}
