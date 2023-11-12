using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AkuruSlider : MonoBehaviour
{
    Slider akuruSlider;
    Player player;
    PotInventory potInventory;

    // Start is called before the first frame update
    void Start()
    {
        akuruSlider = GameObject.Find(name: "AkuruSlider").GetComponent<Slider>();
        player = GameObject.Find(name: "Akuru(Player)").GetComponent<Player>();
        potInventory = FindAnyObjectByType<PotInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(potInventory.isPotFull || player.isAkuruWorking == false)
        {
            akuruSlider.gameObject.SetActive(false);
        }
        else if (!potInventory.isPotFull && player.isAkuruWorking == true)
        {
            akuruSlider.gameObject.SetActive(true);
        }
        
    }
}
