using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingComets : MonoBehaviour
{
    public float riseTime;
    public float upSpeed;


    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Rise());
        }
    }
    IEnumerator Rise()
    {
        
        yield return new WaitForSeconds(riseTime);
        GetComponent<ConstantForce>().force = new Vector3(0, upSpeed, 0);
    }
}
