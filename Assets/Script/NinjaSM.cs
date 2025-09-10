using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaSM : NinjaController
{
    [HideInInspector]
    public IdleState idleState;
    [HideInInspector]
    public RunState runState;
    [HideInInspector]
    public JumpState jumpState;
    [HideInInspector]
    public AttackState attackState;
    [HideInInspector]
    public HurtState hurtState;
    [HideInInspector]
    public DieState dieState;

    public Rigidbody2D rb;
    public float speed = 2f;
    public float jumpForce = 10f;

    public GameObject projectilePrefabs;
    public Transform firePoint;
    public int health = 10;

    public delegate void HealthChanged(int health);
    public event HealthChanged OnHealthChanged;

    public Animator _animator;  

    private void Awake()
    {
        idleState = new IdleState(this);
        runState = new RunState(this);
        jumpState = new JumpState(this);
        attackState = new AttackState(this);
        hurtState = new HurtState(this);
        dieState = new DieState(this);

        _animator = GetComponent<Animator>(); 
    }

    protected override NinjaState GetInitialState()
    {
        return idleState;
    }

    // call event OnHealthChanged
    public void NotifyHealthChanged()
    {
        
        OnHealthChanged?.Invoke(health);
    }

    //run animation played
    public void SetRunAnimation(bool isRunning)
    {
        if (_animator != null)
        {
            _animator.SetBool("isRunning", isRunning);  
        }
    }
}
