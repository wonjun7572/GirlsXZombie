using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

/// The states of the game.
public enum GameManagerState
{
    STARTING,
    SPAWNING,
    MOVING,
    MERGING,
    CHECKING,
    WAITING,
    WIN,
    GAMEOVER
}

/// the transitions for the game states.
public enum GameManagerStateTran
{
    DONE,
    MOVE,
    SPAWN,
    CHECK,
    MERGE,
    WIN,
    LOSE
}

/// <summary>
/// Move direction to control where we move.
/// </summary>
public enum MoveDir
{
    NONE,
    LEFT,
    RIGHT,
    UP,
    DOWN
}

public class GameManager : MonoBehaviour, IDragHandler
{
    GameObject tile;

    public float currentGameTime;
    public GameObject tilePrefab;
    public float tileWidth;
    public float tileHeight;

    public AudioClip mergeSound;

    /// <summary>
    /// the size of the board normally 4x4
    /// </summary>
    public int boardSize;

    /// <summary>
    /// The drag gap where wwe detect the dragin to avoid false drags.
    /// </summary>
    public int dragGap;

    public int totalCells;

    public int i;

    /// <summary>
    /// Private fields used for working in the game manager.
    /// </summary>

    float totalScore;
    bool removedTutorial;

    private float time;
    private bool timer_condition = true;
    private float t = 2.0f; //2초이상 눌렀을때를 표현하기 위해서

    MoveDir currentDir;
    int currentTileID;

    int[,] tilePositions;

    //List<List<int>> merges;

    float biggestScore;

    Dictionary<int, GameObject> spawnedTiles;

    StateMachine stateMachine;

    float timer;
    int totalMoved;

    public GameObject BasicMap;
    public GameObject LabMap;

    void Awake()
    {
        // 맵 스킨 체크
        CheckMapKey();
    }

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
        currentTileID = 1;
        tilePositions = new int[boardSize, boardSize];
        spawnedTiles = new Dictionary<int, GameObject>();
        //merges = new List<List<int>>();

        for (int col = 0; col < tilePositions.GetLength(0); col++)
        {
            for (int row = 0; row < tilePositions.GetLength(1); row++)
            {
                tilePositions[col, row] = -1;
                totalCells++;
            }
        }

        // WE setup here the state machine for our game manager.
        stateMachine = new StateMachine();

        stateMachine.CreateState(GameManagerState.STARTING, OnStarting);
        stateMachine.CreateState(GameManagerState.WAITING, OnWaiting);
        stateMachine.CreateState(GameManagerState.MOVING, OnMoving);
        stateMachine.CreateState(GameManagerState.MERGING, OnMerging);
        stateMachine.CreateState(GameManagerState.SPAWNING, OnSpawning);
        stateMachine.CreateState(GameManagerState.CHECKING, OnChecking);
        stateMachine.CreateState(GameManagerState.WIN, OnWin);
        stateMachine.CreateState(GameManagerState.GAMEOVER, OnGameOver);

        stateMachine.CreateTransition(GameManagerState.STARTING, GameManagerState.WAITING, GameManagerStateTran.DONE);

        stateMachine.CreateTransition(GameManagerState.WAITING, GameManagerState.MOVING, GameManagerStateTran.MOVE);

        stateMachine.CreateTransition(GameManagerState.MOVING, GameManagerState.MERGING, GameManagerStateTran.DONE);

        stateMachine.CreateTransition(GameManagerState.MERGING, GameManagerState.CHECKING, GameManagerStateTran.DONE);

        stateMachine.CreateTransition(GameManagerState.CHECKING, GameManagerState.SPAWNING, GameManagerStateTran.SPAWN);
        stateMachine.CreateTransition(GameManagerState.CHECKING, GameManagerState.WIN, GameManagerStateTran.WIN, OnWinIn);
        stateMachine.CreateTransition(GameManagerState.CHECKING, GameManagerState.GAMEOVER, GameManagerStateTran.LOSE, OnGameOverIn);

