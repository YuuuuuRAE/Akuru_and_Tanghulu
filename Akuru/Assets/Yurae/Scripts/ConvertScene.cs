using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConvertScene : MonoBehaviour
{
    // �� ��ư�� �����ø� �˴ϴ�.
    // �����(AT_100) ������ �̵�
    public void AT_100()
    {
        GameManager.instance.SceneName = "AT_100";
        SceneManager.LoadScene("AT_100");
        Debug.Log("����� ������ �̵�");
    }

    // ���ۼ�(AT_200) ������ �̵�
    public void AT_200()
    {

        GameManager.instance.SceneName = "AT_200";
        SceneManager.LoadScene("AT_200");
        Debug.Log("���ۼ� ������ �̵�");
    }

    // �Ǹż�(AT_300) ������ �̵�
    public void AT_300()
    {
        GameManager.instance.SceneName = "AT_300";
        SceneManager.LoadScene("AT_300");
        Debug.Log("�Ǹż� ������ �̵�");
    }

    // �귿 ������ �̵�
    public void Roulette()
    {
        SceneManager.LoadScene("Roulette");
        Debug.Log("�귿 ������ �̵�");
    }

    public void BackRoulette()
    {
        SceneManager.LoadScene(GameManager.instance.SceneName);
        Debug.Log("������ �� : " + GameManager.instance.SceneName + "�� �̵�");
    }
}
