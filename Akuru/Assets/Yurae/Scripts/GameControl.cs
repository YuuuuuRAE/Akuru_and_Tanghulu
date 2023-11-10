using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance;

    //����ġ �� ��ȭ
    public int Level; //����

    public int Ruby; //���
    public int Coin; //����

    //���� ����
    public int CountStrawBerry;
    public int CountGreenGrape;
    public int CountMandarin;
    public int CountPineApple;
    public int BlueBerry;


    //SingleTon
    private void Awake()
    {

        
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }









}
