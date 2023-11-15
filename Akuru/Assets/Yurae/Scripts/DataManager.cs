using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static GameObject container;

    // ---싱글톤으로 선언--- //
    static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if (!instance)
            {
                container = new GameObject();
                container.name = "DataManager";
                instance = container.AddComponent(typeof(DataManager)) as DataManager;
                DontDestroyOnLoad(container);
            }
            return instance;
        }
    }

    // --- 게임 데이터 파일이름 설정 ("원하는 이름(영문).json") --- //
    string GameDataFileName = "GameData.json";

    // --- 저장용 클래스 변수 --- //
    public Data data = new Data();


    // 불러오기
    public void LoadGameData()
    {
        string filePath = Application.dataPath + "/" + GameDataFileName;

        // 저장된 게임이 있다면
        if (File.Exists(filePath))
        {
            // 저장된 파일 읽어오고 Json을 클래스 형식으로 전환해서 할당
            string FromJsonData = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<Data>(FromJsonData);

            GameManager.instance.iSFirstStart = data.iSFirstStart;
            GameManager.instance.AlertLevel = data.AlertLevel;
            GameManager.instance.openStandNum = data.openStandNum;
            GameManager.instance.isFullStand = data.isFullStand;
            GameManager.instance.MaxFruitType = data.MaxFruitType;
            GameManager.instance.isUnlock = data.isUnlock;
            GameManager.instance.CurrentLevel = data.CurrentLevel;
            GameManager.instance.MaxXp = data.MaxXp;
            GameManager.instance.CurrentXp = data.CurrentXp;
            GameManager.instance.IncrementXp = data.IncrementXp;
            GameManager.instance.currentRuby = data.currentRuby;
            GameManager.instance.currentCoin = data.currentCoin;
            GameManager.instance.SceneName = data.SceneName;
            GameManager.instance.BGMname = data.BGMname;
            GameManager.instance.isBGM = data.isBGM;
            GameManager.instance.isSound = data.isSound;
            GameManager.instance.isVibe = data.isVibe;

            GameManager.instance.fruit_FirstMaking = data.fruit_FirstMaking;
            GameManager.instance.isSelectFT = data.isSelectFT;
            GameManager.instance.fruitNumList = data.fruitNumList;
            GameManager.instance.tangfuruNumList = data.tangfuruNumList;
            GameManager.instance.standsNumList = data.standsNumList;
            GameManager.instance.tangfuruNowNum_Rcp = data.tangfuruNowNum_Rcp;
            GameManager.instance.tangfuruAllNum_Rcp = data.tangfuruAllNum_Rcp;
            GameManager.instance.lockFreezer = data.lockFreezer;
        }
    }


    // 저장하기
    public void SaveGameData()
    {
        // 클래스를 Json 형식으로 전환 (true : 가독성 좋게 작성)
        string ToJsonData = JsonUtility.ToJson(data, true);
        string filePath = Application.dataPath + "/" + GameDataFileName;

        // 이미 저장된 파일이 있다면 덮어쓰고, 없다면 새로 만들어서 저장
        File.WriteAllText(filePath, ToJsonData);
    }
}