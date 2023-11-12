using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PopupMessage : MonoBehaviour
{
    public float timer = 0;
    float waitTime = 3;


    public GameObject fullMessage; // 굳히소가 가득찼을때 메세지


    public GameObject recipePopUp; //레시피 팝업창
    public GameObject freezerPopUp; //굳히소 구매 팝업창
    
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
        //터치했을 때 판매대로 하나씩 넘어감
        //판매대가 가득찼으면 터치했을때 뜨도록 onclick 작성

        // if(GameManager.instance.(판매대 가득참) == true)
        if (Input.GetKeyDown(KeyCode.Space)) //판매대가 가득찼을때 
        {
            IsFreezerFull();
        }

        if (fullMessage.activeSelf == true) //판매대가 가득찼을때 메세지는 3초뒤에 사라짐
        {
            timer += Time.deltaTime;
            Color clear = new Color(1, 1, 1, 0);

            if (timer >= waitTime)
            {
                StartCoroutine(FadeCoroutine()); //서서히 사라지도록 
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
            yield return new WaitForSeconds(0.01f); // 0.01초마다 실행 
            fullMessageImg.color = new Color(1, 1, 1, fadeCount);
            fullMessageButton.color = new Color(1, 1, 1, fadeCount);
        }
    }

    public void IsFreezerFull() //판매대가 가득차면
    {
        fullMessageImg.color = new Color(1, 1, 1, 1);
        fullMessageButton.color = new Color(1, 1, 1, 1);
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


