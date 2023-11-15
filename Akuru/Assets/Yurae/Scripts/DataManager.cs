using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static GameObject container;

    // ---�̱������� ����--- //
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

    // --- ���� ������ �����̸� ���� ("���ϴ� �̸�(����).json") --- //
    string GameDataFileName = "GameData.json";

    // --- ����� Ŭ���� ���� --- //
    public Data data = new Data();


    // �ҷ�����
    public void LoadGameData()
    {
        string filePath = Application.dataPath + "/" + GameDataFileName;

        // ����� ������ �ִٸ�
        if (File.Exists(filePath))
        {
            // ����� ���� �о���� Json�� Ŭ���� �������� ��ȯ�ؼ� �Ҵ�
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


    // �����ϱ�
    public void SaveGameData()
    {
        // Ŭ������ Json �������� ��ȯ (true : ������ ���� �ۼ�)
        string ToJsonData = JsonUtility.ToJson(data, true);
        string filePath = Application.dataPath + "/" + GameDataFileName;

        // �̹� ����� ������ �ִٸ� �����, ���ٸ� ���� ���� ����
        File.WriteAllText(filePath, ToJsonData);
    }
}