        stateMachine.CreateTransition(GameManagerState.SPAWNING, GameManagerState.WAITING, GameManagerStateTran.DONE);

        stateMachine.SetCurrentState(GameManagerState.STARTING);

        PlayerState.Instance.AddScore(0, 0);
    }

    /// <summary>
    /// Gets a new tile ID.
    /// </summary>
    /// <returns>The new I.</returns>
    public int GetNewID()
    {
        return currentTileID++;
    }

    /// <summary>
    /// Creates the new tile.
    /// </summary>
    /// <returns>The new tile.</returns>
    public GameObject CreateNewTile()
    {
        int tvalue = 2; //2번째로 생성

        int trow = -1;
        int tcol = -1;

        if (totalCells - spawnedTiles.Count <= 0)
        {
            return null;
        }

        int newCell = Random.Range(0, totalCells - spawnedTiles.Count);

        for (int col = 0; col < tilePositions.GetLength(0); col++)
        {
            for (int row = 0; row < tilePositions.GetLength(1); row++)
            {
                if (tilePositions[col, row] == -1)
                {
                    newCell--;
                    if (newCell <= 0)
                    {
                        trow = row;
                        tcol = col;
                        break;
                    }
                }
            }
            if (trow >= 0 && tcol >= 0)
            {
                break;
            }
        }

        tile = GameObject.Instantiate(tilePrefab, new Vector3(tcol * tileWidth + 0.45f, 0, trow * tileWidth + 0.4f), Quaternion.identity) as GameObject;

        int tileID = GetNewID();

        tilePositions[tcol, trow] = tileID;
        spawnedTiles.Add(tileID, tile);

        tile.GetComponent<TileBehavior>().currentCol = tcol;
        tile.GetComponent<TileBehavior>().tileID = tileID;
        tile.GetComponent<TileBehavior>().currentRow = trow;
        tile.GetComponent<TileBehavior>().tileAmount = tvalue;

        return tile;
    }

    public GameObject FirstTiles()
    {
        int tvalue = 2; //2번째로 생성

        int trow = 1;
        int tcol = 1;

        tile = GameObject.Instantiate(tilePrefab, new Vector3(tcol * tileWidth + 0.45f, 0, trow * tileWidth + 0.4f), Quaternion.identity) as GameObject;

        int tileID = GetNewID();

        tilePositions[tcol, trow] = tileID;
        spawnedTiles.Add(tileID, tile);

        tile.GetComponent<TileBehavior>().currentCol = tcol;
        tile.GetComponent<TileBehavior>().tileID = tileID;
        tile.GetComponent<TileBehavior>().currentRow = trow;
        tile.GetComponent<TileBehavior>().tileAmount = tvalue;

        return tile;
     }

    public GameObject SecondTiles()
    {
        int tvalue = 2; //2번째로 생성

        int trow = 2;
        int tcol = 1;

        tile = GameObject.Instantiate(tilePrefab, new Vector3(tcol * tileWidth + 0.45f, 0, trow * tileWidth + 0.4f), Quaternion.identity) as GameObject;

        int tileID = GetNewID();

        tilePositions[tcol, trow] = tileID;
        spawnedTiles.Add(tileID, tile);

        tile.GetComponent<TileBehavior>().currentCol = tcol;
        tile.GetComponent<TileBehavior>().tileID = tileID;
        tile.GetComponent<TileBehavior>().currentRow = trow;
        tile.GetComponent<TileBehavior>().tileAmount = tvalue;

        return tile;
    }

    public GameObject ThirdTiles()
    {
        int tvalue = 2; //2번째로 생성

        int trow = 1;
        int tcol = 2;

        tile = GameObject.Instantiate(tilePrefab, new Vector3(tcol * tileWidth + 0.45f, 0, trow * tileWidth + 0.4f), Quaternion.identity) as GameObject;

        int tileID = GetNewID();

        tilePositions[tcol, trow] = tileID;
        spawnedTiles.Add(tileID, tile);

        tile.GetComponent<TileBehavior>().currentCol = tcol;
        tile.GetComponent<TileBehavior>().tileID = tileID;
        tile.GetComponent<TileBehavior>().currentRow = trow;
        tile.GetComponent<TileBehavior>().tileAmount = tvalue;

        return tile;
    }

    public GameObject FourthTiles()
    {
        int tvalue = 2; //2번째로 생성

        int trow = 2;
        int tcol = 2;

        tile = GameObject.Instantiate(tilePrefab, new Vector3(tcol * tileWidth + 0.45f, 0, trow * tileWidth + 0.4f), Quaternion.identity) as GameObject;

        int tileID = GetNewID();

        tilePositions[tcol, trow] = tileID;
        spawnedTiles.Add(tileID, tile);

        tile.GetComponent<TileBehavior>().currentCol = tcol;
        tile.GetComponent<TileBehavior>().tileID = tileID;
        tile.GetComponent<TileBehavior>().currentRow = trow;
        tile.GetComponent<TileBehavior>().tileAmount = tvalue;

        return tile;
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
        UpdateGUI();

        if (timer_condition)
        {
            time += Time.deltaTime;
        }

        if (time > t)
        {
            Do();
        }

        ExpSpawning(); // 생성됨
    }

    void UpdateGUI()
    {
        // 스코어 임시로 주석처리
        //GameObject.Find("CurrentScoreLabel").GetComponent<Text>().text = "" + totalScore;
        //if (PlayerState.Instance.data.scores.Count > 0)
        //{
        //	GameObject.Find("BestScoreLabel").GetComponent<Text>().text = "" + PlayerState.Instance.data.scores[0].amount;
        //}				

        if (currentGameTime >= 8 && !removedTutorial)
        {
            GameObject.Find("Tutorial").GetComponent<UIScreenDisplay>().Hide();
            removedTutorial = true;
        }

        //GameObject.Find("TimeLabel").GetComponent<Text>().text = string.Format("{0:00}:{1:00}", Mathf.Floor(currentGameTime / 60), currentGameTime % 60); 
        // 이걸 지우면 게임씬에서 메뉴씬으로 exit할때 오류는 사라짐. 근데 다시 restart가 안됨.

    }

    void OnLeft()
    {
        //Debug.Log("Left");
        currentDir = MoveDir.LEFT;
        stateMachine.ProcessTriggerEvent(GameManagerStateTran.MOVE);
    }

    void OnRight()
    {
        //Debug.Log("Right");
        currentDir = MoveDir.RIGHT;
        stateMachine.ProcessTriggerEvent(GameManagerStateTran.MOVE);
    }

    void OnUp()
    {
        //Debug.Log("Up");
        currentDir = MoveDir.UP;
        stateMachine.ProcessTriggerEvent(GameManagerStateTran.MOVE);
    }

    void OnDown()
    {
        //Debug.Log("Down");
        currentDir = MoveDir.DOWN;
        stateMachine.ProcessTriggerEvent(GameManagerStateTran.MOVE);
    }

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
    {
        if (stateMachine.CurrentState.name == GameManagerState.WAITING.ToString()) //아무것도 입력을 받지 않고있다면 
        {
            if (eventData.delta.x < -dragGap)
            {
                OnLeft();
            }

            if (eventData.delta.y < -dragGap)
            {
                OnDown();
            }

            if (eventData.delta.x > dragGap)
            {
                OnRight();
            }

            if (eventData.delta.y > dragGap)
            {
                OnUp();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        timer_condition = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        timer_condition = false;
        time = 0f;
    }

    public void Do()
    {
        timer_condition = false;
        time = 0f;
    }

    #endregion


    #region STATE_MACHINE

    TileBehavior GetTile(int col, int row)
    {
        return spawnedTiles[tilePositions[col, row]].GetComponent<TileBehavior>();
    }

    void OnStarting()
    {
        FirstTiles();
        SecondTiles();
        ThirdTiles();
        FourthTiles();

        stateMachine.ProcessTriggerEvent(GameManagerStateTran.DONE);

    }


    void OnWaiting()
    {
        timer = 0.15f;
        currentGameTime += Time.deltaTime;
    }

    void OnSpawning()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            //여기가 드래그하면 오브젝트 하나더 생성해주는 부분
            if (totalMoved > 0)
            {
                stateMachine.ProcessTriggerEvent(GameManagerStateTran.DONE);
            }
            // 여기까지
            else
            {
                stateMachine.ProcessTriggerEvent(GameManagerStateTran.DONE);
            }
        }
    }

    void ExpSpawning()
    {
        if (PlayerStats.Instance.Exp >= 50)
        {
            GameObject newTile = CreateNewTile();
            if (newTile != null)
            {
                timer = 0.15f;
            }
            PlayerStats.Instance.Exp = 0;
        }
    }

    void UpdateAchievements(float value)
    {
        if (value > biggestScore)
        {
            //GooglePlayManager.instance.UnlockAchievement(string.Format("achievement_{0:0}", Mathf.RoundToInt(value)));			
            biggestScore = value;
        }

    }

    /// <summary>
    /// When the state is for checking the results.
    /// </summary>
    void OnChecking()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            totalScore = 0;
            foreach (GameObject tile in spawnedTiles.Values)
            {

                totalScore += tile.GetComponent<TileBehavior>().tileAmount;

                UpdateAchievements(tile.GetComponent<TileBehavior>().tileAmount);


                if (tile.GetComponent<TileBehavior>().tileAmount >= 2048)
                {
                    stateMachine.ProcessTriggerEvent(GameManagerStateTran.WIN);
                    return;
                }

            }

            if (spawnedTiles.Count < totalCells)
            {
                stateMachine.ProcessTriggerEvent(GameManagerStateTran.SPAWN);
            }
            else
            {
                stateMachine.ProcessTriggerEvent(GameManagerStateTran.LOSE);
            }
        }
        currentDir = MoveDir.NONE;
    }

    /// <summary>
    /// When the state transites into the Win condition. this executes only once.
    /// </summary>
    void OnWinIn()
    {
        PlayerState.Instance.AddScore(0, totalScore);
        Time.timeScale = 0f;
        GameObject.Find("WinPanel").GetComponent<UIScreenDisplay>().Show();
    }

    /// <summary>
    /// When we stay at win condition, nothing to do.
    /// </summary>
    void OnWin()
    {

    }

    /// <summary>
    /// When we transite to the game over. this executes only once.
    /// </summary>
    void OnGameOverIn()
    {
        PlayerState.Instance.AddScore(0, totalScore);
        Time.timeScale = 0f;
        GameObject.Find("GameOverPanel").GetComponent<UIScreenDisplay>().Show();
        FindCharacterValue.Instance.SetCharacterValue();
        Spawner.Instance.GetGold();
    }

    /// <summary>
    /// Game Over state, nothing to do.
    /// </summary>
    void OnGameOver()
    {


    }

    /// <summary>
    /// Merges 2 tiles when we overlap one with other.
    /// </summary>
    /// <param name="aid">Aid.</param>
    /// <param name="bid">Bid.</param>
    void MergeTile(int aid, int bid)
    {
        GameObject A = spawnedTiles[aid];
        GameObject B = spawnedTiles[bid];
        //if(timer_condition == false)
        //{
        //Debug.Log("실행중");
        if (!A.GetComponent<TileBehavior>().hasMerged)
        {
            A.GetComponent<TileBehavior>().hasMerged = true;
            B.GetComponent<TileBehavior>().UpgradeTile();
            spawnedTiles.Remove(aid);
            GameObject.Destroy(A.gameObject, 0.1f);
            SoundMgr.instance.SFXPlay("MergeSound", mergeSound);
        }//이부분이 합성되면서 a가 사라지고 b가 2배된 상태에서 그자리에 생성입니다.
         //}
    }



    /// <summary>
    /// This is the state where we merge all possible merging tiles.
    /// </summary>
    void OnMerging()
    {
        for (int row = 0; row < tilePositions.GetLength(1); row++)
        {
            for (int col = 0; col < tilePositions.GetLength(0); col++)
            {

                if (tilePositions[col, row] > 0)
                {
                    GetTile(col, row).hasMerged = false;
                }
            }
        }

        stateMachine.ProcessTriggerEvent(GameManagerStateTran.DONE);
    }

    /// <summary>
    /// When we're moving the tiles.
    /// </summary>
    void OnMoving()
    {
        totalMoved = 0;
        if (currentDir == MoveDir.LEFT)
        {
           // Debug.Log("Doing move Process");
            for (int row = 0; row < tilePositions.GetLength(1); row++)
            {
                for (int col = 0; col < tilePositions.GetLength(0); col++)
                {

                    if (tilePositions[col, row] > 0)
                    {

                       // Debug.Log("Moving Tile: " + tilePositions[col, row] + "[" + col + "," + row + "]");

                        int targetCol = col;

                        for (int tcol = col - 1; tcol >= 0; tcol--)
                        {
                            targetCol = tcol;
                            if (tilePositions[tcol, row] > 0)
                            {
                                if (GetTile(tcol, row).tileAmount != GetTile(col, row).tileAmount || GetTile(tcol, row).hasMerged)
                                {
                                    targetCol = tcol + 1;
                                }
                                else
                                {
                                    MergeTile(GetTile(tcol, row).tileID, GetTile(col, row).tileID);
                                }
                                break;
                            }
                        }
                        int id = tilePositions[col, row];
                        tilePositions[col, row] = -1;
                        tilePositions[targetCol, row] = id;
                        if (spawnedTiles[tilePositions[targetCol, row]].GetComponent<TileBehavior>().currentCol != targetCol)
                        {
                            totalMoved++;
                        }
                        spawnedTiles[tilePositions[targetCol, row]].GetComponent<TileBehavior>().currentCol = targetCol;
                        spawnedTiles[tilePositions[targetCol, row]].GetComponent<TileBehavior>().MoveTo(targetCol * tileWidth + 0.45f, row * tileWidth + 0.4f);

                    }
                }
            }


        }

        if (currentDir == MoveDir.RIGHT)
        {
           // Debug.Log("Doing move RIGHT Process");
            for (int row = 0; row < tilePositions.GetLength(1); row++)
            {
                for (int col = tilePositions.GetLength(0) - 1; col >= 0; col--)
                {
                    if (tilePositions[col, row] > 0)
                    {


                        int targetCol = col;

                        for (int tcol = col + 1; tcol < tilePositions.GetLength(0); tcol++)
                        {
                            targetCol = tcol;
                            if (tilePositions[tcol, row] > 0)
                            {
                                if (GetTile(tcol, row).tileAmount != GetTile(col, row).tileAmount || GetTile(tcol, row).hasMerged)
                                {
                                    targetCol = tcol - 1;
                                }
                                else
                                {
                                    MergeTile(GetTile(tcol, row).tileID, GetTile(col, row).tileID);
                                }
                                break;
                            }
                        }
                        int id = tilePositions[col, row];
                        tilePositions[col, row] = -1;
                        tilePositions[targetCol, row] = id;

                        if (spawnedTiles[tilePositions[targetCol, row]].GetComponent<TileBehavior>().currentCol != targetCol)
                        {
                            totalMoved++;
                        }

                        spawnedTiles[tilePositions[targetCol, row]].GetComponent<TileBehavior>().currentCol = targetCol;
                        spawnedTiles[tilePositions[targetCol, row]].GetComponent<TileBehavior>().MoveTo(targetCol * tileWidth + 0.45f, row * tileWidth + 0.4f);


                    }
                }
            }


        }

        if (currentDir == MoveDir.DOWN)
        {
           // Debug.Log("Doing move Process");
            for (int col = 0; col < tilePositions.GetLength(0); col++)
            {
                for (int row = 0; row < tilePositions.GetLength(1); row++)
                {
                    if (tilePositions[col, row] > 0)
                    {

                        int targetRow = row;

                        for (int trow = row - 1; trow >= 0; trow--)
                        {
                            targetRow = trow;
                            if (tilePositions[col, trow] > 0)
                            {
                                if (GetTile(col, trow).tileAmount != GetTile(col, row).tileAmount || GetTile(col, trow).hasMerged)
                                {
                                    targetRow = trow + 1;
                                }
                                else
                                {
                                    MergeTile(GetTile(col, trow).tileID, GetTile(col, row).tileID);
                                }

                                break;
                            }
                        }
                        int id = tilePositions[col, row];
                        tilePositions[col, row] = -1;
                        tilePositions[col, targetRow] = id;
                        if (spawnedTiles[tilePositions[col, targetRow]].GetComponent<TileBehavior>().currentRow != targetRow)
                        {
                            totalMoved++;
                        }

                        spawnedTiles[tilePositions[col, targetRow]].GetComponent<TileBehavior>().currentRow = targetRow;
                        spawnedTiles[tilePositions[col, targetRow]].GetComponent<TileBehavior>().MoveTo(col * tileWidth + 0.45f, targetRow * tileWidth + 0.4f);


                    }
                }
            }

        }

        if (currentDir == MoveDir.UP)
        {
           // Debug.Log("Doing move Process");
            for (int col = 0; col < tilePositions.GetLength(0); col++)
            {
                for (int row = tilePositions.GetLength(1) - 1; row >= 0; row--)
                {
                    if (tilePositions[col, row] > 0)
                    {

                        int targetRow = row;

                        for (int trow = row + 1; trow < tilePositions.GetLength(1); trow++)
                        {
                            targetRow = trow;
                            if (tilePositions[col, trow] > 0)
                            {
                                if (GetTile(col, trow).tileAmount != GetTile(col, row).tileAmount || GetTile(col, trow).hasMerged)
                                {
                                    targetRow = trow - 1;
                                }
                                else
                                {
                                    MergeTile(GetTile(col, trow).tileID, GetTile(col, row).tileID);

                                }

                                break;
                            }
                        }

                        int id = tilePositions[col, row];
                        tilePositions[col, row] = -1;
                        tilePositions[col, targetRow] = id;

                        if (spawnedTiles[tilePositions[col, targetRow]].GetComponent<TileBehavior>().currentRow != targetRow)
                        {
                            totalMoved++;
                        }

                        spawnedTiles[tilePositions[col, targetRow]].GetComponent<TileBehavior>().currentRow = targetRow;
                        spawnedTiles[tilePositions[col, targetRow]].GetComponent<TileBehavior>().MoveTo(col * tileWidth + 0.45f, targetRow * tileWidth + 0.4f);
                    }
                }
            }
        }

        PrintBoard();
        timer = 0.15f;

        stateMachine.ProcessTriggerEvent(GameManagerStateTran.DONE);

    }

    /// <summary>
    /// Debug function to print out the board.
    /// </summary>
    void PrintBoard()
    {
        for (int row = 3; row >= 0; row--)
        {
            string t = "";
            for (int col = 0; col < 4; col++)
            {
                t += "[" + tilePositions[col, row] + "]";
            }
            //Debug.Log(t);
        }
    }


    #endregion

    void CheckMapKey()
    {
        if(PlayerPrefsMgr._map == 0)
        {
            BasicMap.SetActive(true);
            LabMap.SetActive(false);
        }

        else if(PlayerPrefsMgr._map == 1)
        {
            BasicMap.SetActive(false);
            LabMap.SetActive(true);
        }
    }
}
