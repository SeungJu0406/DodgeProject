using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum GameState { Ready, Progress, Goal, Over }
public class GameManager : MonoBehaviour
{   
    public static GameManager Instance;
    
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
    }

    private void Update()
    {
        if(curState == GameState.Ready && !Input.anyKeyDown)
        {
            ReadyGame();
        }
        else if (curState == GameState.Ready && Input.anyKeyDown)
        {
            StartGame();
        }
        else if ((curState == GameState.Over||curState==GameState.Goal )&& Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
    public void ReadyGame()
    {
        curState = GameState.Ready;
        OnReady?.Invoke();
    }

    public void StartGame()
    {
        curState = GameState.Progress;
        OnStart?.Invoke();
    }
    public void GameOver()
    {
        curState = GameState.Over;
        Camera.main.transform.parent = null;
        OnGameOver?.Invoke();
    }
    public void GoalGame()
    {
        curState = GameState.Goal; 
        OnGoal?.Invoke();
    }

}
