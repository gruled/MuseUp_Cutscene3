using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AustronautWaving : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWaving", true);
    }

}
