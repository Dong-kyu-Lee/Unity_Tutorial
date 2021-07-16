using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    bool sending;

    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if(Input.GetKeyDown(KeyCode.Space) && sending == false)
        {
            StartCoroutine("SendDog");
        }
    }
    
    IEnumerator SendDog()
    {
        sending = true;
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        yield return new WaitForSeconds(3f);
        sending = false;
    }
}
