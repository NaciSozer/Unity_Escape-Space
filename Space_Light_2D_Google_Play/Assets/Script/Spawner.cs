using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] asteroids;
    public GameObject[] stillAsteroids;
    public GameObject battery;


    float rastXPosition;
    
    void Start()
    {
        InvokeRepeating(nameof(AstroidsSpawner), 1f,2f);

        //InvokeRepeating(nameof(StillAstreoid), 2f, 5f);

        InvokeRepeating(nameof(BaterySpawner), 2f, 12f);

        
        
    }

    
    void Update()
    {
        rastXPosition = Random.Range(-1.93f, 1.95f);
        
    }

    void AstroidsSpawner()
    {
        int rastAstroid = Random.Range(0,3);
        

        Instantiate(asteroids[rastAstroid], new Vector3(rastXPosition, transform.position.y + 15f, transform.position.z), Quaternion.identity);

        

    }

    void StillAstreoid()
    {
        int rastStillAstroid = Random.Range(0, 2);
         

        Instantiate(stillAsteroids[rastStillAstroid], new Vector3(rastXPosition, transform.position.y + 15f, transform.position.z), Quaternion.identity);
    }

    void BaterySpawner()
    {
        Instantiate(battery, new Vector3(rastXPosition, transform.position.y + 12f, transform.position.z), Quaternion.identity);



    }

}
