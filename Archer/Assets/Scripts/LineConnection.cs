using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConnection : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    private LineRenderer lr;
    public GameManager gameManager;
    int turn = 0;
    // Update is called once per frame
    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        enemy = gameManager.enemyList[turn].gameObject;
    }
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, enemy.transform.position);
       
        DrawLine(player,enemy,3f,lr);
    }
    public static void DrawLine(GameObject first, GameObject second, float linewidth,LineRenderer lr)
    {
        
        lr.SetPosition(0, first.gameObject.transform.position);
        lr.SetPosition(1, second.gameObject.transform.position);
        lr.startWidth = linewidth;
        lr.endWidth = linewidth;
    }
}
