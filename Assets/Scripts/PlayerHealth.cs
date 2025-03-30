using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private static int currentHealth;
    public TextMeshProUGUI healthText;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthUI()
    {
        healthText.text = "" + currentHealth;
    }

    void Die()
    {
        SceneManager.LoadScene("Loose");
        Debug.Log("El jugador ha muerto");
        
    }

    public void Heal(int Heal)
    {
        currentHealth += Heal;
    }

    void Update ()
    {
        UpdateHealthUI ();
    }
}

