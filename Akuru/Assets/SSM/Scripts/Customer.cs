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
        // 활성화될 때 초기 속도 설정
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

    // 손님 이동 관련
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

    // 멈추기 전 저장된 속도 복구
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
