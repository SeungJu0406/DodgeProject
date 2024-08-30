using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState { Ready, Progress, Goal, Over }

    [SerializeField] Map map;

    [SerializeField] Player player;

    [HideInInspector] GameObject instancePlayerObj;

    [HideInInspector] Player instancePlayer;

    [HideInInspector] Detecting playerdetecting;

    [SerializeField] public GameState curState;

    [Header("UI")]
    [SerializeField] GameObject readyUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject goalUI;

    private void Start()
    {
        Camera.main.transform.position = new Vector3(0, 18, -12);
        Camera.main.transform.rotation = Quaternion.Euler(60, 0, 0);

        player.transform.position = new Vector3(0, 0, 0);
        instancePlayerObj = Instantiate(player.gameObject);
        instancePlayer=instancePlayerObj.GetComponent<Player>();
        instancePlayer.OnDie += OverGame;
        instancePlayer.OnWin += GoalGame;
        playerdetecting = instancePlayerObj.GetComponent<Detecting>();
        Camera.main.transform.parent = instancePlayer.transform;


        curState = GameState.Ready;
        
        playerdetecting.enabled = false;

        readyUI.SetActive(true);
        gameOverUI.SetActive(false);
        goalUI.SetActive(false);
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

    void StartGame()
    {
        curState = GameState.Progress;
        readyUI.SetActive(false);
        playerdetecting.enabled = true;
    }
    void OverGame()
    {
        // 타워 공격중지
        curState = GameState.Over;
        gameOverUI.SetActive(true);
        Camera.main.transform.parent = null;
        playerdetecting.enabled = false;
    }
    void GoalGame()
    {
        curState = GameState.Goal; 
        goalUI.SetActive(true);
        playerdetecting.enabled = false;
    }

}
