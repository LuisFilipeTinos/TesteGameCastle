using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    private bool chaseplayer;
    CircleCollider2D collider;

    [SerializeField] int walkPointSet;
    public EnemyTakeDamage damageScript;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        chaseplayer = false;
        collider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (chaseplayer)
            ChasePlayer();        
    }

    public void ChasePlayer()
    {
        agent.SetDestination(new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAppear"))
        {
            chaseplayer = true;
            collider.radius = 0.5f;
            damageScript.finishedAppearing = true;
            collider.isTrigger = false;
        }
            
    }
}
