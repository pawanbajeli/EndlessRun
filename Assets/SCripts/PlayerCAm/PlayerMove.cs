using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    public Text score;
    public GameObject gameEndPrefab;
     GameObject replyButton;


    private Rigidbody rb;
    int scorevalue;
    bool isgameOver = false;
    


    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the player
        GameObject obj = GameObject.FindGameObjectWithTag("gamescore");
        score= obj.GetComponent<Text>();
        replyButton = GameObject.FindGameObjectWithTag("replay");
        replyButton.SetActive(false);
    }

    void Update()
    {
        // Player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * speed * Time.deltaTime;
        rb.MovePosition(transform.position + transform.TransformDirection(movement));

        scorevalue=int.Parse(score.text);
        //to check the player has crossed the edge or not
        if (!isgameOver)
        {
            if (this.transform.position.x < -5.8f || this.transform.position.x > 4.5f)
            {
                stopGame();
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="coin1" || collision.gameObject.tag=="coin2")
        {
            //Debug.Log("coin destroyed");
            scorevalue++;
            score.text =scorevalue.ToString();
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag=="death")
        {
            Instantiate(gameEndPrefab, this.transform.position, Quaternion.identity);
            Time.timeScale = 0;
            replyButton.SetActive(true);
            

        }
    }

    void stopGame()
    {
        isgameOver = true;
        Time.timeScale = 0;
        replyButton.SetActive(true);
    }


}
