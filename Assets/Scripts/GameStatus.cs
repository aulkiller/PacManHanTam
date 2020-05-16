using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private int currentScore = 0,totalPoint;

    public Vector2 maxAreaSize,minAreaSize;
    [SerializeField] private GameObject pointPrefabs,finishPrefabs;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    private void Start()
    {
        scoreText.text = currentScore.ToString();
        pointMaker();
        
    }

    public void GetPoint()
    {
        totalPoint--;
        currentScore++;
        scoreText.text = currentScore.ToString();
        if(totalPoint==0)
        {
            GameObject finishLine = Instantiate(finishPrefabs);
        }
    }

    void pointMaker()
    {
        GameObject pointParent = new GameObject();
        pointParent.transform.position = Vector2.zero;
        pointParent.name = "Point";

        for (int i = 1; i<=totalPoint; i++)
        {
           GameObject pointClone  = Instantiate(pointPrefabs);
            if (pointParent != null) pointClone.transform.parent = pointParent.transform;
            pointClone.gameObject.name = "Point " + i;
        }
    }

}
