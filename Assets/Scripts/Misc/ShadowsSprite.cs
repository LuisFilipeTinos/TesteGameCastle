using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowsSprite : MonoBehaviour
{
    public static ShadowsSprite me;
    public GameObject shadow;
    public List<GameObject> pool = new List<GameObject>();
    private float timer;
    public float speed;
    public Color color;
    PlayerController playerController;

    private void Awake()
    {
        me = this;
        playerController = GetComponent<PlayerController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetShadows()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                pool[i].transform.position = transform.position;
                pool[i].transform.rotation = transform.rotation;
                pool[i].GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
                pool[i].GetComponent<SolidColorSprite>().color = color;
                pool[i].transform.localScale = transform.localScale;
                return pool[i];
            }
        }
        GameObject obj = Instantiate(shadow, transform.position, transform.rotation) as GameObject;
        obj.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
        obj.GetComponent<SolidColorSprite>().color = color;
        obj.transform.localScale = transform.localScale;
        pool.Add(obj);
        return obj;
    }

    public void ShadowsSkill()
    {
        timer += speed * Time.deltaTime;
        if (timer > 1)
        {
            GetShadows();
            timer = 0;
        }
            
    }
}
