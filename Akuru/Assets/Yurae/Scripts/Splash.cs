using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    public GameObject SplashImage;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadScene", 3);
    }

    private void LoadScene()
    {
        if (GameManager.instance.iSFirstStart)
        {
            SceneManager.LoadScene("AT_100");
        }
        else
        {
            SceneManager.LoadScene("AT_200");
        }
    }
}
