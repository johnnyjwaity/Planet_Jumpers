using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkBuilder : MonoBehaviour {
    public GameObject[] chunksPossible;
    public float chunkWidth;
    private int currentChunk;
    private GameObject player;
    public float yAxis;
	// Use this for initialization
	void Start () {
        currentChunk = 1;
        player = FindObjectOfType<PlayerController>().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if(player.transform.position.x > chunkWidth * currentChunk){
            loadNewChunk();
            currentChunk++;
        }
	}

    public void loadNewChunk()
    {
        int rNum = Random.Range(0, chunksPossible.Length-1);
        Instantiate(chunksPossible[rNum], new Vector3(currentChunk * chunkWidth, yAxis, -0.3f), Quaternion.Euler(Vector3.zero));
    }
}
