using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    public float speed = 1;
    public Transform target;
    void Awake()
    {
        target = transform.parent.GetComponent<Spawn>().player.transform;
        //target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position+new Vector3(0,2,0), step);
    }
}
