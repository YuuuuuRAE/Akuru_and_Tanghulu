using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public float speed;
    public Rigidbody2D customerRB;
    private Vector2 savedVelocity;
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    public Animator animator;

    bool isCounterEnter = false;

    void Awake()
    {
        customerRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        spriteRenderer.sprite = sprites[1];
    }

    private void OnEnable()
    {
        // 활성화될 때 초기 속도 설정
        customerRB.velocity = new Vector3(0, speed, 0);
    }

    // 손님 이동 관련
    public void OnTriggerEnter2D(Collider2D other)
    {
        spriteRenderer.sprite = sprites[0];

        if (other.tag == "Counter")
        {
            animator.SetBool("Walk", false);
            customerRB.velocity = Vector2.zero;
            savedVelocity = Vector2.zero;
            spriteRenderer.sprite = sprites[0];
            isCounterEnter = true;
            return;
        }
        else if (other.tag == "Customer")
        {
            animator.SetBool("Walk", false);
            customerRB.velocity = Vector2.zero;
        }
        else if (other.tag == "BlockLine1")
        {
            animator.SetBool("Walk", true);
            customerRB.velocity = new Vector2(speed, 0);
            savedVelocity = customerRB.velocity;
            //spriteRenderer.sprite = sprites[2];
            spriteRenderer.flipX = false;
        }
        else if (other.tag == "BlockLine2")
        {
            animator.SetBool("Walk", true);
            customerRB.velocity = new Vector2(-speed, 0);
            savedVelocity = customerRB.velocity;
            //spriteRenderer.sprite = sprites[2];
            spriteRenderer.flipX = true;
        }
        else if (other.tag == "Wall")
        {
            animator.SetBool("Walk", false);
            customerRB.velocity = new Vector2(0, (speed / 2));
            savedVelocity = customerRB.velocity;
            //spriteRenderer.sprite = sprites[1];
            spriteRenderer.flipX = false;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Customer" && !isCounterEnter)
        {
            Invoke("RestoreVelocity", 3f);
        }
    }

    // 멈추기 전 저장된 속도 복구
    private void RestoreVelocity()
    {
        customerRB.velocity = savedVelocity;
    }
}
