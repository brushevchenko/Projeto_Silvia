using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject bala;
    public float speed = 100;
    public int health=5;
    
   
    public Rigidbody2D rb;
    public Transform limX;
    public Transform limY;
   


     

    public void Update()
    {
        float h = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown("left") || Input.GetKeyDown("a") )
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + tempVect);

        //Restringir o movimento entre dois valores
        if (transform.position.x <= -21.5f || transform.position.x >= limX.position.x)
        {
            // Criando o limite
            float xPos = Mathf.Clamp(transform.position.x, -21.5f, limX.position.x);
            // Limitando
            transform.position = new Vector3(xPos, transform.position.y,
            transform.position.z);
        }

        if (transform.position.y <= -7.4f || transform.position.y >= limY.position.y)
        {
            // Criando o limite
            float yPos = Mathf.Clamp(transform.position.y, -7.4f, limY.position.y);
            // Limitando
            transform.position = new Vector3(transform.position.x, yPos,
            transform.position.z);
        }

        if (Input.GetKeyDown("space"))
        {
            // Cria uma nova bala na posiçao atual da nave para que siga a nave
            Instantiate(bala, transform.position, Quaternion.identity);
        }

        

    }

    

}

           
    

    

