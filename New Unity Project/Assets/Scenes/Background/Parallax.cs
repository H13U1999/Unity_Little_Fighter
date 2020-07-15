using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax: MonoBehaviour
{
    public float length, startpost;
    public GameObject Cam;
    public float ParallaxEffect;
    void Start()
    {
        startpost = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = (Cam.transform.position.x * ParallaxEffect);
        float temp = (Cam.transform.position.x * (1-ParallaxEffect));
        transform.position = new Vector3(startpost + dist, transform.position.y, transform.position.z);
        if (temp > startpost + length) startpost += length;
        else if (temp < startpost - length) startpost -= length;
    }
}
