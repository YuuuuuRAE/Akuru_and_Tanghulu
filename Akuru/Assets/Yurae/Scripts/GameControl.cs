using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance;


    //Data Lists
    public int Level;
    public float MaxXp;
    public float CurrentXp;
    public float IncrementXp;


    public int Coin;
    public int Ruby;

    


    //SingleTon
    private void Awake()
    {

        
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
