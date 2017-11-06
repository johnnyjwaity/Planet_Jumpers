using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkBuilder : MonoBehaviour {
    public GameObject[] chunksPossible;
    public float chunkWidth;
    private int currentChunk;
    private int currentBuildChunk;
    private GameObject player;
    public float yAxis;
    private List<GameObject> activeChunks;
    private GameManager gm;
	// Use this for initialization
	void Start () {
        currentChunk = 1;
        gm = FindObjectOfType<GameManager>();
        //player = FindObjectOfType<PlayerController>().gameObject;
        activeChunks = new List<GameObject>();
        refreshChunks();
	}
	
	// Update is called once per frame
	void Update () {
        if (!gm.gameIsRunning)
        {
            return;
        }
        if(player == null)
        {
            player = FindObjectOfType<PlayerController>().gameObject;
        }
        if(player.transform.position.x > chunkWidth * currentChunk){
            loadNewChunk();
            currentChunk++;
        }

        if(activeChunks.Count > 5)
        {
            Destroy(activeChunks[0]);
            activeChunks.RemoveAt(0);
        }
	}

    public void loadNewChunk()
    {
        int rNum = Random.Range(0, chunksPossible.Length);
        GameObject chunk = Instantiate(chunksPossible[rNum], new Vector3((currentBuildChunk * chunkWidth)+(chunkWidth/2), yAxis, -0.3f), Quaternion.Euler(Vector3.zero));
        activeChunks.Add(chunk);
        currentBuildChunk++;
    }
    public void refreshChunks()
    {
        foreach(GameObject currentChunk in activeChunks)
        {
            Destroy(currentChunk);
        }
        activeChunks.Clear();
        currentBuildChunk = 0;
        currentChunk = 1;
        for(int i = 0; i<3; i++)
        {
            loadNewChunk();
        }
       
    }
}
