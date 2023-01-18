using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    [SerializeField] float shakeSpeed = 5.0f;
    [SerializeField] float shakeAmount = 1.0f;
    [SerializeField] public bool isShaking;
    [SerializeField] public bool finishedAppearing;

    [SerializeField] GameObject bloodBurst;
    [SerializeField] float enemyLife;
    Rigidbody2D rb2d;

    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        finishedAppearing = false;
    }

    public void Update()
    {
        if (isShaking)
            this.transform.position = new Vector2(this.transform.position.x + Mathf.Sin(Time.time * shakeSpeed) * shakeAmount * 0.2f, this.transform.position.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Whip") && finishedAppearing)
        {
            Instantiate(bloodBurst, this.transform.position, Quaternion.identity);
            if (enemyLife > 0)
            {
                enemyLife--;
                rb2d.velocity = Vector2.zero;
                isShaking = true;
                StartCoroutine(TakeDamage());
            }
            else
            {
                Destroy(this.gameObject);
            }
            
        }
    }

    private IEnumerator TakeDamage()
    {
        var currentPosition = this.transform.position;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.07f);
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.07f);
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.07f);
        spriteRenderer.color = Color.white;
        this.transform.position = currentPosition;
        isShaking = false;
    }
}
