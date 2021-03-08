using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReturnToMain : MonoBehaviour
{
    void Update()
    {
        if (this.gameObject && Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
