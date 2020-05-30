using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameStatus : MonoBehaviour
{
    [SerializeField] private Text scoreText,timerText,highText,stageLevel;
    [SerializeField] private int areaTime;
    public int currentScore = 0, areaPoint;
    private int currentPoint;
    [SerializeField] private GameObject[] buttons = new GameObject[6];

    public Vector2 maxAreaSize,minAreaSize;
    [SerializeField] private GameObject pointPrefabs, finishPrefabs, playerObject;
    [SerializeField]  private GameObject[] enemy = new GameObject[6];
    [SerializeField] private GameObject[] healthBox = new GameObject[3];
    [SerializeField] private GameObject[] teks = new GameObject[3];
    private Vector3[] enemyLocation = new Vector3[6];
    private MazeGenerator maze;
    private Player player;
    private Grid grid;
    private GameObject Abintang;
    private Unit[] unit = new Unit[6];
    [SerializeField] private int health;
    //private GameOver button;
    private bool needTutorial = true , justTutorial = false;
    private GameObject wallParent;
    private Camera camera;
    [SerializeField] private GameObject mainCamera;
    private Vector2 scorePlace;
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
        highText.text  = PlayerPrefs.GetInt("Highscore").ToString();
        scorePlace = scoreText.rectTransform.localPosition;
       // enemy = GameObject.FindGameObjectsWithTag("Enemy");
        maze = gameObject.GetComponent<MazeGenerator>();
        player = FindObjectOfType<Player>();
        grid = FindObjectOfType<Grid>();
        Abintang = GameObject.Find("A*");
        playerObject = GameObject.Find("(Player)");
        unit = FindObjectsOfType<Unit>();
      //  button = FindObjectOfType<GameOver>();
        camera = mainCamera.GetComponent<Camera>();
    }

    private void Start()
    {
        Time.timeScale = 1;
        Destroy(healthBox[2]);
        mainCamera.transform.position = new Vector3(0, 0,-5f);
        camera.orthographicSize = 10.125f;
        wallParent = GameObject.Find("WallHandler");
        if (needTutorial == justTutorial)
        {
            Tutorial();

         }
        for (int i = 0; i < buttons.Length-1; i++)
        {
            buttons[i].SetActive(false);
        }
        for (int i = 0; i < teks.Length; i++)
        {
            teks[i].SetActive(false);
        }
        stageLevel.text = areaPoint.ToString();
        scoreText.text = currentScore.ToString();
        for (int i = 0; i < enemy.Length; i++)
        {
        //Debug.Log(i);
        enemyLocation[i]  = enemy[i].transform.position;
        }
        StartCoroutine(Timer());
    }

    public void Tutorial()
    {
        wallParent.SetActive(true);
        enemy[1].SetActive(false);
        camera.orthographicSize = 5;
        mainCamera.transform.position = new Vector2(5, 10);
    }

    public void Lanjut()
    {
       
        scoreText.alignment = TextAnchor.MiddleRight;
        scoreText.rectTransform.localPosition = scorePlace;
        stageLevel.text = areaPoint.ToString();



        for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i].transform.position = enemyLocation[i];
            }

        Time.timeScale = 1;
        StartCoroutine(Timer());
        Abintang.SetActive(false);
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].SetActive(false);
        }
        for (int i = 0; i < buttons.Length-1; i++)
            {
                buttons[i].SetActive(false);
            }
        for (int i = 0; i < teks.Length; i++)
        {
            teks[i].SetActive(false);
        }
        playerObject.SetActive(false);
            player.ResetLocation();        
        for(int i = 0; i<unit.Length;i++)
        {
            if(areaPoint%3 == 0 && areaPoint>= 18)
            {
            unit[i].Speed();
            }

        }
    }

    IEnumerator Timer()
    {
        timerText.enabled = true;
        int currentTime = areaTime;
        while (currentTime > 0)
        {
            buttons[5].SetActive(true);
            timerText.text = currentTime.ToString();
            //if (currentTime <= 3 && player.transform.localPosition != player.startLocation)  
            //{

            //}

            if( currentTime <= 3)
            {
                if (GameObject.Find("Maze") == null && GameObject.Find("WallHandler") == null)
                {
                    maze.GenerateMaze(maze.mazeRows, maze.mazeColumns);
                }
                playerObject.SetActive(true);
                player.play = false;
                    enemy[0].SetActive(true);
                //if(areaPoint %3 == 0)
                   
                    for(int i = 3,k =1; i<=areaPoint;i+=3,k++)
                    {
                        if(i<=15)
                        enemy[k].SetActive(true);
                    }
                //    if(areaPoint > 6)
                //    {
                //    if (areaPoint % 3 == 0)
                //    {
                //        if((areaPoint/3)%3 == 0)
                //        {
                //            GameObject enemyClone = Instantiate(enemyPrefabs[0],enemy[0].transform.position,enemy[0].transform.rotation);
                //            if (GameObject.Find("EnemyHandler") != null) enemyClone.transform.parent = GameObject.Find("EnemyHandler").transform;
                //            enemyClone.gameObject.name = "Enemy " + areaPoint;
                //            enemyClone.gameObject.tag = "Enemy";
                //        }
                //        if ((areaPoint / 3) % 3 == 1)
                //        {
                //            GameObject enemyClone = Instantiate(enemyPrefabs[1], enemy[2].transform.position, enemy[1].transform.rotation);
                //            if (GameObject.Find("EnemyHandler") != null) enemyClone.transform.parent = GameObject.Find("EnemyHandler").transform;
                //            enemyClone.gameObject.name = "Enemy " + areaPoint;
                //            enemyClone.gameObject.tag = "Enemy";
                //        }
                //        if ((areaPoint / 3) % 3 == 2)
                //        {
                //            GameObject enemyClone = Instantiate(enemyPrefabs[2], enemy[2].transform.position, enemy[2].transform.rotation);
                //            if (GameObject.Find("EnemyHandler") != null) enemyClone.transform.parent = GameObject.Find("EnemyHandler").transform;
                //            enemyClone.gameObject.name = "Enemy " + areaPoint;
                //            enemyClone.gameObject.tag = "Enemy";
                //        }
                //    }

                //}
            }

            //if (currentTime <= 2) Abintang.SetActive(true);

            if (currentTime <= 1 && GameObject.Find("Point") == null)
            {
                //Abintang.SetActive(true);
                grid.CreateGrid();
                PointMaker();
            //for(int i = 0;i<unit.Length;i++)
            //{
            //    StartCoroutine(unit[i].RefreshPath());
            //}
            }
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        timerText.text = "Start";
        Abintang.SetActive(true);
        player.play = true;
        Debug.Log(enemy.Length);
        unit = FindObjectsOfType<Unit>();
        for (int i = 0; i < enemy.Length; i++)
        {
            if(enemy[i].activeSelf)
            StartCoroutine(unit[i].RefreshPath());
        }
        // player.enabled = true;

        yield return new WaitForSeconds(1f);
        timerText.enabled = false;

        // print("meo");
        buttons[5].SetActive(false);
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

    private void PointMaker()
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

    public void Stop()
    {
        StopAllCoroutines();
        Destroy(GameObject.Find("Point"));
        Destroy(GameObject.Find("FinishLine(Clone)"));
        player.play = false;
        //player.enabled = false;
        buttons[3].SetActive(true);

        Time.timeScale = 0;

        if (wallParent != null)
        {
            Destroy(wallParent);
            maze.enabled = true;
        }
        if (GameObject.Find("Maze") != null)
        {
            maze.DeleteMaze();
        }
        scoreText.rectTransform.localPosition = new Vector2(0, 0);
        scoreText.alignment = TextAnchor.MiddleCenter;
        buttons[0].SetActive(true);
        if(health>0) buttons[1].SetActive(true);
        else if(health <= 0) buttons[2].SetActive(true);
    }
    public void Health()
    {
        teks[0].SetActive(true);
        health--;
        if (health != 0)
        Destroy(healthBox[health-1]);
    }
    public void Finish()
    {
        teks[1].SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        buttons[3].SetActive(true);
        teks[2].SetActive(true);
        buttons[0].SetActive(true);
        buttons[4].SetActive(true);
        
    }

    public void Resume()
    {
        Time.timeScale = 1;
        buttons[3].SetActive(false);
        teks[2].SetActive(false);
        buttons[0].SetActive(false);
        buttons[4].SetActive(false);

    }


}
