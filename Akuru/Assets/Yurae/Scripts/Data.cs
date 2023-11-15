using System;
using System.Collections.Generic;

[Serializable] // 직렬화

public class Data
{
    public bool iSFirstStart;
    public int AlertLevel;
    public int openStandNum; // 해금된 진열장 갯수
    public bool isFullStand; // 진열대가 가득 차있는지 체크
    public int MaxFruitType; //최대 과일 타입
    public bool isUnlock;
    public int CurrentLevel;
    public float MaxXp; // 최대 경험치
    public float CurrentXp; //현재 경험치
    public float IncrementXp; //경험치 증가량
    public float currentRuby;
    public float currentCoin;
    public string SceneName;
    public string BGMname;
    public bool isBGM; //브금 관련
    public bool isSound; //효과음 관련
    public bool isVibe; //진동 관련

    public List<bool> fruit_FirstMaking;
    public bool isSelectFT; // 먼저 손질 버튼이 클릭되어 있나?
    public int[] fruitNumList = new int[5];
    public int[] tangfuruNumList; // 탕후루 갯수 / 제작소에서 만든 탕후루 이곳에 쌓이도록
    public int[] standsNumList; // 진열해야하는 탕후루 종류별 개수
    public List<int> tangfuruNowNum_Rcp; // 레벨업시 0으로 돌아감
    public List<int> tangfuruAllNum_Rcp;
    public List<bool> lockFreezer;
}