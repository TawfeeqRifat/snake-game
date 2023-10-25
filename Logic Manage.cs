using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManage : MonoBehaviour
{
    public player_movement player;
    public GameObject food;
    GameObject currentFood;
    public GameObject GOScreen;
    public AudioClip a1;
    public AudioSource audiosource;
    
    static bool highscoretrue;
    public Text displayScore;
    public Text displayHighScore;
    public int playerScore;
    public int points = 3;
    void Start()
    {
       playerScore=0 ;
        spawner();
    }
    public void spawner()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>();
        currentFood = Instantiate(food, new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0), transform.rotation);
    }
    // Update is called once per frame
    [ContextMenu("eat")]
    public void eat()
    {
        //AudioSource.PlayClipAtPoint(a1, transform.position);
        audiosource.Play();
        Destroy(currentFood);
        for (int i = 0; i < 4; i++) { player.grow(); }
         spawner();
        playerScore += points;

    }

    public void gameOverScreen()
    {
        int HighScore;
        GOScreen.SetActive(true);
        displayScore.text = "Score:" +playerScore.ToString();
        //if (highscoretrue) {
            HighScore = PlayerPrefs.GetInt("HighScore" );
            HighScore = HighScore > playerScore ? HighScore : playerScore;
            PlayerPrefs.SetInt("HighScore", HighScore);
        displayHighScore.text = "High Score:" + HighScore.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void giveUp()
    {
        SceneManager.LoadScene(0);
    }
}
