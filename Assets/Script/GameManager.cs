using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;  // Referensi ke TextMeshPro untuk menampilkan kesehatan
    private NinjaSM playerSM;  // Referensi ke NinjaSM (di mana health dikelola)

    void Start()
    {
        // Cari objek dengan tag "Player" dan dapatkan komponen NinjaSM
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerSM = player.GetComponent<NinjaSM>();
            if (playerSM != null)
            {
                playerSM.OnHealthChanged += UpdateHealthDisplay;  // Berlangganan event perubahan kesehatan
            }
        }
    }

    // Fungsi untuk mengupdate tampilan kesehatan
    void UpdateHealthDisplay(int health)
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health.ToString();  // Menampilkan kesehatan di TextMeshPro
        }
    }

    void Update()
    {
        // Debugging untuk melihat kesehatan secara langsung
        if (playerSM != null)
        {
            Debug.Log("Current Health: " + playerSM.health);
        }
    }
}
