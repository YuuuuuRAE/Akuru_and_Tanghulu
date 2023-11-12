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


    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.CurrentLevel >= 5)
        {
            GameManager.instance.isUnlock = true;
        }


        xpBar.value = GameManager.instance.CurrentXp / GameManager.instance.MaxXp;

        LV_in_AdmLV.text = GameManager.instance.CurrentLevel.ToString();
        LV_in_Main.text = GameManager.instance.CurrentLevel.ToString();
        XP.text = GameManager.instance.CurrentXp.ToString() + " / " + GameManager.instance.MaxXp.ToString();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.instance.CurrentXp += 3;
        }
    }


}
