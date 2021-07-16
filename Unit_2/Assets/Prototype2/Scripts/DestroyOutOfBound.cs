using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    private float XLimmit = 20;

    void Start()
    {
        
    }

    void Update()
    {
        if(transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
        if(transform.position.x > XLimmit)
        {
            Destroy(gameObject);
        }
        else if(transform.position.x < -XLimmit)
        {
            Destroy(gameObject);
        }
    }
}
