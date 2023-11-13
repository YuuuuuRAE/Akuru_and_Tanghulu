using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cashier : MonoBehaviour
{
    Animator animator;
    public GameObject progressBar;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (progressBar.activeSelf)
        {
            animator.SetBool("Sell", true);
        }
        else
        {
            animator.SetBool("Sell", false);
        }
    }
}
