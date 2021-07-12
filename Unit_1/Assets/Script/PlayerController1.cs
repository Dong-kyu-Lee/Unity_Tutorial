using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private float speed = 10.0f;
    public float turnSpeed = 45.0f;
    public float horizontalInput;
    private float forwardInput;

    private float inputZ;
    private float inputX;

    void Start()
    {
        
    }

    void Update()
    {
        /*if(Input.GetKey(KeyCode.UpArrow))
        {
            inputZ = 1;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            inputZ = -1;
        }*/
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
