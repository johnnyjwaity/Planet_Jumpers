using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject player;
    public GameObject startPoint;
    public bool gameIsRunning;
    public Button playButton;
    private Animator anim;

    private float AnimationDuration;
    private float timerCounter;
    private bool timerRunning;

    private SoundManager sm;

    public GameObject scoreDisplay;
    public GameObject bestDisplay;
    public GameObject lastDisplay;
    public GameObject creditsButton;
    public GameObject shopButton;
    public GameObject introButton;
    public GameObject volumeButton;

    public Color red;
    public Color white;


    public Toggle doNotShow;

    // Use this for initialization
    void Start () {
        sm = GetComponent<SoundManager>();
        anim = GetComponent<Animator>();
        AnimationDuration = 0.8f;
        //PlayerPrefs.SetInt("FirstTimePlaying", 0);
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetInt("Volume", 1);
        }

        AudioListener.volume = PlayerPrefs.GetInt("Volume");
	}
	
	// Update is called once per frame
	void Update () {
        AudioListener.volume = PlayerPrefs.GetInt("Volume");
        if (PlayerPrefs.GetInt("Volume") == 1)
        {
            volumeButton.GetComponent<Button>().GetComponent<Image>().color = white;
        }
        else
        {
            volumeButton.GetComponent<Button>().GetComponent<Image>().color = red;
        }

        if (timerRunning)
        {
            timerCounter -= Time.deltaTime;
            if(timerCounter <= 0)
            {
                startGameCode();
                timerRunning = false;
            }
        }
	}
    public void startGame()
    {
        playButton.interactable = false;
        playButton.gameObject.SetActive(false);
        anim.SetBool("gameRunning", true);
        timerCounter = AnimationDuration;
        timerRunning = true;
        scoreDisplay.SetActive(true);
        bestDisplay.SetActive(false);
        lastDisplay.SetActive(false);
        creditsButton.SetActive(false);
        shopButton.SetActive(false);
        introButton.SetActive(false);
        volumeButton.SetActive(false);
        doNotShow.gameObject.SetActive(true);
    }

    private void startGameCode()
    {
        Debug.Log("Created Player");
        GameObject playerClone = Instantiate(player, startPoint.transform.position, Quaternion.Euler(Vector3.zero));
        playerClone.name = "Player";
        gameIsRunning = true;
        if(!PlayerPrefs.HasKey("FirstTimePlaying")){
            PlayerPrefs.SetInt("FirstTimePlaying", 0);
        }

        if(PlayerPrefs.GetInt("FirstTimePlaying") == 0){
            openIntro();
        }
        sm.playMusic();
        
        
        
    }

    public void endGame()
    {
        GetComponent<ADManager>().ShowRewardedVideo();
        gameIsRunning = false;
        playButton.interactable = true;
        playButton.gameObject.SetActive(true);
        anim.SetBool("gameRunning", false);
        sm.stopMusic();

        scoreDisplay.SetActive(false);
        bestDisplay.SetActive(true);
        lastDisplay.SetActive(true);
        creditsButton.SetActive(true);
        shopButton.SetActive(true);
        introButton.SetActive(true);
        volumeButton.SetActive(true);
        doNotShow.gameObject.SetActive(false);
    }

    public void openCredits()
    {
        anim.SetBool("creditsPanel", true);
    }
    public void closeCredits()
    {
        anim.SetBool("creditsPanel", false);
    }

    public void openShop()
    {
        anim.SetBool("shopPanel", true);
    }
    public void closeShop()
    {
        anim.SetBool("shopPanel", false);
    }

    public void openIntro()
    {
        anim.SetBool("introPanel", true);
    }
    public void closeIntro()
    {
        anim.SetBool("introPanel", false);
    }

    public void doNotShowAgain(){
        if(doNotShow.isOn){
            PlayerPrefs.SetInt("FirstTimePlaying", 1);
        }
        else{
            PlayerPrefs.SetInt("FirstTimePlaying", 0);
        }
    }

    public void toggleVolume()
    {
        if(PlayerPrefs.GetInt("Volume") == 1)
        {
            PlayerPrefs.SetInt("Volume", 0);
        }
        else{
            PlayerPrefs.SetInt("Volume", 1);

        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }

}
