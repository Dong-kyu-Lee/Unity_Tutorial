using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSpin : MonoBehaviour
{
    public float spinSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * spinSpeed);
    }
}
