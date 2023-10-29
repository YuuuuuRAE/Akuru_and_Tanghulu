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

    // �մ� ���� ���ķ� ���� �ν��Ͻ��� ���� �ۼ�
    // 0 ����, 1 û����, 2 ��, 3 ���ξ���, 4 ��纣��
    public int favorite;

    void Start()
    {
        customerRB = GetComponent<Rigidbody2D>();
        customerRB.velocity = new Vector3(0, speed, 0);
    }

    // �մ� �̵� ����
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

    // �մ� ��� ����
    public void pay()
    {
        GameManager.instance.favorite = favorite;
        GameManager.instance.PayCheck();
    }



    void Update()
    {

    }
}
