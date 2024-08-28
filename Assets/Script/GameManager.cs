using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState { Ready, Progress ,Over }

    [SerializeField] Map map;

    [SerializeField] Player player;

    [SerializeField] Turret turret;

    [SerializeField] Turret[] turrets;

    [SerializeField] public GameState curState;

    [Header("UI")]
    [SerializeField] GameObject readyUI;
    [SerializeField] GameObject gameOverUI;

    private void Start()
    {
        Camera.main.transform.position = new Vector3(0, 18, -12);
        Camera.main.transform.rotation = Quaternion.Euler(60, 0, 0);       

        player.transform.position = new Vector3(0, 0, 0);
        GameObject instancePlayer =Instantiate(player.gameObject);
        instancePlayer.GetComponent<Player>().OnDie += OverGame;
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
    }

    private void Update()
    {
        if (curState == GameState.Ready && Input.anyKeyDown)
        {
            StartGame();
        }
        else if (curState == GameState.Over && Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    void StartGame()
    {
        curState = GameState.Progress;
        readyUI.SetActive(false);
        gameOverUI.SetActive(false);
        foreach (Turret turret in turrets)
        {
            turret.StartAttack();
        }
    }
    void OverGame()
    {
        // 타워 공격중지
        curState = GameState.Over;
        readyUI.SetActive(false);
        gameOverUI.SetActive(true);
        foreach (Turret turret in turrets)
        {
            turret.StopAttack();
        }
    }

}
