using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using UnityEditor.EditorTools;

public class GameManager : MonoBehaviour
{
    // UI 종류
    public GameObject customerList;
    public GameObject purchaseStand;

    // 진열장 추가 창
    public GameObject[] purchase;
    public int purchaseNum;

    // 손님 리스트
    public GameObject[] customers;
    private int currentCustomersNum;
    public Button listLeft;
    public Button listRight;
    public Text customerName;
    public Text customerInst;
    public Text likeability;

    // 재화 종류
    public Text ruby;
    public Text coin;

    // 현재 재화 보유량
    public int currentRuby;
    public int currentCoin;

    // 계산 시간 슬라이더
    public Slider progress;

    // 게임 가속버튼 판정
    public bool doubleSpeed = false;

    // 손님, 탕후루 인자값 가져오기
    public CustomerSpawner customerSpawner;
    public TanghuluSpawner tanghuluSpawner;
    public int favorite;

    //Sinleton Pattern
    public static GameManager instance;
    private void Awake()
    {
        customerSpawner = FindObjectOfType<CustomerSpawner>();
        tanghuluSpawner = FindObjectOfType<TanghuluSpawner>();

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
        currentRuby = 99999;
        currentCoin = 700;
    }


    public void Update()
    {
        // 현재 재화
        ruby.text = "루비 : " + currentRuby;
        coin.text = "코인 : " + currentCoin;

        // 계산 시간
        {

        }
    }

    public void PayCheck()
    {
        GameObject[] tanghulus = instance.tanghuluSpawner.tanghulus;

        GameObject tanghuluWithFavorite = null;

        for (int i = 0; i < tanghulus.Length; i++)
        {
            if (tanghulus[i] != null)
            {
                GameObject tanghuluComponent = tanghulus[i].GetComponent<GameObject>();

                if (tanghuluComponent != null && i == favorite)
                {
                    tanghuluWithFavorite = tanghuluComponent;
                    tanghuluWithFavorite.SetActive(false);

                    Debug.Log(favorite);
                    break; // 원하는 컴포넌트를 찾았으므로 루프 종료
                }
            }
        }


    }

    // 진열장 관련
    // 진열장 구매 UI 오픈
    public void PurchaseOpen(int buttonIndex)
    {
        if (buttonIndex == 0 || !purchase[(buttonIndex - 1)].activeSelf)
        {
            purchaseNum = buttonIndex;
            purchaseStand.SetActive(true);
            Debug.Log((purchaseNum + 2) + "번 진열장 선택");
        }
        else
        {
            Debug.Log("이전 진열장을 먼저 해금해주세요");
        }
    }

    // 진열장 구매
    public void Purchase()
    {
        if (currentCoin >= 200)
        {
            currentCoin -= 200;
            Debug.Log("남은 코인 : " + currentCoin);
            purchaseStand.SetActive(false);
            purchase[purchaseNum].SetActive(false);
            Debug.Log((purchaseNum + 2) + "번 진열장 해금");
        }
        else
        {
            Debug.Log("코인이 부족합니다.");
        }
    }

    // 진열장 닫기
    public void PurchaseClose()
    {
        purchaseStand.SetActive(false);
    }


    // 계산 가속버튼
    public void Acceleration()
    {
        Debug.Log("계산 가속");
    }


    // 상점 버튼
    public void Shop()
    {
        Debug.Log("상점");
    }


    // 손님 리스트 UI 관련
    // 손님 리스트 UI 오픈
    public void ListOpen()
    {
        currentCustomersNum = 0;
        customerList.SetActive(true);
        ListChange();
    }

    // 손님 리스트 좌 버튼
    public void ListLeft()
    {
        currentCustomersNum--;

        if (currentCustomersNum < 0)
        {
            currentCustomersNum = customers.Length - 1;
        }
        ListChange();
    }

    // 손님 리스트 우 버튼
    public void ListRight()
    {
        currentCustomersNum++;

        if (currentCustomersNum >= customers.Length)
        {
            currentCustomersNum = 0;
        }
        ListChange();
    }

    // 손님 리스트 정보 전환
    public void ListChange()
    {
        switch (currentCustomersNum)
        {
            case 0:
                customerName.text = "딸기콩";
                customerInst.text = "딸기 탕후루를 좋아하는 아쿠루\n사랑스러운 미소를 지으며 달콤함을 느끼는 중";
                break;
            case 1:
                customerName.text = "청포뿌";
                customerInst.text = "청포도 탕후루를 좋아하는 아쿠루.\n재미있는 몸짓으로 주변을 환하게 밝힌다.";
                break;
            case 2:
                customerName.text = "귤랑";
                customerInst.text = "귤 탕후루를 좋아하는 아쿠루.\n호기심이 많아 이것저것 건드리다 자주 다친다.";
                break;
            case 3:
                customerName.text = "파인토";
                customerInst.text = "파인애플 탕후루를 좋아하는 아쿠루.\n여기저기 돌아다니는 것을 좋아한다.";
                break;
            case 4:
                customerName.text = "블루포";
                customerInst.text = "블루베리 탕후루를 좋아하는 아쿠루.\n폴짝 폴짝 뛰어다니기를 좋아한다.";
                break;
            default:
                break;
        }

        for (int i = 0; i < customers.Length; i++)
        {
            if (i == currentCustomersNum)
            {
                customers[i].SetActive(true);
            }
            else
            {
                customers[i].SetActive(false);
            }
        }
    }

    // 손님 리스트 UI 닫기
    public void ListClose()
    {
        customerList.SetActive(false);
    }


    //주방 씬으로 이동
    public void Kitchen()
    {
        Debug.Log("주방씬 이동");
    }


    // 배속 버튼
    public void DoubleSpeed()
    {
        // 아쿠루 생성속도, 아쿠루 이동속도, 계산속도 변경
        // 기본속도일 때
        if (!doubleSpeed)
        {
            Debug.Log("게임 2배속");
            doubleSpeed = true;
        }
        // 두배속일 때
        else if (doubleSpeed)
        {
            Debug.Log("게임 정상 배속");
            doubleSpeed = false;
        }
    }


    // 설정창 UI 오픈
    public void Setting()
    {
        Debug.Log("설정창 오픈");
    }


    // 레벨창 UI 오픈
    public void Level()
    {
        Debug.Log("레벨창 오픈");
    }


    // 출석 체크 UI 오픈
    public void Check()
    {
        Debug.Log("출석체크 오픈");
    }


    // 쿼스트창 UI 오픈
    public void Quest()
    {
        Debug.Log("퀘스트 오픈");
    }


    // 룰렛 UI 오픈
    public void Roulette()
    {
        Debug.Log("룰렛 오픈");
    }


    // 이벤트 UI 오픈
    public void Event()
    {
        Debug.Log("이벤트 오픈");
    }
}