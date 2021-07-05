using System.Collections;
using System.Threading;
using UnityEngine;

public class FallingComets : MonoBehaviour
{
    public float fallTime;
     
 
    void OnCollisionEnter(Collision collision)
    {
        //als het object met de tag "player" het aanraakt beginnen de astroïden met vallen
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Fall());
        }
    }
    IEnumerator Fall()
    {
        //het zorgen dat de astroïden daadwerkelijk vallen, thanks zwaartekracht
        yield return new WaitForSeconds(fallTime);
        GetComponent<Rigidbody>().useGravity = true;
    }
}
