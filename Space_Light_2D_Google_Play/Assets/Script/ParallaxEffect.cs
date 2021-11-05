using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float length, startpos, ima;
    public GameObject cam;
    public float paralleaxEffect;

    public Canvas canim;


    void Start()
    {
        startpos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;





    }


    private void FixedUpdate()
    {

        float temp = (cam.transform.position.y * (1 - paralleaxEffect));
        float dist = (cam.transform.position.y * paralleaxEffect);

        transform.position = new Vector3(transform.position.x, startpos + dist, transform.position.z);


        if (temp > startpos + length)
        {

            startpos += length;

        }

        else if (temp < startpos - length)
        {

            startpos = length;

        }
    }

}