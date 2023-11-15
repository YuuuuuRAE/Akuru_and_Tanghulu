using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passing : MonoBehaviour
{
    public float speed;
    public Rigidbody2D passingRB;
    public GameObject target;
    public int index;

    private SpriteRenderer spriteRenderer;

    Animator animator;

    private void Start()
    {
        if (index == -1)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    void OnEnable()
    {
        passingRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        animator.SetBool("Walk", true);

        PassingInstate(index);
    }

    public void PassingInstate(int i)
    {
        passingRB.velocity = new Vector3(i * speed, 0, 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌한 오브젝트가 target인 경우 비활성화
        if (collision.gameObject == target)
        {
            gameObject.SetActive(false);
        }
    }
}
