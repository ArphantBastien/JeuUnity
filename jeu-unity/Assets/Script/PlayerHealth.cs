using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float invincibilityTimeAfterHit = 3f;
    public float invicinbilityFlashDelay = 0.1f;
    public bool isInvincible = false;

    public SpriteRenderer graphics;
    public BarredeVie healthbar;
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }
    public void TakeDamage(int damage)
    {
        if(!isInvincible)
        { 
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
   }
    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invicinbilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicinbilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
        {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}
