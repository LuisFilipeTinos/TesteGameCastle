using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroll : MonoBehaviour
{
    private bool isFacingLeft;
    Rigidbody2D rb2d;
    SpriteRenderer sr;
    private float moveSpeed = 200f;
    [SerializeField] EnemyTakeDamage damageScript;

    [SerializeField] Transform castPos;
    [SerializeField] float baseCastDist;

    [SerializeField] float shakeSpeed = 5.0f;
    [SerializeField] float shakeAmount = 1.0f;

    [SerializeField] BoxCollider2D collider;
    [SerializeField] BoxCollider2D trigger;

    [SerializeField] ParticleSystem groundParticles;
    bool appeared;

    private void Start()
    {
        isFacingLeft = true;
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        collider.enabled = false;
        groundParticles.Pause();
        rb2d.gravityScale = 0;
        appeared = false;
    }

    private void FixedUpdate()
    {
        if (!damageScript.isShaking && appeared)
        {
            if (isHittingWallOrCloseEdge(true) || isHittingWallOrCloseEdge(false))
                ChangeDirection();

            if (isFacingLeft)
                rb2d.velocity = new Vector2(-moveSpeed * Time.deltaTime, this.transform.position.y);
            else
                rb2d.velocity = new Vector2(moveSpeed * Time.deltaTime, this.transform.position.y);
        }
        else if (!appeared)
            this.transform.position = new Vector2(this.transform.position.x + Mathf.Sin(Time.time * 20.0f) * 0.01f, this.transform.position.y);
    }

    private void ChangeDirection()
    {
        if (isFacingLeft)
        {
            this.transform.localScale = new Vector3(-5, 5, 5);
            isFacingLeft = false;
        }
        else
        {
            this.transform.localScale = new Vector3(5, 5, 5);
            isFacingLeft = true;
        }
    }

    bool isHittingWallOrCloseEdge(bool wall = true)
    {
        bool val;
        float castDist = baseCastDist;

        Vector3 targetPos = castPos.position;

        if (wall)
        {
            val = false;
            targetPos.x += castDist;

            Debug.DrawLine(castPos.position, targetPos, Color.blue);

            if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground")))
                val = true;
        }
        else
        {
            val = true;
            targetPos.y -= castDist;

            Debug.DrawLine(castPos.position, targetPos, Color.red);

            if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground")))
                val = false;
        }


        return val;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAppear") && !appeared)
            StartCoroutine(EnemyAppear());
    }

    private IEnumerator EnemyAppear()
    {
        trigger.enabled = false;
        groundParticles.Play();
        rb2d.velocity = new Vector2(rb2d.velocity.x, 1);
        yield return new WaitForSeconds(1.5f);
        rb2d.velocity = Vector2.zero;
        groundParticles.Stop();
        collider.enabled = true;
        rb2d.gravityScale = 1;
        appeared = true;
        damageScript.finishedAppearing = true;
    }
}
