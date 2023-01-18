using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTakeDamage : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    public bool isInvincible;

    [SerializeField] Animator anim;

    public float knockBackForce;
    public float knockBackCounter;
    public float knockBackTotalTime;
    public bool knockFromRight;

    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] GameObject bloodBurst;
    [SerializeField] GameObject player;

    void Start()
    {
        isInvincible = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isInvincible)
            StartCoroutine(TakeDamage(collision));
    }

    IEnumerator TakeDamage(Collider2D collision)
    {
        if (collision.transform.position.x <= this.transform.position.x)
            knockFromRight = false;
        else
            knockFromRight = true;

        if (collision.gameObject.name.StartsWith("SpikeBall"))
            playerHealth.health = 0;
        else
            playerHealth.health--;
        anim.Play("DamageAnim");
        knockBackCounter = 0.2f;

        if (playerHealth.health == 0)
        {
            Instantiate(bloodBurst, this.transform.position, Quaternion.identity);
            player.SetActive(false);
        }
            
        isInvincible = true;
        sr.color = Color.red;
        yield return new WaitForSeconds(0.07f);
        sr.color = Color.white;
        yield return new WaitForSeconds(0.07f);
        sr.color = Color.red;
        yield return new WaitForSeconds(0.07f);
        sr.color = Color.white;
        yield return new WaitForSeconds(0.07f);
        sr.color = Color.red;
        yield return new WaitForSeconds(0.07f);
        sr.color = Color.white;
        yield return new WaitForSeconds(0.07f);
        sr.color = Color.red;
        yield return new WaitForSeconds(0.07f);
        sr.color = Color.white;
        yield return new WaitForSeconds(0.07f);
        sr.color = Color.red;
        yield return new WaitForSeconds(0.07f);
        sr.color = Color.white;
        yield return new WaitForSeconds(0.07f);
        sr.color = Color.red;
        yield return new WaitForSeconds(0.07f);
        sr.color = Color.white;
        yield return new WaitForSeconds(0.07f);
        sr.color = Color.red;
        yield return new WaitForSeconds(0.07f);
        sr.color = Color.white;
        yield return new WaitForSeconds(0.07f);
        sr.color = Color.red;
        yield return new WaitForSeconds(0.07f);
        sr.color = Color.white;
        yield return new WaitForSeconds(0.07f);
        sr.color = Color.red;
        yield return new WaitForSeconds(0.07f);
        sr.color = Color.white;
        yield return new WaitForSeconds(0.07f);
        sr.color = Color.red;
        yield return new WaitForSeconds(0.07f);
        sr.color = Color.white;
        isInvincible = false;
    }
}
