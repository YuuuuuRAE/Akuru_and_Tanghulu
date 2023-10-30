using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public GameObject PopUp_Object;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //메인 하단 버튼 중 [상점], [출석체크],[이벤트],[퀘스트],[가속광고]
        //버튼을 터치했을 때로 변경
        if (Input.GetButtonDown("Cancel"))
        {
            if (PopUp_Object.activeSelf)
                PopUp_Object.SetActive(false);
            else
                PopUp_Object.SetActive(true);
        }






    }
}
