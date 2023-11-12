using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PopupMessage : MonoBehaviour
{
    public float timer = 0;
    float waitTime = 3;


    public GameObject fullMessage; // �����Ұ� ����á���� �޼���


    public GameObject recipePopUp; //������ �˾�â
    public GameObject freezerPopUp; //������ ���� �˾�â
    
    public GameObject AT_2A1PopUp;

    


    [Header("fullMessage")]
    public Image fullMessageImg;
    public Image fullMessageButton;

    



    private void Start()
    {
        
        fullMessage.SetActive(false);
        recipePopUp.SetActive(false);
        freezerPopUp.SetActive(false);
        AT_2A1PopUp.SetActive(false);


    }

    

    private void Update()
    {
        //��ġ���� �� �ǸŴ�� �ϳ��� �Ѿ
        //�ǸŴ밡 ����á���� ��ġ������ �ߵ��� onclick �ۼ�

        // if(GameManager.instance.(�ǸŴ� ������) == true)
        if (Input.GetKeyDown(KeyCode.Space)) //�ǸŴ밡 ����á���� 
        {
            IsFreezerFull();
        }

        if (fullMessage.activeSelf == true) //�ǸŴ밡 ����á���� �޼����� 3�ʵڿ� �����
        {
            timer += Time.deltaTime;
            Color clear = new Color(1, 1, 1, 0);

            if (timer >= waitTime)
            {
                StartCoroutine(FadeCoroutine()); //������ ��������� 
                timer = 0;
            }

            if (fullMessageImg.color == clear)
            {
                fullMessage.SetActive(false);
            }
        }

        
    }

    

    IEnumerator FadeCoroutine()
    {
        float fadeCount = 1;
        
        while (fadeCount > 0)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f); // 0.01�ʸ��� ���� 
            fullMessageImg.color = new Color(1, 1, 1, fadeCount);
            fullMessageButton.color = new Color(1, 1, 1, fadeCount);
        }
    }

    public void IsFreezerFull() //�ǸŴ밡 ��������
    {
        fullMessageImg.color = new Color(1, 1, 1, 1);
        fullMessageButton.color = new Color(1, 1, 1, 1);
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


