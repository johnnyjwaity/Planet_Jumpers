﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakSprite : MonoBehaviour
{

    public int size = 4;
    public int PPU = 32;

    private float timer;
    public bool landedOn;
    public float timeTillExplosion;

    public bool breakSprite;

    public Animator projectionField;
    private bool startedAnimation;

    public TextMesh timerText;
    // Use this for initialization
    void Start()
    {
        //BreakUp();
        timer = timeTillExplosion;
        timerText.text = timeTillExplosion + "";
    }

    // Update is called once per frame
    void Update()
    {
        if(breakSprite){
            BreakUp();
            breakSprite = false;
        }

        if(landedOn){
            if (!startedAnimation)
            {
                projectionField.SetTrigger("Project");
                startedAnimation = true;
            }
            timer -= Time.deltaTime;
            timerText.text = Mathf.Floor(timer+1)+"";
            if(timer <= 0){
                breakSprite = true;
            }
        }
    }

    void BreakUp()
    {
        // Get sprite texture
        Texture2D sourceTexture = GetComponent<SpriteRenderer>().sprite.texture;

        // Get sprite width and height
        int width = Mathf.FloorToInt(GetComponent<SpriteRenderer>().sprite.rect.width);
        int height = Mathf.FloorToInt(GetComponent<SpriteRenderer>().sprite.rect.height);

        int partNumber = 0;

        for (int i = 0; i < width / size; i++)
        {
            for (int j = 0; j < height / size; j++)
            {
                // Cut out the needed part from the texture
                Sprite newSprite = Sprite.Create(sourceTexture, new Rect(i * width / (width / size), j * height / (height / size), size, size), new Vector2(0f, 0f), PPU);
                GameObject n = new GameObject();
                n.AddComponent<Rigidbody2D>();
                SpriteRenderer sr = n.AddComponent<SpriteRenderer>();
                sr.sprite = newSprite; //A kivágott sprite-ot megkapja az új GameObject
                sr.name = "part " + partNumber;
                // Place every GameObject as it was in the original sprite
                n.transform.position = new Vector3((GetComponent<SpriteRenderer>().bounds.min.x + (sr.sprite.rect.width / PPU) * i), (GetComponent<SpriteRenderer>().bounds.min.y + (sr.sprite.rect.width / PPU) * j), transform.position.z);
                //n.transform.parent = transform; // Place the parts inside the parent object

                partNumber++;

                n.GetComponent<Rigidbody2D>().gravityScale = Random.Range(1, 10);
                n.AddComponent<DestroyOverTime>().time = 3;
                
            }
        }
        // Remove the original sprite
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject);
    }
}