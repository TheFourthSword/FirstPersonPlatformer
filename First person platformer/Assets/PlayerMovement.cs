using System.Collections;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce;
    public float sidewaysForce;
    public float jumpForce;
    public float dashForce;
    public int dashFrames;
    bool grounded;
    bool dashPolice = true;
    bool isDashing = false;

    void Start()
    {
     
    }

    void Update()
    {
        Vector3 vel = Vector3.zero;
        if (Input.GetKey("w"))
        {
            vel += transform.forward * forwardForce;
        }
        if (Input.GetKey("s"))
        {
            vel -= transform.forward * forwardForce;
        }
        if (Input.GetKey("a"))
        {
            vel -= transform.right * sidewaysForce;

        }
        if (Input.GetKey("d"))
        {
            vel += transform.right * sidewaysForce;
        }
        if (isDashing)
        {
            vel += transform.forward * dashForce;
        }
        rb.velocity = new Vector3(vel.x, rb.velocity.y, vel.z);
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
            if (Input.GetMouseButtonDown(0) && dashPolice)
        {
            StartCoroutine(Dash());
            dashPolice = false;      
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //check of de speler wel op de grond staat om deze later op te roepen
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            dashPolice = true;
        }

        //als de speler met de death plane collide, start het level opnieuw
        if (collision.gameObject.tag == "Death")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //als de speler de finish aanraakt, krijgen zij de win screen
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("WinScreen");
        }

        if (collision.gameObject.tag == "Next")
        {
            SceneManager.LoadScene("bigLevel");
        }
    }
    void OnCollisionExit(Collision collision)
    {
        //als de speler niet op de grond staat kunnen zij ook niet springen
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;
        yield return new WaitForSeconds(dashFrames);
        isDashing = false;
    }
}

