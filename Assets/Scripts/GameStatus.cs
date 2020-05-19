using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    [SerializeField] private Text scoreText,timerText;
    [SerializeField] private int currentScore = 0, areaPoint,areaTime;
    private int currentPoint;

    public Vector2 maxAreaSize,minAreaSize;
    [SerializeField] private GameObject pointPrefabs,finishPrefabs;
    private GameObject[] enemy;
    private Vector3[] enemyLocation = new Vector3[3];
    private MazeGenerator maze;
    private Player player;
    private Grid grid;
    private GameObject Abintang;
    private Unit[] unit = new Unit[3];
    public bool win=false;
    //private void Awake()
    //{
    //    int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
    //    if (gameStatusCount > 1)
    //    {
    //        gameObject.SetActive(false);
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        DontDestroyOnLoad(gameObject);
    //    }
    //}

    private void Awake()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        maze = gameObject.GetComponent<MazeGenerator>();
        player = FindObjectOfType<Player>();
        grid = FindObjectOfType<Grid>();
        Abintang = GameObject.Find("A*");
        unit = FindObjectsOfType<Unit>();



    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
        for (int i = 0; i < enemy.Length; i++)
        {
        //Debug.Log(i);
        enemyLocation[i]  = enemy[i].transform.position;
        }
        StartCoroutine(Timer());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return) && win)
        {
           // player.enabled = true;
            GameObject wallParent = GameObject.Find("WallHandler");
            if (wallParent != null)
            {
                Destroy(wallParent);
                maze.enabled = true;
            }
            if (GameObject.Find("Maze") != null)
            {
                maze.DeleteMaze();
            }
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i].transform.position = enemyLocation[i];
            }

            player.ResetLocation();
            Time.timeScale = 1;
            StartCoroutine(Timer());
            win = false;

        }
    }

    IEnumerator Timer()
    {
        timerText.enabled = true;
        player.play = false;
        int currentTime = areaTime;
        if(areaPoint == 5)
        {
            enemy[0].active = true;
        }
        if(areaPoint == 10)
            enemy[2].active = true;
        while (currentTime > 0)
        {
    
            timerText.text = currentTime.ToString();
            //if (currentTime <= 3 && player.transform.localPosition != player.startLocation)  
            //{

            //}
            if (currentTime <= 2 && GameObject.Find("Maze") == null && GameObject.Find("WallHandler") == null)
            {
                maze.GenerateMaze(maze.mazeRows, maze.mazeColumns);
            }
            if (currentTime <= 1 && GameObject.Find("Point") == null)
            {
                //Abintang.SetActive(true);
                grid.CreateGrid();
                PointMaker();
            }
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        timerText.text = "Start";
            for(int i = 0;i<unit.Length;i++)
            {
            StartCoroutine(unit[i].RefreshPath());
            }
        player.play = true;
       // player.enabled = true;

        yield return new WaitForSeconds(1f);

        timerText.enabled = false;
        // print("meo");
    }

    public void GetPoint()
    {
        currentPoint--;
        currentScore++;
        scoreText.text = currentScore.ToString();
        if(currentPoint==0)
        {
            GameObject finishLine = Instantiate(finishPrefabs);
        }
    }

    void PointMaker()
    {
        currentPoint = areaPoint;
        GameObject pointParent = new GameObject();
        pointParent.transform.position = Vector2.zero;
        pointParent.name = "Point";

        for (int i = 1; i<=areaPoint; i++)
        {
           GameObject pointClone  = Instantiate(pointPrefabs);
            if (pointParent != null) pointClone.transform.parent = pointParent.transform;
            pointClone.gameObject.name = "Point " + i;
            pointClone.gameObject.tag = "Point";
        }
    }

    public void NexLevel()
    {
       
  

        //Abintang.SetActive(false);
        Destroy(GameObject.Find("Point"));
        for (int i = 0; i< unit.Length;i++)
        {
             StopCoroutine(unit[i].FollowPath());
            //StopCoroutine("FollowPath");
        }
        player.play = false;
        //player.enabled = false;
        win = true;
        areaPoint++;
        Time.timeScale = 0;
    }

}
