using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField]
    private Slider xpBar;
    public Text LV_in_Main;
    public Text LV_in_AdmLV;
    public Text XP;

    public Contena contena;

    

    /*
     Lv 1 = 3xp
    ���� 5LV�� 5���� 1�� �������� ����
     */
    public int PlayerLevel = 1; //���� �÷��̾��� ���� MaxLv = 5 (���� ��ȹ���� ����)


    private float maxXP = 3; //�ʿ� ����ġ
    private float curXP = 0; //���� ���� ����ġ
    private float increment_XP = 5; //����ġ ������

    public float test_XP = 3; //�׽�Ʈ�� ���� ����ġ


    // Start is called before the first frame update
    void Start()
    {
        xpBar.value = (float)curXP / (float)maxXP;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

            curXP += test_XP;
            if (curXP >= maxXP)
            {
                curXP = curXP - maxXP; //�ʰ� ����ġ�� ���� ����ġ ������ �ʿ� ����ġ ���� �� ��
                LevelUP(); //�÷��̾� ������
                if (PlayerLevel != 1 && PlayerLevel % 5 == 1) //�÷��̾� ������ 1�� �ƴϰ� 5�� ���� �������� 1�϶� �������� 1 ���� ��Ŵ
                {
                    increment_XP++;
                }
                maxXP += increment_XP;
            }
        }

        LoadGameControl();
        HandleXP();
        ShowCurXP();
    }

    private void LoadGameControl()
    {
        GameControl.Instance.MaxXp = maxXP;
        GameControl.Instance.CurrentXp = curXP;
        GameControl.Instance.IncrementXp = increment_XP;
    }

    //�����̴� ���� �Լ�
    private void HandleXP()
    {
        xpBar.value = GameControl.Instance.CurrentXp / GameControl.Instance.MaxXp;
    }


    //������ ���� �Լ� 
    private void LevelUP()
    {
        GameControl.Instance.Level++;
        LV_in_AdmLV.text = GameControl.Instance.Level.ToString();
        LV_in_Main.text = GameControl.Instance.Level.ToString();
    }

    //���� ����ġ ���� ���� �Լ�
    private void ShowCurXP()
    {
        XP.text = GameControl.Instance.CurrentXp.ToString() + " / " + GameControl.Instance.MaxXp.ToString();
    }
}
