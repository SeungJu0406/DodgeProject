using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState { Ready, Progress, Goal, Over }

    [SerializeField] Map map;

    [SerializeField] Player player;

    [HideInInspector] GameObject instancePlayerObj;

    [HideInInspector] Player instancePlayer;

    [SerializeField] Turret turret;

    [SerializeField] Turret[] turrets;

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
        Camera.main.transform.parent = instancePlayer.transform;


        turrets = FindObjectsOfType<Turret>();
        foreach (Turret turret in turrets)
        {
            TurretRotate turretRotate = turret.GetComponent<TurretRotate>();
            turretRotate.FindTarget();
            turret.StopAttack();
        }

        curState = GameState.Ready;
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
        foreach (Turret turret in turrets)
        {
            turret.StartAttack();
        }
    }
    void OverGame()
    {
        // 타워 공격중지
        curState = GameState.Over;
        gameOverUI.SetActive(true);
        Camera.main.transform.parent = null; 
        foreach (Turret turret in turrets)
        {
            turret.StopAttack();
        }
    }
    void GoalGame()
    {
        curState = GameState.Goal; 
        goalUI.SetActive(true);
        foreach (Turret turret in turrets)
        {
            turret.StopAttack();
        }
    }

}
