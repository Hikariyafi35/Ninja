using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : NinjaState
{
    private NinjaSM _sm;
    private float _attackCooldown = 0.5f; // Waktu cooldown antar serangan
    private float _nextAttackTime = 0f;

    public AttackState(NinjaSM stateMachine) : base("Attack State", stateMachine)
    {
        _sm = stateMachine;  // Dapatkan NinjaSM dari parameter
    }

    public override void Enter()
    {
        base.Enter();
        // Pada saat memasuki AttackState, pastikan untuk mencegah serangan berturut-turut tanpa cooldown
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        // Periksa apakah Fire1 ditekan dan apakah cooldown sudah habis
        if (Input.GetButtonDown("Fire1") && Time.time >= _nextAttackTime)
        {
            Debug.Log("Attack triggered!");
            if (_sm._animator != null)
            {
                _sm._animator.SetBool("isAttacking", true);  // Aktifkan animasi attack
            }
            Attack();
            _nextAttackTime = Time.time + _attackCooldown;
        }

        // Transisi ke IdleState setelah tombol dilepas
        if (!Input.GetButton("Fire2"))
        {
            Debug.Log("Returning to Idle state...");
            _sm.ChangeState(_sm.idleState);  // Kembali ke IdleState
        }
    }

    public override void UpdatePhysic()
    {
        base.UpdatePhysic();
    }

    private void Attack()
    {
        // Periksa apakah prefab proyektil dan firePoint sudah diatur
        if (_sm.projectilePrefabs != null && _sm.firePoint != null)
        {
            // Instansiasi proyektil pada posisi firePoint dan dengan rotasi firePoint
            GameObject projectile = Object.Instantiate(_sm.projectilePrefabs, _sm.firePoint.position, _sm.firePoint.rotation);

            // Debug log untuk memverifikasi proyektil diinstansiasi
            Debug.Log($"Projectile instantiated at {_sm.firePoint.position}");

            // Dapatkan Rigidbody2D dari proyektil
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // Tentukan arah proyektil (misalnya ke kanan jika firePoint menghadap ke kanan)
                Vector2 direction = _sm.firePoint.right;  // Menggunakan arah kanan dari firePoint (pastikan firePoint memiliki rotasi yang benar)
                rb.velocity = direction * 10f;  

                // Debug log untuk memastikan kecepatan proyektil
                Debug.Log($"Projectile velocity: {rb.velocity}");
            }
            else
            {
                Debug.LogError("Projectile does not have a Rigidbody2D component!");
            }
        }
        else
        {
            Debug.LogError("Projectile prefab or firePoint is missing!");
        }
    }
    public override void Exit()
    {
        base.Exit();

        if (_sm._animator != null)
        {
            _sm._animator.SetBool("isAttacking", false);  
        }
    }
}