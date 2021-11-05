using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;
public class Ship : MonoBehaviour
{
    Rigidbody2D myBody;
    private float mySpeedX;
    [SerializeField] float speed;
    public float hiz;

    [SerializeField] float MaxX, MinY;

   


    [SerializeField] Light2D lights;
    float lightValue = 1f;


    int healt = 3;

    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        myBody.velocity = new Vector2(0, hiz * Time.deltaTime);

        lights = GameObject.FindGameObjectWithTag("MainLight").GetComponent<Light2D>();

    }

    
    void Update()
    {

        ShipHaraket();//Geminin hareketi
        Light();//Işık zamanla gücünün azalması
        //Geminin kamera dışına taşmaması
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinY, MaxX), transform.position.y, transform.position.z);


    }


    public void Light()
    {

        lights.pointLightOuterRadius -= 0.1f * Time.deltaTime;

        if(lights.pointLightOuterAngle == 0)
        {
            lights.pointLightOuterRadius = 0;
        }

      
        if(healt == 0)
        {
            SceneManager.LoadScene(0);
        }

    }

    public void ShipHaraket()//Geminin sağsol hareketi
    {
        //Klavye ile hareket
        mySpeedX = Input.GetAxis("Horizontal");

        myBody.velocity = new Vector2(mySpeedX * speed, myBody.velocity.y);



        if (Input.anyKey)//Fare ile hareket
        {

            if (Input.mousePosition.x < Screen.width / 2 || transform.position.x > 5.8f)
            {

                transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);

            }


            if (Input.mousePosition.x > Screen.width / 2 || transform.position.x < -5.8f)
            {

                transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);

            }




        }



        if (Input.touchCount > 0)//Dokunmatik ekran ile hareket
        {
            var touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2 || transform.position.x > 5.8f)
            {
                transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
            }
            else if (touch.position.x > Screen.width / 2 || transform.position.x > -5.8f)
            {
                transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
            }
        }





    }




    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Battery"))//Işığın gücü
        {
            lights.pointLightOuterRadius += lightValue;
           

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Asteroid"))
        {
            
            healt--;
            Debug.Log(healt);
        }
            
        


    }

    

    //void respownAst()
    //{
    //    int i = Random.Range(0, 4);

    //    GameObject ast = asteroid[i];

    //    screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

    //    ast.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y);

    //    Instantiate(ast , ast.transform.position , Quaternion.identity);


    //}


}
