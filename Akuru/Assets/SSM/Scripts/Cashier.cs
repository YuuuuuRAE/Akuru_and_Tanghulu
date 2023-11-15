using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cashier : MonoBehaviour
{
    Animator animator;
    public GameObject progressBar;
    public GameObject saleTanghulu;
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    public int tanghuluIndex;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = saleTanghulu.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (progressBar.activeSelf)
        {
            animator.SetBool("Sell", true);
            saleTanghulu.SetActive(true);
            spriteRenderer.sprite = sprites[tanghuluIndex];
        }
        else
        {
            animator.SetBool("Sell", false);
            saleTanghulu.SetActive(false);
        }
    }
}
