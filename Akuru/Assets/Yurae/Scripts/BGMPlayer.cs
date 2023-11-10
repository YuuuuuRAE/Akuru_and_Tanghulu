using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGMPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip BGM;

    // Singleton Pattern
    public static BGMPlayer instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("�ı�");
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (GameManager.instance.isBGM == false)
        {
            audioSource.Stop(); //���� ����
        }
        else if (GameManager.instance.isBGM == true && audioSource.isPlaying == false)
        {
            audioSource.Play(); //���ӸŴ��� �� isbgm�� t�̰� ������ �������� �ƴ϶�� ���� ���
        }
    }


}
