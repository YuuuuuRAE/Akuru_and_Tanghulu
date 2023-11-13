using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("게임 첫 시작 여부")]
    public bool iSFirstStart;

    [Header("콘테나 먼저손질")] // true 일 경우 우선 손질 된다 /두개이상 true가 되지 않게 할 것
    public List<bool> fruit_FirstMaking;

    [Header("다음 레벨업을 위한 현재 제작 수량")]
    public List<int> tangfuruNowNum_Rcp; // 레벨업시 0으로 돌아감

    [Header("총 누적 탕후루 제작 갯수")]
    public List<int> tangfuruAllNum_Rcp; 

    [Header("현재 과일/탕후루 개수 리스트")]
    //과일 리스트
    // 0 = 딸기  /  0 = 청포도  /  0 = 귤  /  0 = 파인애플  /  0 = 블루베리  

    public int[] fruitNumList; // 과일 갯수 / 유래님이 수확한 과일 이곳에 쌓이도록
    public int[] tangfuruNumList; // 탕후루 갯수 / 제작소에서 만든 탕후루 이곳에 쌓이도록
    public int[] standsNumList; // 진열해야하는 탕후루 종류별 개수
    public int openStandNum; // 해금된 진열장 갯수

 

    [Header("생산소 관련")]
    public int MaxFruitType; //최대 과일 타입
    public bool isUnlock = false;

    [Header("레벨")]
    //현재 레벨
    public int CurrentLevel = 1;
    public float MaxXp; // 최대 경험치
    public float CurrentXp; //현재 경험치
    public float IncrementXp; //경험치 증가량

    [Header("재화 보유량")]
    // 현재 재화 보유량
    public float currentRuby;
    public float currentCoin;

    [Header("게임 가속 버튼")]
    // 게임 가속버튼 판정
    public bool isdoubleSpeed;

    [Header("룰렛에서 돌아가는 씬")]
    public string SceneName;

    [Header("BGM 이름")]
    public string BGMname;

    [Header("설정 관련")]
    public bool isBGM; //브금 관련
    public bool isSound; //효과음 관련
    public bool isVibe; //진동 관련


    // Singleton Pattern
    public static GameManager instance;
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
            Debug.Log("파괴");
        }
    }

    public void Start()
    {


    }

    void Update()
    {

        if (CurrentXp >= MaxXp)
        {
            CurrentXp = CurrentXp - MaxXp; //초과 경험치는 현재 경험치 량에서 필요 겅험치 량을 뺀 양
            CurrentLevel++; //플레이어 레벨업
            if (CurrentLevel <= 5) MaxFruitType++;
            if (CurrentLevel != 1 && CurrentLevel % 5 == 1) //플레이어 레벨이 1이 아니고 5로 나눈 나머지가 1일때 증가분을 1 증가 시킴
            {
                IncrementXp++;

            }
           MaxXp += IncrementXp;
        }

    }





    // 배속 버튼
    public void DoubleSpeed()
    {
        // 기본속도일 때
        if (!isdoubleSpeed)
        {
            Time.timeScale = 2.0f;
            isdoubleSpeed = true;
            Debug.Log("게임 2배속");
        }
        // 두배속일 때
        else if (isdoubleSpeed)
        {
            Time.timeScale = 1.0f;
            isdoubleSpeed = false;
            Debug.Log("게임 정상 배속");
        }
    }

    // 상점 버튼
    public void Shop()
    {
        Debug.Log("상점");
    }


    // 설정창 UI 오픈 버튼
    public void Setting()
    {
        Debug.Log("설정창 오픈");
    }


    // 레벨창 UI 오픈 버튼
    public void Level()
    {
        Debug.Log("레벨창 오픈");
    }


    // 출석 체크 UI 오픈 버튼
    public void Check()
    {
        Debug.Log("출석체크 오픈");
    }


    // 쿼스트창 UI 오픈 버튼
    public void Quest()
    {
        Debug.Log("퀘스트 오픈");
    }


    // 이벤트 UI 오픈 버튼
    public void Event()
    {
        Debug.Log("이벤트 오픈");
    }
}