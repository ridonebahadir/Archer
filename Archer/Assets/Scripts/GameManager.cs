using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Animator playerAnim;
    public Text scoreText;
    public int score;
    public Transform Spawn;

    public GameObject[] prefab;
    public GameObject[] enemy;
    public List<GameObject> enemyList;
    public int piece = 10;
   

    [Header("Start Panel")]
    public Player player;
    public GameObject startPanel;
    void Start()
    {
        player.enabled = false;
        int child = 0;
        scoreText.text = "Score = " + score.ToString();


        for (int i = 1; i < piece; i++)
        {

            int random = Random.Range(0, 2) == 0 ? -3 : 3;
           
            //if (child ==prefab.Length)
            //{
            //    child = 0;
            //}


            switch (child)
            {
                case 0:
                case 1:
                    Instantiate(prefab[child], transform.position + new Vector3(random, 0, i * 15), Quaternion.identity, Spawn);
                    break;
                case 2:
                    int rand = Random.Range(0, enemy.Length);
                    GameObject obj= Instantiate(enemy[rand], transform.position + new Vector3(random, 0, i * 15), Quaternion.identity, Spawn);
                    enemyList.Add(obj);
                    break;
                case 3:
                    Instantiate(prefab[child], transform.position + new Vector3(0, 0, i * 15), Quaternion.identity, Spawn);
                    child = 0;
                    break;
                default:
                    break;
            }
          
           
            child++;
        }

        //for (int i = 1; i < 10; i++)
        //{
        //    int random = Random.Range(0, 2) == 0 ? -3 : 3;
        //    GameObject obj= Instantiate(enemy, transform.position + new Vector3(0, 0, i * 45), Quaternion.Euler(0,180,0), Spawn);
        //    obj.transform.GetChild(0).localPosition = new Vector3(random, 0, 0);
        //}

        //for (int i = 1; i < 10; i++)
        //{
        //    int random = Random.Range(0, 2) == 0 ? -3 : 3;
        //    Instantiate(health, transform.position + new Vector3(random, 0, i * 50), Quaternion.identity, Spawn);
            
        //}


    }

   public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Finish()
    {
        Invoke("Restart", 3f);
    }
    public void StartButton()
    {
        playerAnim.SetBool("Start", true);
        startPanel.SetActive(false);
        player.enabled = true;
    }
}
