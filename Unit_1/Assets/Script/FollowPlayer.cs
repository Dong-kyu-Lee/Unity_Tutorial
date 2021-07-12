using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -7);
    private Vector3 offset2 = new Vector3(0, 2, 1);
    private Vector3 resetRotation = new Vector3(30, 0, 0);

    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = player.transform.position + offset2;
            transform.rotation = player.transform.rotation;
        }
        else
        {
            transform.rotation = Quaternion.Euler(resetRotation);
            transform.position = player.transform.position + offset;
        }
    }
}
