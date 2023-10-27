using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Fruit : ScriptableObject
{

    public string fruitName; //과일 이름
    public Sprite fruitImage; //과일 이미지
    public float making_time; //손질시간
    public int fruitAmount; //과일 갯수
    public float fruitInPot; // 냄비 조리시간

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
