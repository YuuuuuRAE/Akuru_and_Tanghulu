using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockFreezer : MonoBehaviour
{
    //이전 굳히소를 해금하지 않으면 해금되지 않도록 ((수정하기))
    public void ClickUnlockfreezer()
    {
        gameObject.SetActive(false);

    }
}
