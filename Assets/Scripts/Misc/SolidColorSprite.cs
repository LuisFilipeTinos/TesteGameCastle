using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidColorSprite : MonoBehaviour
{
    private SpriteRenderer sr;
    private Shader material;
    [SerializeField] public Color color;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        material = Shader.Find("GUI/Text Shader");
    }

    private void ColorSprite()
    {
        sr.material.shader = material;
        sr.color = color;
    }

    public void Finish()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        ColorSprite();
    }
}
