using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    private int hp;

    [SerializeField]
    private float destroytime; //���� ���� time

    [SerializeField]
    private SphereCollider col;

    [SerializeField]
    private GameObject go_rock; //�Ϲ� ����
    [SerializeField]
    private GameObject go_debris; //���� ����
    [SerializeField]
    private GameObject go_effect_prefab;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip effect_sound;
    [SerializeField]
    private AudioClip effect_sound2;


    private void Start()
    {
        
    }

    public void Mining()
    {
        audioSource.clip = effect_sound;
        audioSource.Play();
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
        audioSource.clip = effect_sound2;
        audioSource.Play();

        col.enabled = false;
        Destroy(go_rock);
        go_debris.SetActive(true);
        Destroy(go_debris, destroytime);
    }
}
