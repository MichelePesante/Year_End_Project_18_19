﻿using UnityEngine;

public class PlayerAnimatorProxy : MonoBehaviour
{
    [SerializeField] Animator animator;

    [Header("Events")]
    [SerializeField] UnityVoidEvent OnDeathAnimEnd;

    [HideInInspector] public bool IsDead = false;

    bool _isGrounded;
    public bool IsGrounded
    {
        get { return _isGrounded; }
        set
        {
            if (value != _isGrounded)
            {
                _isGrounded = value;
                animator.SetBool("isGrounded", _isGrounded);
            }
        }
    }

    bool _isDashing;
    public bool IsDashing
    {
        get { return _isDashing; }
        set
        {
            if (value != _isDashing)
            {
                _isDashing = value;
                animator.SetBool("isDashing", _isDashing);
            }
        }
    }

    bool _isRising;
    public bool IsRising
    {
        get { return _isRising; }
        set
        {
            if (value != _isRising)
            {
                _isRising = value;
                animator.SetBool("isRising", _isRising);
            }
        }
    }

    bool _isWalking;
    public bool IsWalking
    {
        get { return _isWalking; }
        set
        {
            if(value != _isWalking)
            {
                _isWalking = value;
                animator.SetBool("isWalking", _isWalking);
            }
        }
    }

    bool _chargeing;
    public bool Chargeing
    {
        get { return _chargeing; }
        set
        {
            if (value != _chargeing)
            {
                _chargeing = value;
                animator.SetBool("Chargeing", _chargeing);
            }
        }
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void UpAttack()
    {
        animator.SetTrigger("Up Attack");
    }

    public void Damaged()
    {
        animator.SetTrigger("Damaged");
    }

    public void Death()
    {
        animator.SetTrigger("Death");
        IsDead = true;
    }

    public void DeathAnimEnd()
    {
        OnDeathAnimEnd.Invoke();
    }

    public void ChargeAttack()
    {
        animator.SetTrigger("Charge Attack");
    }

}