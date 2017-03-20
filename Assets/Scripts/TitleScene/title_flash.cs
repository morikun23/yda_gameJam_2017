
using UnityEngine;
using System.Collections;

public class title_flash : MonoBehaviour
{
    private float nextTime;
    public float interval = 1f;   // 点滅周期

    SpriteRenderer sp;



    // Use this for initialization

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        nextTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTime)
        {
            sp.enabled = !sp.enabled;
            nextTime += interval;
        }
    }
}