using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    float velocityOfTransition;

    [SerializeField]
    Vector2 posOffset;

    [SerializeField]
    public float leftLimit;

    [SerializeField]
    public float rightLimit;

    [SerializeField]
    public float upLimit;

    [SerializeField]
    public float botomLimit;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = player.transform.position;

        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        transform.position = Vector3.Lerp(startPos, endPos, velocityOfTransition * Time.deltaTime);

        transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
                Mathf.Clamp(transform.position.y, botomLimit, upLimit),
                transform.position.z
            );

    }
}
