using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance;

    //경험치 및 재화
    public int Level; //레벨

    public int Ruby; //루비
    public int Coin; //코인

    //과일 개수
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
