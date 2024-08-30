using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum GameState { Ready, Progress, Goal, Over }
public class GameManager : MonoBehaviour
{   
    public static GameManager Instance;

    Player player;

    Detecting playerdetecting;

    Goal goal;
    
    public GameState curState;

    public event UnityAction OnReady;
    public event UnityAction OnStart;
    public event UnityAction OnGameOver;
    public event UnityAction OnGoal;

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void Create()
    {
        GameManager gameManagerPrefab = Resources.Load<GameManager>("GameManager");
        Instantiate(gameManagerPrefab);
    }

    public static void Release()
    {
        if (Instance == null) return;

        Destroy(Instance.gameObject);
        Instance = null;
    }

    private void Start()
    {
        Camera.main.transform.position = new Vector3(0, 18, -12);
        Camera.main.transform.rotation = Quaternion.Euler(60, 0, 0);

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player"); 
        player= playerObject.GetComponent<Player>();
        player.OnDie += GameOver;     
        playerdetecting = playerObject.GetComponent<Detecting>();
        Camera.main.transform.parent = player.transform;

        GameObject goalObject = GameObject.FindGameObjectWithTag("Finish");
        goal = goalObject.GetComponent<Goal>();
        goal.OnWin += GoalGame;

        ReadyGame();
    }

    private void Update()
    {
        if (curState == GameState.Ready && Input.anyKeyDown)
        {
            StartGame();
        }
        else if ((curState == GameState.Over||curState==GameState.Goal )&& Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
    void ReadyGame()
    {
        curState = GameState.Ready;
        playerdetecting.enabled = false;
        OnReady?.Invoke();
    }

    void StartGame()
    {
        curState = GameState.Progress;
        playerdetecting.enabled = true;
        OnStart?.Invoke();
    }
    void GameOver()
    {
        curState = GameState.Over;
        Camera.main.transform.parent = null;
        playerdetecting.enabled = false;
        OnGameOver?.Invoke();
    }
    void GoalGame()
    {
        curState = GameState.Goal; 
        playerdetecting.enabled = false;
        OnGoal?.Invoke();
    }

}
