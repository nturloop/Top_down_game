using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private animationState animState;

    private Animator anim;
    private PlayerController PlyCtr;

    void Start() {
        anim = GetComponent<Animator>();
        PlyCtr = GameObject.Find("PlayerController").GetComponent<PlayerController>();
        
        //animState = animationState.Idle;
        

    }

    private void Update()
    {
        
        
    }

    void FixedUpdate()
    {
        ChangeState();
        ApplySate();

    }

    private void ApplySate()
    {
        switch(animState)
        {
            case animationState.Idle:
             
                AnimateToIdle();
                break;

            case animationState.Walking:
                AnimateToWalk();
                break;

            case animationState.Attacking:
                AnimateToAttack();
                break;
            case animationState.Dashing:
                AnimateToDash();
                break;

        }
    }

    private void ChangeState()
    {
        if (!PlyCtr.inAction)
        {
            if (PlyCtr.isMoving)
            {
                animState = animationState.Walking;
            }
            else
            {
                animState = animationState.Idle;
            }
        }
            if (PlyCtr.isAttacking)
            {
                animState = animationState.Attacking;
            }
            if (PlyCtr.isDashing)
            {
                animState = animationState.Dashing;
            }
        
    }

    private void AnimateToIdle()
    {
          
            anim.speed = 0.5f;
            anim.SetFloat("direction", (float)PlyCtr.PlyDirection);
            anim.Play("Idle");
             
        
    }

    private void AnimateToWalk()
    {
        
            anim.SetFloat("xInput", PlyCtr.Xinput());
            anim.SetFloat("yInput", PlyCtr.Yinput());
            anim.Play("walk");
            
        
    }

    private void AnimateToAttack()
    {
            anim.speed = 1.5f;
            anim.SetFloat("xMousePos", PlyCtr.MousePos2d.x);
            anim.SetFloat("yMousePos", PlyCtr.MousePos2d.y);
            anim.Play("Attack");
            
        
    }


    private void AnimateToDash()
    {
        anim.speed = 2f;
        anim.SetFloat("xMousePos", PlyCtr.MousePos2d.x);
        anim.SetFloat("yMousePos", PlyCtr.MousePos2d.y);
        anim.Play("Dash");


    }
}

public enum animationState
{
    Idle,Walking,Attacking,Jumping,Dashing
}