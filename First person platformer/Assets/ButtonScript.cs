using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Beginnen()
    {
        SceneManager.LoadScene("new level");
    }

    public void Stoppen()
    {
        Application.Quit();
    }
}
