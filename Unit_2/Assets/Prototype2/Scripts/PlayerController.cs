using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float speed = 10f;
    public float XRange = 10f;
    public float ZRange = 15f;

    public GameObject projectilePrefab;

    void Start()
    {
        
    }

    void Update()
    {
        //Player Move
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);

        if(transform.position.x < -XRange)
        {
            transform.position = new Vector3(-XRange, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > XRange)
        {
            transform.position = new Vector3(XRange, transform.position.y, transform.position.z);
        }
        if(transform.position.z > ZRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, ZRange);
        }
        else if(transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            if (GameManager.Live > 1)
            {
                GameManager.Live -= 1;
                Debug.Log("Live: " + GameManager.Live);
            }
            else { 
                GameManager.Live = 0;
                Debug.Log("Game Over!");
            }
        }
    }
}
