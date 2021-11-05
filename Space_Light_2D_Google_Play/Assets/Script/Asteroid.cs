using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    float ran;

   
    void Start()
    {
        ran = Random.Range(-2,2);

    }


    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, ran));
    }


    private void OnBecameInvisible()//Asteroid ekrandan çıktığında yok olması işlemi
    {
        Destroy(gameObject);
    }



}
