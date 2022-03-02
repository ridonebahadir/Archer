using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject player;
    private Vector3 targetCurrent;
    private ArcherController archerController;
    //private Animator anim;
    public bool fire;
    public float shotAgainTime;

    private void Start()
    {
        //anim = transform.parent.GetChild(0).GetComponent<Animator>();
        archerController = transform.parent.GetComponent<ArcherController>();
    }
  
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag=="Player")
        {
            player = other.gameObject;
            fire = true;
            StartCoroutine(ArrowFire());
           
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            fire = false;
            StopCoroutine(ArrowFire());
           
        }
    }
    IEnumerator ArrowFire()
    {
        while (fire)
        {
           
            //anim.SetTrigger("Attack");
            archerController.TryToShoot(player.transform.position);
            yield return new WaitForSeconds(shotAgainTime);
            if (player.GetComponent<Player>().health <= 0)
            {
                fire = false;
                //anim.SetBool("Win",true);
            }
        }
       
    }
}
