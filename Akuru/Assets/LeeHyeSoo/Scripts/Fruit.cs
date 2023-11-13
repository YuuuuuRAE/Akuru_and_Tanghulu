using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Fruit : ScriptableObject
{
    public int fruitNum; //과일 번호
    public string fruitName; //과일 이름
    public Sprite fruitImage; //과일 이미지
    public Sprite tangfuruImage; //탕후루 이미지
    public Sprite tangfuruRcpImage; //탕후루 레시피 이미지
    public Sprite tangfuruRcpLvUpImage; //탕후루 레시피 레벨업 이미지
    public float making_time; //손질시간
    public int fruitAmount; //과일 갯수 / 수확한 과일이 이곳에 + 되도록 ((유래님 파트))
    public float fruitInPotTime; // 냄비 조리시간

    [Header("레시피 창: 과일 레벨업")]
    public int rcpLevel; //탕후루 레벨
    public int price; //= 해당 레시피 레벨 달성 시 판매소에서의 탕후루 판매 가격
    public int exp; //= 해당 레시피 레벨일 때 탕후루 제작시 경험치
    public int rqQuantity; //다음 레벨로 레벨업을 하기 위한 필요 제작 수량
    public int rqCoin; // 레벨업에 필요한 코인
    public int rqRuby; // 레벨업에 필요한 루비


}
