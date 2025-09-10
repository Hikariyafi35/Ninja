using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : NinjaState
{
    private NinjaSM _sm;
    private bool _isJumping;
    private bool _isFalling;

    public JumpState(NinjaSM stateMachine) : base("Jump State", stateMachine)
    {
        _sm = (NinjaSM)ninjaController;
    }

    public override void Enter()
    {
        base.Enter();
        _isJumping = true;
        _isFalling = false;

        // Atur animasi lompat
        if (_sm._animator != null)
        {
            _sm._animator.SetBool("isJumping", true);  // Set parameter isJumping di Animator
            _sm._animator.SetBool("isFalling", false); // Pastikan animasi jatuh tidak aktif
        }

        // Berikan gaya vertikal untuk lompat
        _sm.rb.velocity = new Vector2(_sm.rb.velocity.x, _sm.jumpForce);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        // Cek jika karakter sedang jatuh
        if (_sm.rb.velocity.y < 0 && !_isFalling) // Jika mulai jatuh
        {
            _isJumping = false;
            _isFalling = true;

            // Atur animasi jatuh
            if (_sm._animator != null)
            {
                _sm._animator.SetBool("isJumping", false);  // Matikan animasi lompat
                _sm._animator.SetBool("isFalling", true);   // Aktifkan animasi jatuh
            }
        }

        // Kembali ke IdleState jika menyentuh tanah
        if (_sm.rb.velocity.y == 0 && (_isJumping || _isFalling)) // Ketika karakter menyentuh tanah
        {
            ninjaController.ChangeState(_sm.idleState); // Pindah ke IdleState
            _isJumping = false;
            _isFalling = false;

            // Reset animasi setelah mendarat
            if (_sm._animator != null)
            {
                _sm._animator.SetBool("isJumping", false);  // Matikan animasi lompat
                _sm._animator.SetBool("isFalling", false);  // Matikan animasi jatuh
            }
        }
    }

    public override void UpdatePhysic()
    {
        base.UpdatePhysic();
        // Tidak ada perubahan fisika khusus saat dalam lompat
    }
}
