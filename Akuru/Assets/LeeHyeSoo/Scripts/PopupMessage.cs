using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupMessage : MonoBehaviour
{
    float timer = 0;
    float waitTime = 3;


    public GameObject fullMessage; // 굳히소가 가득찼을때 메세지
    public GameObject recipePopUp; //레시피 팝업창
    public GameObject freezerPopUp; //굳히소 구매 팝업창
    public GameObject AT_2A1PopUp;
    //[Header("상단UI")]
    //public GameObject attendancePopUp; //출석 팝업창
    //public GameObject questPopUp; //퀘스트 팝업창
    //public GameObject roulettePopUp; //룰렛 팝업창
    //public GameObject eventPopUp; //이벤 팝업창



    private void Start()
    {
        fullMessage.SetActive(false);
        recipePopUp.SetActive(false);
        freezerPopUp.SetActive(false);
        AT_2A1PopUp.SetActive(false);


    }

    private void Update()
    {
        if (fullMessage.activeSelf == true) //굳히소가 가득찼을때 메세지는 3초뒤에 사라짐
        {
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                fullMessage.SetActive(false);
                timer = 0;
            }
        }

        
    }

    public void IsFreezerFull() //굳히소가 가득차면 뜨도록 ((수정하기))
    {
        fullMessage.SetActive(true);
        
    }
    

    public void ClickRecipePopUp() //레시피 팝업창을 열었을때 
    {
        recipePopUp.SetActive(true);

    }

    public void ClickRecipePopUp_X() //레시피 팝업창의 x를 눌렀을때
    {
        recipePopUp.SetActive(false);

    }

    public void ClickAT_2A1PopUp() //레시피 팝업창을 열었을때 
    {
        AT_2A1PopUp.SetActive(true);

    }

    public void ClickAT_2A1PopUp_X() //레시피 팝업창의 x를 눌렀을때
    {
        AT_2A1PopUp.SetActive(false);

    }

    public void ClickFreezerPopUp() //굳히소 구매버튼을 눌렀을때
    {
        freezerPopUp.SetActive(true);
    }

    public void ClickFreezerPopUp_X() //굳히소 구매버튼 x를 눌렀을 때
    {
        freezerPopUp.SetActive(false);
    }

    //public void ClickAttendancePopUp() //출석 팝업창을 열었을 때 
    //{
    //    attendancePopUp.SetActive(true);
    //}

    //public void ClickAttendancePopUp_X() //출석 팝업창x를 눌렀을때
    //{
    //    attendancePopUp.SetActive(false);
    //}

    //public void ClickQuestPopUp() //퀘스트 팝업창을 열었을때
    //{
    //    attendancePopUp.SetActive(true);
    //}

    //public void ClickQuestPopUp_X() //퀘스트 팝업창x를 눌렀을때
    //{
    //    attendancePopUp.SetActive(false);
    //}

    //public void ClickRoulettePopUp() //룰렛 팝업창을 열었을때
    //{
    //    roulettePopUp.SetActive(true);
    //}

    //public void ClickRoulettePopUp_X() //룰렛 팝업창x를 눌렀을때
    //{
    //    roulettePopUp.SetActive(false);
    //}

    //public void ClickEventPopUp() //이벤 팝업창을 열었을때
    //{
    //    eventPopUp.SetActive(true);
    //}

    //public void ClickEventPopUp_X() //이벤 팝업창x를 눌렀을때
    //{
    //    eventPopUp.SetActive(false);
    //}
}


