using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADManager : MonoBehaviour {

    private int howManyPlayThroughs;

	// Use this for initialization
	void Start () {
        Advertisement.Initialize("1597619");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ShowRewardedVideo()
    {
        howManyPlayThroughs++;
        if(howManyPlayThroughs%2 == 0)
        {
            ShowOptions options = new ShowOptions();
            options.resultCallback = HandleShowResult;

            Advertisement.Show("force", options);
        }
        
    }

    private void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            Debug.Log("Video completed - Offer a reward to the player");

        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("Video was skipped - Do NOT reward the player");

        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video failed to show");
        }
    }
}
