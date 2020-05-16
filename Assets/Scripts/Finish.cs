using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{

    private GameStatus gameStatus;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        Location();
    }

    private void Location()
    {

        int maxX = Mathf.RoundToInt(gameStatus.maxAreaSize.x),
            maxY = Mathf.RoundToInt(gameStatus.maxAreaSize.y),
            minX = Mathf.RoundToInt(gameStatus.minAreaSize.x),
            minY = Mathf.RoundToInt(gameStatus.minAreaSize.y);

        gameObject.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            print("NEXT");
            Time.timeScale = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TembokRidho"))
        {
            Location();
        }
        
    }


}
