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
        //���� �ϴ� ��ư �� [����], [�⼮üũ],[�̺�Ʈ],[����Ʈ],[���ӱ���]
        //��ư�� ��ġ���� ���� ����
        if (Input.GetButtonDown("Cancel"))
        {
            if (PopUp_Object.activeSelf)
                PopUp_Object.SetActive(false);
            else
                PopUp_Object.SetActive(true);
        }






    }
}
