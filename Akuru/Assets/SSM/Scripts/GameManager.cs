using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("과일/탕후루 개수 리스트")]
    //과일 리스트
    // 0 = 딸기  /  1 = 청포도  /  2 = 귤  /  3 = 파인애플  /  4 = 블루베리  

    public List<int> fruitNumList; // 과일 갯수 / 유래님이 수확한 과일 이곳에 쌓이도록
<<<<<<< HEAD
    public List<int> tangfuruNumList; // 탕후루 갯수 / 제작소에서 만든 탕후루 이곳에 쌓이도록 코드작성함
=======
    public List<int> tangfuruNumList; // 탕후루 갯수 / 제작소에서 만든 탕후루 이곳에 쌓이도록
>>>>>>> parent of f8a414f (Repair GameManager)

    [Header("텍스트")]
    // 재화 텍스트 종류
    public Text playerLevel;
    public Text ruby;
    public Text coin;

    [Header("레벨")]
    //현재 레벨
    public int currentLevel;
    //레벨업을 위해 모아야할 경험치
    public int nextLevelUpExp;
    //레벨업을 위해 모인 현재 경험치
    public int currentExp;

    [Header("재화 보유량")]
    // 현재 재화 보유량
    public float currentRuby;
    public float currentCoin;

    [Header("게임 가속 버튼")]
    // 게임 가속버튼 판정
    public bool isdoubleSpeed;

    [Header("레벨업 팝업")]
    public Text playerLevelPopUp_Level;
    public Slider playerLevelPopUp_Slider;
    public Text playerLevelPopUp_SliderText;

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

        currentLevel = 1;
        nextLevelUpExp = 3;
        currentCoin = 3000;
        currentRuby = 1000;
    }

    void Update()
    {
        PlayerLevelUp();

        playerLevel.text = currentLevel.ToString();
        playerLevelPopUp_Level.text = currentLevel.ToString();
        playerLevelPopUp_SliderText.text = currentExp + " / " + nextLevelUpExp;

        playerLevelPopUp_Slider.maxValue = nextLevelUpExp;
        playerLevelPopUp_Slider.value = currentExp;

        // 현재 재화

        ruby.text = FormatNumber(currentRuby);
        coin.text = FormatNumber(currentCoin);
    }

    // 숫자를 천 단위 구분 기호가 있는 문자열로 서식화
    private string FormatNumber(float number)
    {
        return string.Format("{0:N0}", number);

    }

    void PlayerLevelUp() //플레이어 레벨업
    {
        if(currentExp >= nextLevelUpExp)
        {
            currentLevel += 1;
            currentExp -= nextLevelUpExp; 
            nextLevelUpExp += 5; //exp증가분 5
        }

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