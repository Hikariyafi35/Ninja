using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RunState : NinjaState
{
    private NinjaSM _sm;
    private float _horizontalInput;

    public RunState(NinjaSM stateMachine) : base("Run State", stateMachine)
    {
        _sm = (NinjaSM)ninjaController;
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
        
        // Set animasi run
        _sm.SetRunAnimation(true);  
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        _horizontalInput = Input.GetAxis("Horizontal");

        // Transisi ke IdleState jika input horizontal 0
        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
        {
            ninjaController.ChangeState(_sm.idleState); // Pindah ke IdleState jika tidak ada pergerakan
        }

        // Transisi ke JumpState jika tombol lompat ditekan
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_sm.rb.velocity.y) < Mathf.Epsilon) 
        {
            ninjaController.ChangeState(_sm.jumpState); // Pindah ke JumpState saat lompat
        }

        // Transisi ke AttackState saat tombol Fire2 ditekan
        if (Input.GetButtonDown("Fire2"))
        {
            ninjaController.ChangeState(_sm.attackState); // Pindah ke AttackState
        }
    }

    public override void UpdatePhysic()
    {
        base.UpdatePhysic();

        // Menentukan kecepatan pergerakan horizontal
        Vector2 vel = _sm.rb.velocity;
        vel.x = _horizontalInput * _sm.speed * 10 * Time.fixedDeltaTime;
        _sm.rb.velocity = vel;

        // Mengatur rotasi otomatis berdasarkan arah pergerakan
        if (_horizontalInput > 0)  // Karakter bergerak ke kanan
        {
            _sm.transform.localRotation = Quaternion.Euler(0, 0, 0);  // Rotasi menghadap kanan
        }
        else if (_horizontalInput < 0)  // Karakter bergerak ke kiri
        {
            _sm.transform.localRotation = Quaternion.Euler(0, 180, 0);  // Rotasi menghadap kiri
        }
    }

    public override void Exit()
    {
        base.Exit();

        _sm.SetRunAnimation(false);  
    }
}
