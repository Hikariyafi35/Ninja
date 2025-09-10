using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : NinjaState
{
    private NinjaSM _sm;

    public DieState(NinjaSM stateMachine) : base("Die State", stateMachine)
    {
        _sm = stateMachine;  // Dapatkan NinjaSM dari parameter
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Player is dead!");

        
        _sm.rb.velocity = Vector2.zero;  // Hentikan pergerakan
        _sm.speed = 0f;  // Hentikan pergerakan lebih lanjut
        if (_sm._animator != null)
        {
            _sm._animator.SetBool("isDead", true);  
        }
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysic()
    {
        base.UpdatePhysic();
    }
}
