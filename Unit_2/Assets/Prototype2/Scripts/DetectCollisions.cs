using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.layer != other.gameObject.layer)
        {
            Destroy(gameObject);
            if (other.gameObject.layer != 3)
            {
                Destroy(other.gameObject);
                GameManager.Score += 1;
                Debug.Log("Score: " + GameManager.Score);
            }
        }
    }
}
