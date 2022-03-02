using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryShooting : MonoBehaviour
{
   
    private Vector3 mousePressDownPos;
   
    [SerializeField] Rigidbody rb;
   
    public float maxHeight = 2;
    public GameObject target;
    public GameObject archer;

    void Update()   
    {

        if (Input.GetMouseButtonDown(0))
        {

            mousePressDownPos = Input.mousePosition;

          


        }
        if (Input.GetMouseButton(0))
        {
            
            Vector3 forceInit = mousePressDownPos-Input.mousePosition;
            
           
            Vector3 forceV = (new Vector3(forceInit.x, forceInit.y*2, forceInit.y*5));
           

           
           
            DrawTrajectory.Instance.UpdateTarejectory(forceV, rb,transform.position);
        }
        if (Input.GetMouseButtonUp(0))
        {
            DrawTrajectory.Instance.HideLine();
        }
    }
  
}
