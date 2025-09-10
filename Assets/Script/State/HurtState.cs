using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : NinjaState
{
    private NinjaSM _sm;
    private float _hurtDuration = 1f;  // Durasi waktu untuk state Hurt
    private float _nextHurtTime = 0f;

    public HurtState(NinjaSM stateMachine) : base("Hurt State", stateMachine)
    {
        _sm = stateMachine;  
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered HurtState");

        
        _sm.health -= 1;  // Mengurangi 1 dari health

        if (_sm.health <= 0)
        {
            _sm.health = 0;
            Debug.Log("Player is dead!");

            // call NotifyHealthChanged untuk memberi tahu GameManager tentang perubahan health
            _sm.NotifyHealthChanged();

            // Pindah ke DieState jika health mencapai 0
            _sm.ChangeState(_sm.dieState);  // Pindah ke DieState
            return;  
        }

        
        _sm.NotifyHealthChanged();

        Debug.Log("Current Health: " + _sm.health);

        // Atur animasi hurt
        if (_sm._animator != null)
        {
            _sm._animator.SetBool("isHurt", true);  // Aktifkan animasi hurt
        }

        // Mengatur cooldown agar kerusakan tidak berulang dengan cepat
        _nextHurtTime = Time.time + _hurtDuration;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        // Kembali ke IdleState setelah durasi selesai
        if (Time.time >= _nextHurtTime)
        {
            Debug.Log("Returning to IdleState...");
            _sm.ChangeState(_sm.idleState);  // Kembali ke IdleState setelah durasi hurt selesai

            // Matikan animasi hurt setelah selesai
            if (_sm._animator != null)
            {
                _sm._animator.SetBool("isHurt", false);  // Matikan animasi hurt
            }
        }

        // Kembali ke IdleState jika F ditekan lagi (sesuai permintaan)
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Returning to IdleState from HurtState...");
            _sm.ChangeState(_sm.idleState);  // Kembali ke IdleState jika tombol F ditekan lagi

            // Matikan animasi hurt saat kembali ke IdleState
            if (_sm._animator != null)
            {
                _sm._animator.SetBool("isHurt", false);  // Matikan animasi hurt
            }
        }
    }

    public override void UpdatePhysic()
    {
        base.UpdatePhysic();
    }
}