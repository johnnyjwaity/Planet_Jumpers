using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkListener : MonoBehaviour {
    private ChunkBuilder cb;
	// Use this for initialization
	void Start () {
        cb = FindObjectOfType<ChunkBuilder>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            cb.loadNewChunk();
        }
    }
}
