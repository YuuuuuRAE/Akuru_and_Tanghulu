using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupMessage : MonoBehaviour
{
    float timer = 0;
    float waitTime = 3;


    public GameObject fullMessage; // �����Ұ� ����á���� �޼���
    public GameObject recipePopUp; //������ �˾�â
    public GameObject freezerPopUp; //������ ���� �˾�â
    public GameObject AT_2A1PopUp;
    //[Header("���UI")]
    //public GameObject attendancePopUp; //�⼮ �˾�â
    //public GameObject questPopUp; //����Ʈ �˾�â
    //public GameObject roulettePopUp; //�귿 �˾�â
    //public GameObject eventPopUp; //�̺� �˾�â



    private void Start()
    {
        fullMessage.SetActive(false);
        recipePopUp.SetActive(false);
        freezerPopUp.SetActive(false);
        AT_2A1PopUp.SetActive(false);


    }

    private void Update()
    {
        if (fullMessage.activeSelf == true) //�����Ұ� ����á���� �޼����� 3�ʵڿ� �����
        {
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                fullMessage.SetActive(false);
                timer = 0;
            }
        }

        
    }

    public void IsFreezerFull() //�����Ұ� �������� �ߵ��� ((�����ϱ�))
    {
        fullMessage.SetActive(true);
        
    }
    

    public void ClickRecipePopUp() //������ �˾�â�� �������� 
    {
        recipePopUp.SetActive(true);

    }

    public void ClickRecipePopUp_X() //������ �˾�â�� x�� ��������
    {
        recipePopUp.SetActive(false);

    }

    public void ClickAT_2A1PopUp() //������ �˾�â�� �������� 
    {
        AT_2A1PopUp.SetActive(true);

    }

    public void ClickAT_2A1PopUp_X() //������ �˾�â�� x�� ��������
    {
        AT_2A1PopUp.SetActive(false);

    }

    public void ClickFreezerPopUp() //������ ���Ź�ư�� ��������
    {
        freezerPopUp.SetActive(true);
    }

    public void ClickFreezerPopUp_X() //������ ���Ź�ư x�� ������ ��
    {
        freezerPopUp.SetActive(false);
    }

    //public void ClickAttendancePopUp() //�⼮ �˾�â�� ������ �� 
    //{
    //    attendancePopUp.SetActive(true);
    //}

    //public void ClickAttendancePopUp_X() //�⼮ �˾�âx�� ��������
    //{
    //    attendancePopUp.SetActive(false);
    //}

    //public void ClickQuestPopUp() //����Ʈ �˾�â�� ��������
    //{
    //    attendancePopUp.SetActive(true);
    //}

    //public void ClickQuestPopUp_X() //����Ʈ �˾�âx�� ��������
    //{
    //    attendancePopUp.SetActive(false);
    //}

    //public void ClickRoulettePopUp() //�귿 �˾�â�� ��������
    //{
    //    roulettePopUp.SetActive(true);
    //}

    //public void ClickRoulettePopUp_X() //�귿 �˾�âx�� ��������
    //{
    //    roulettePopUp.SetActive(false);
    //}

    //public void ClickEventPopUp() //�̺� �˾�â�� ��������
    //{
    //    eventPopUp.SetActive(true);
    //}

    //public void ClickEventPopUp_X() //�̺� �˾�âx�� ��������
    //{
    //    eventPopUp.SetActive(false);
    //}
}


