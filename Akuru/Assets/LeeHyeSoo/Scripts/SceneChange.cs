using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string AT_100; //ª˝ªÍº“ æ¿
    public string AT_200; //¡¶¿€º“ æ¿
    public string AT_300; //∆«∏≈º“ æ¿

    
    public void GoToAT100()
    {
        Debug.Log("¥Ÿ¿Ω æ¿:"+  AT_100);
        //SceneManager.LoadScene(AT_100);
    }

    public void GoToAT200()
    {
        Debug.Log("¥Ÿ¿Ω æ¿:" + AT_200);
        //SceneManager.LoadScene(AT_200);
    }

    public void GoToAT300()
    {
        Debug.Log("¥Ÿ¿Ω æ¿:" + AT_300);
        //SceneManager.LoadScene(AT_300);
    }
}
