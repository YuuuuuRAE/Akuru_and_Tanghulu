using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public float speed;
    public Rigidbody2D customerRB;
    private Vector2 savedVelocity;

    bool isCounterEnter = false;

    void Awake()
    {
        customerRB = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        // Ȱ��ȭ�� �� �ʱ� �ӵ� ����
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
            return;
        }
        else if (other.tag == "Customer")
        {
            customerRB.velocity = Vector2.zero;
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
            customerRB.velocity = new Vector2(0, (speed / 2));
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

    // ���߱� �� ����� �ӵ� ����
    private void RestoreVelocity()
    {
        customerRB.velocity = savedVelocity;
    }
}
