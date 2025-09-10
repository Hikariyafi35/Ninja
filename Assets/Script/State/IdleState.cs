using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : NinjaState
{
    private NinjaSM _sm;
    private float _horizontalInput;
    public IdleState(NinjaSM stateMachine) : base("Idle State", stateMachine)
    {
        _sm = (NinjaSM)ninjaController;
    }
    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        // Transisi ke JumpState jika tombol lompat ditekan
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_sm.rb.velocity.y) < Mathf.Epsilon) 
        {
            ninjaController.ChangeState(_sm.jumpState); // Pindah ke JumpState saat lompat
        }
        //transtiton to run state if input != 0
        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
            ninjaController.ChangeState(((NinjaSM)ninjaController).runState);
        // Transisi ke AttackState saat tombol Fire2 ditekan
        if (Input.GetButtonDown("Fire2"))
        {
            ninjaController.ChangeState(_sm.attackState); // Pindah ke AttackState
        }
        if (Input.GetKeyDown(KeyCode.F))  // Menggunakan GetKeyDown untuk tombol F
        {
            ninjaController.ChangeState(_sm.hurtState); // Pindah ke HurtState
        }
    }
}
