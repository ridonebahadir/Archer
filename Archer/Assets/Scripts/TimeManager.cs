using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.5f;
    public float slowdownLength = 2f;

    public static int enemyChild;
    public Transform enemySpawn;
    // Update is called once per frame
    void Update()
    {
        //Time.timeScale += (1f / slowdownLength)*Time.unscaledDeltaTime;
        
        //Time.timeScale = Mathf.Clamp(Time.timeScale,0f,1f);
    
    
    }

    public void DoSlowmotion()
    {
        enemySpawn.GetChild(enemyChild).GetChild(0).GetChild(0).GetComponent<Animator>().speed = 0.2f;
        //Time.timeScale = slowdownFactor;
        //Time.fixedDeltaTime = Time.timeScale * .02f;

    }

}
