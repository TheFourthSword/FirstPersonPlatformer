using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixcursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //yay nu kan je op dingen klikken bij het eindscherm
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
