using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezerGroup : MonoBehaviour
{
    TangfuruGoToFreezer tangfuruGoToFreezer;
    Player player;
    PotInventory potInventory;

    public List<Freezer> freezers;

    void Start()
    {
        tangfuruGoToFreezer = FindAnyObjectByType<TangfuruGoToFreezer>();
        player = GameObject.Find(name: "Akuru(Player)").GetComponent<Player>();
        potInventory = FindAnyObjectByType<PotInventory>();
    }

    void Update()
    {

    }

    public void PlusTangfuruInFreezer(int f_Index, int t_Index) // 탕후루 정보 충돌한 냉장고에 저장하기 / (냉장고번호, 탕후루번호)
    {
        Debug.Log(f_Index);
        Debug.Log(player.fruits[t_Index]); //Pineapple (Fruit)

        freezers[f_Index].inFreezer.Add(player.fruits[t_Index]);

        
    }
}
