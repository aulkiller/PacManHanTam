﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private GameStatus gameStatus;
 
    private void Start()
    {

        gameStatus = FindObjectOfType<GameStatus>();
        Location();

    }

    public void Location()
    {

        //int maxX = Mathf.RoundToInt(gameStatus.maxAreaSize.x),
        //    maxY = Mathf.RoundToInt(gameStatus.maxAreaSize.y),
        //    minX = Mathf.RoundToInt(gameStatus.minAreaSize.x),
        //    minY = Mathf.RoundToInt(gameStatus.minAreaSize.y);

        //gameObject.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        gameObject.transform.position = new Vector2(Random.Range(gameStatus.minAreaSize.x, gameStatus.maxAreaSize.x), Random.Range(gameStatus.minAreaSize.y, gameStatus.maxAreaSize.y));
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameStatus.GetPoint();
            Destroy(gameObject);  
        }
        else if (collision.gameObject.CompareTag("TembokRidho") || collision.gameObject.CompareTag("Point"))
        {
            Location();
        }

        
    }






}
