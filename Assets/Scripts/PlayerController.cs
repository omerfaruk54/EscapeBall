using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private float spawnY = 0f;
    private float speed = 10f;
    private float leftBall;
    private float healtBar = 3;

    //public int nextSceneLoad;

    private Rigidbody playerRB;


    [SerializeField] private Image[] healt;

    [SerializeField] private Text countText;

    [SerializeField] private Button nextLevelButton;


    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] spawner;
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject[] goal;
    [SerializeField] private GameObject gate;

    [SerializeField] private Vector3 firstPosition;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        leftBall = goal.Length;
        nextLevelButton.gameObject.SetActive(false);
        Time.timeScale = 1;
        //nextSceneLoad = SceneManager.GetActiveScene().buildIndex +1;
}

    // Update is called once per frame
    void FixedUpdate()
    {
        Bound();
        countText.text = "REMAINING: " + leftBall;
    }

    void Bound()
    {
        if (player.gameObject.transform.position.y < -1)
        {
            player.transform.position = firstPosition;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Star")) // if you take all ball you must go to goal.
        {

            Destroy(other.gameObject);
            leftBall--;
            if (leftBall == 0)
            {
                Destroy(gate);
            }
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            Destroy(other.gameObject);
            //ceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            nextLevelButton.gameObject.SetActive(true);
            Time.timeScale = 0;

           /* SceneManager.LoadScene(nextSceneLoad);
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }*/




        }

        else if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            Destroy(enemy[Random.Range(0,enemy.Length)]);
            enemy[0].GetComponent<NavMeshAgent>().speed = 4;
            
        }

        else if (other.gameObject.CompareTag("Trap"))
        {
            Destroy(other.gameObject);
            
            player.GetComponent<JoystickPlayerExample>().speed = 0;

        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Gate") || collision.gameObject.CompareTag("Water"))
        {
            if(enemy[0] != null)
            {
                Instantiate(enemy[Random.Range(0, enemy.Length)], spawner[Random.Range(0, spawner.Length)].transform.position, enemy[0].transform.rotation);
            }
            
            healtBar--;
            player.transform.position = firstPosition;
            if (healtBar == 2)
            {
                Destroy(healt[2]);
            }
            else if (healtBar == 1)
            {
                Destroy(healt[1]);
            }
            else if(healtBar==0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }

        else if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

