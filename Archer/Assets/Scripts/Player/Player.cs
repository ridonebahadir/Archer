using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public TimeManager timeManager;
    private Player player;
    public GameObject popUp;
    public GameManager gameManager;
    private Animator anim;
    public Transform target;
   
    public Camera mainCamera;
    public GameObject arrow;
    public GameObject line;
    private ArcherController archerController;
    public Slider slider;
    public float runSpeed;
    public int health;
    public int takeDamage = 10;
    bool isDie;
    bool stop;
    private void Start()
    {
        slider.maxValue = health;
        slider.value = health;
         player = this;
       
        anim = transform.GetChild(0).GetComponent<Animator>();
        archerController = GetComponent<ArcherController>();
    }
    bool rotation;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotation)
        {
            var lookPos = target.transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 100f);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 20f);
            transform.position = new Vector3(0, 0, transform.position.z);
        }

        if (!isDie)
        {

            if (Input.GetMouseButton(0))
            {
                anim.SetBool("Attack", true);
                anim.SetBool("walkOrStop", true);
                rotation = true;
                //timeManager.DoSlowmotion();
                arrow.SetActive(true);

            }
            else
            {
                rotation = false;
              
                anim.SetBool("Attack", false);
                anim.SetBool("walkOrStop", false);
                Invoke("Move",0.3f);
                arrow.SetActive(false);


            }
           
        }
       


       



    }
    private void Move()
    {
        if (stop)
        {
            Invoke("StopTrue",0.5f);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * runSpeed);
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, transform.position.z - 10);
        }
       

    }
    void StopTrue() { stop = false; }
    public void ArrowHit()
    {
        health -= takeDamage;
        slider.value = health;
        if (health <= 0)
        {
            //boxCollider.enabled = false;
            Died();
        }
        else
        {
            stop = true;
            PopUp("-10 Health", Color.red);
            anim.SetTrigger("Damage");
           
        }
       


      
    }
    public void HealthHit()
    {
        health += 10;
      
        if (health>slider.maxValue)
        {
            health =(int)slider.maxValue;
        }

        slider.value = health;
    }

    public void ToplaHit()
    {
        gameManager.score += 10;
        gameManager.scoreText.text = "Score = " + gameManager.score.ToString();
    }
    private void Died()
    {
        isDie = true;
        anim.Play("Die");
        line.SetActive(false);
        archerController.enabled = false;
        gameManager.Finish();
        player.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Health")
        {
            HealthHit();
            PopUp("+10 Health",Color.blue);
            Destroy(other.gameObject);
        }
        if (other.tag=="Topla")
        {
            ToplaHit();
            PopUp("+10 Score",Color.green);

           Destroy(other.gameObject);
        }
       
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            Died();
            slider.value = 0;
            health = 0;
            collision.gameObject.GetComponent<Bomb>().Explosion();
           
        }
    }
    void PopUp(string text,Color color)
    {
       GameObject clone= Instantiate(popUp, transform.position + new Vector3(0, 3, 0), Quaternion.identity, transform);
        clone.GetComponent<TextMesh>().text =   text;
        clone.GetComponent<TextMesh>().color = color;
    }
   

}
