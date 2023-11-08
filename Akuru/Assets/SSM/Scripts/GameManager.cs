using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 재화 텍스트 종류
    public Text ruby;
    public Text coin;

    // 현재 재화 보유량
    public float currentRuby;
    public float currentCoin;

    // 게임 가속버튼 판정
    public bool isdoubleSpeed;

    // Sinleton Pattern
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
        currentRuby = 1000;
        currentCoin = 3000;
        isdoubleSpeed = false;
    }

    void Update()
    {
        // 현재 재화
        ruby.text = FormatNumber(currentRuby);
        coin.text = FormatNumber(currentCoin);
    }

    // 숫자를 천 단위 구분 기호가 있는 문자열로 서식화
    private string FormatNumber(float number)
    {
        return string.Format("{0:N0}", number);
    }


    // 각 버튼에 넣으시면 됩니다.
    // 생산소(AT_100) 씬으로 이동
    public void AT_100()
    {
        SceneManager.LoadScene("Production_Plant");
        Debug.Log("생산소 씬으로 이동");
    }

    // 제작소(AT_200) 씬으로 이동
    public void AT_200()
    {
        SceneManager.LoadScene("AT_200");
        Debug.Log("제작소 씬으로 이동");
    }

    // 판매소(AT_300) 씬으로 이동
    public void AT_300()
    {
        SceneManager.LoadScene("Sales");
        Debug.Log("판매소 씬으로 이동");
    }

    // 룰렛 씬으로 이동
    public void Roulette()
    {
        SceneManager.LoadScene("Roulette");
        Debug.Log("룰렛 씬으로 이동");
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