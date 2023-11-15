using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public float speed;
    public Rigidbody2D customerRB;

    public Animator animator;

    public bool isCounterEnter = false;

    void Awake()
    {
        customerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // Ȱ��ȭ�� �� �ʱ� �ӵ� ����
        customerRB.velocity = new Vector3(0, speed, 0);
        animator.SetBool("Walk", true);
    }

    private void Update()
    {
        if (customerRB.velocity.magnitude > 0.1f)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    // �մ� �̵� ����
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Counter")
        {
            customerRB.velocity = Vector2.zero;
            isCounterEnter = true;
            return;
        }
        else if (other.tag == "Customer")
        {
            customerRB.velocity = Vector2.zero;
        }
        else if (other.tag == "Exit")
        {
            animator.SetBool("Success", true);
            customerRB.velocity = Vector2.zero;
            Invoke("CustomerOut", 1.5f);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Customer" && !isCounterEnter)
        {
            Invoke("RestoreVelocity", 0.1f);
        }
    }

    // ���߱� �� ����� �ӵ� ����
    private void RestoreVelocity()
    {
        customerRB.velocity = new Vector3(0, speed, 0);
    }

    private void CustomerOut()
    {
        customerRB.velocity = new Vector3(speed, 0, 0);
        animator.SetBool("Success", false);
        Invoke("Exit", 2f);
    }

    private void Exit()
    {
        gameObject.SetActive(false);
    }
}
