using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointTracker : MonoBehaviour {
    public int points;
    public Text pointDisplay;
    public Text lastDisplay;
    public Text bestDisplay;
    private GameManager gm;
    // Use this for initialization
    void Start () {
        gm = GetComponent<GameManager>();
        points = 0;
        pointDisplay.text = "Score: " + points;
        pointDisplay.gameObject.SetActive(false);
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        bestDisplay.text = "Best: " + PlayerPrefs.GetInt("HighScore");

        if (!PlayerPrefs.HasKey("LastScore"))
        {
            PlayerPrefs.SetInt("LastScore", 0);
        }
        lastDisplay.text = "Last: " + PlayerPrefs.GetInt("LastScore");
    }
	
	// Update is called once per frame
	void Update () {
        if (gm.gameIsRunning)
        {
            if (!pointDisplay.gameObject.activeSelf)
            {
                pointDisplay.gameObject.SetActive(true);
            }
        }
	}
    public void addPoints(int amount)
    {
        points += amount;
        pointDisplay.text = "Score: " + points;
    }
    public void restart()
    {
        PlayerPrefs.SetInt("LastScore", points);
        if(points > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", points);
        }
        points = 0;
        pointDisplay.text = "Score: " + points;
        pointDisplay.gameObject.SetActive(false);

        lastDisplay.text = "Last: " + PlayerPrefs.GetInt("LastScore");
        bestDisplay.text = "Best: " + PlayerPrefs.GetInt("HighScore");
    }
}
