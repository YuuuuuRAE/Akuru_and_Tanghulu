using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConvertScene : MonoBehaviour
{
    // 각 버튼에 넣으시면 됩니다.
    // 생산소(AT_100) 씬으로 이동
    public void AT_100()
    {
        GameManager.instance.SceneName = "AT_100";
        SceneManager.LoadScene("AT_100");
        Debug.Log("생산소 씬으로 이동");
    }

    // 제작소(AT_200) 씬으로 이동
    public void AT_200()
    {

        GameManager.instance.SceneName = "AT_200";
        SceneManager.LoadScene("AT_200");
        Debug.Log("제작소 씬으로 이동");
    }

    // 판매소(AT_300) 씬으로 이동
    public void AT_300()
    {
        GameManager.instance.SceneName = "AT_300";
        SceneManager.LoadScene("AT_300");
        Debug.Log("판매소 씬으로 이동");
    }

    // 룰렛 씬으로 이동
    public void Roulette()
    {
        SceneManager.LoadScene("Roulette");
        Debug.Log("룰렛 씬으로 이동");
    }

    public void BackRoulette()
    {
        SceneManager.LoadScene(GameManager.instance.SceneName);
        Debug.Log("마지막 씬 : " + GameManager.instance.SceneName + "로 이동");
    }
}
