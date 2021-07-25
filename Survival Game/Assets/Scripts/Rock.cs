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
    private GameObject go_rock_item_Prefab;

    [SerializeField]
    private int count; //돌맹이 등장 개수

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
        for (int i = 0; i < count; i++)
        {
            Instantiate(go_rock_item_Prefab, go_rock.transform.position, Quaternion.identity);
        }
        Destroy(go_rock);
        go_debris.SetActive(true);
        Destroy(go_debris, destroytime);
    }
}
