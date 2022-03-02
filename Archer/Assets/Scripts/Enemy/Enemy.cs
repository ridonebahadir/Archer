using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Enemy enemy;
    public GameObject model;
    public GameObject Bomb;
    private BoxCollider boxCollider;
    public EnemyFire enemyFire;
    public int health;
    public int takeDamage = 5;
    //private Animator anim;
    public Slider slider;
    public GameObject[] gift;
    public GameObject grave;
    private void Start()
    {
        enemy = this;
        //anim = transform.GetChild(0).GetComponent<Animator>();
        slider.maxValue = health;
        slider.value = health;
        boxCollider = GetComponent<BoxCollider>();
    }

   
    public void ArrowHit()
    {
        health -= takeDamage;
        slider.value = health;
        if (health <= 0)
        {
            Instantiate(Bomb, transform.position, Quaternion.identity);
            model.SetActive(false);
            enemyFire.StopAllCoroutines();
            enemyFire.fire = false;
            slider.gameObject.SetActive(false);
            enemyFire.enabled = false;
            //anim.SetBool("Die",true);
            enemy.enabled = false;
            boxCollider.enabled = false;
            int random = Random.Range(0, gift.Length);
            Instantiate(gift[random],transform.position+new Vector3(0,2,0),Quaternion.identity,transform.parent.parent);
            StartCoroutine(Grave());
        }
        else
        {
           
           
            //anim.SetTrigger("Damage");
        }
    }


    IEnumerator Grave()
    {
        yield return new WaitForSeconds(3);
       

        Instantiate(grave, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }
}
