using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D customerRB;
    private Vector2 savedVelocity;
    public float payDelay;

    bool isCounterEnter = false;

    // 손님 각자 탕후루 취향 인스턴스로 각각 작성
    // 0 딸기, 1 청포도, 2 귤, 3 파인애플, 4 블루베리
    public int favorite;

    void Start()
    {
        customerRB = GetComponent<Rigidbody2D>();
        customerRB.velocity = new Vector3(0, speed, 0);
    }

    // 손님 이동 관련
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Counter")
        {
            customerRB.velocity = Vector2.zero;
            savedVelocity = Vector2.zero;
            isCounterEnter = true;
            payDelay = 5;
            pay();
            Destroy(gameObject, payDelay);
            return;
        }
        else if (other.tag == "Customer")
        {
            customerRB.velocity = Vector2.zero;
            Invoke("RestoreVelocity", 1.6f);
        }
        else if (other.tag == "BlockLine1")
        {
            customerRB.velocity = new Vector2(speed, 0);
            savedVelocity = customerRB.velocity;
        }
        else if (other.tag == "BlockLine2")
        {
            customerRB.velocity = new Vector2(-speed, 0);
            savedVelocity = customerRB.velocity;
        }
        else if (other.tag == "Wall")
        {
            customerRB.velocity = new Vector2(0, speed);
            savedVelocity = customerRB.velocity;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Customer" && !isCounterEnter)
        {
            Invoke("RestoreVelocity", 1.5f);
        }
    }

    private void RestoreVelocity()
    {
        customerRB.velocity = savedVelocity;
    }

    // 손님 계산 관련
    public void pay()
    {
        GameManager.instance.favorite = favorite;
        GameManager.instance.PayCheck();
    }



    void Update()
    {

    }
}
