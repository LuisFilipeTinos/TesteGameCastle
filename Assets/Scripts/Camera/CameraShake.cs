using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float intensity;
    public float speed;

    float seedX;
    float seedY;
    float seedZ;

    public float maxAngleZ = 1f;
    public float maxOffsetX = 1f;
    public float maxOffsetY = 1f;

    float rotationZ;
    float offsetX;
    float offsetY;

    Vector3 originalPos;

    private void Start()
    {
        speed = 5f;

        seedX = Random.Range(-1000, 1000);
        seedY = Random.Range(-1000, 1000);
        seedZ = Random.Range(-1000, 1000);
    }
    public void Update()
    {
        var time = Time.time * speed;
        rotationZ = intensity * maxAngleZ * PerlinNoise(seedZ, time);

        offsetX = intensity * maxOffsetX * PerlinNoise(seedX, time);
        offsetY = intensity * maxOffsetY * PerlinNoise(seedY, time);

        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        transform.position = originalPos + new Vector3(offsetX, offsetY);
    }

    float PerlinNoise(float seed, float time)
    {
        return (1 - 2 * Mathf.PerlinNoise(seed + time, seed + time));
    }
}
