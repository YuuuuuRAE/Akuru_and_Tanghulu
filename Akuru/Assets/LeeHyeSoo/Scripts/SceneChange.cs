using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string AT_100; //����� ��
    public string AT_200; //���ۼ� ��
    public string AT_300; //�Ǹż� ��

    
    public void GoToAT100()
    {
        Debug.Log("���� ��:"+  AT_100);
        //SceneManager.LoadScene(AT_100);
    }

    public void GoToAT200()
    {
        Debug.Log("���� ��:" + AT_200);
        //SceneManager.LoadScene(AT_200);
    }

    public void GoToAT300()
    {
        Debug.Log("���� ��:" + AT_300);
        //SceneManager.LoadScene(AT_300);
    }
}
