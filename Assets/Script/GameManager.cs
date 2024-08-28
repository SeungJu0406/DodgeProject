using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum GameState { Ready, Progress ,Over }

    [SerializeField] Map map;

    [SerializeField] Player player;

    [SerializeField] Turret turret;

    [HideInInspector] TurretFire[] turretFires;

    [SerializeField] Turret[] turrets;

    [SerializeField] GameState curState;

    [Header("UI")]
    [SerializeField] GameObject readyUI;
    [SerializeField] GameObject gameOverUI;

    private void Start()
    {
        Camera.main.transform.position = new Vector3(0,18,-12);
        Camera.main.transform.rotation = Quaternion.Euler(60, 0, 0);

        player.transform.position = new Vector3(0, 0, 0);       
        GameObject instancePlayer =Instantiate(player.gameObject);
        instancePlayer.GetComponent<Player>().OnDie += OverGame;
        

        int index = 0;
        turrets = FindObjectsOfType<Turret>();
        turretFires = new TurretFire[turrets.Length];
        foreach (Turret turret in turrets)
        {
            TurretRotate turretRotate = turret.GetComponent<TurretRotate>();
            turretRotate.LookTarget();
            turretFires[index++] = turret.GetComponent<TurretFire>();
        }
     
        curState = GameState.Ready;
        foreach (TurretFire turretFire in turretFires)
        {
            turretFire.StopAttack();
        }
        readyUI.SetActive(true);
        gameOverUI.SetActive(false);
    }

    private void Update()
    {
        if (curState == GameState.Ready && Input.anyKeyDown) 
        {
            StartGame();
        }
    }

    void StartGame()
    {
        curState = GameState.Progress;
        readyUI.SetActive(false);
        gameOverUI.SetActive(false);
        foreach (TurretFire turretFire in turretFires)
        {
            turretFire.StartAttack();
        }
    }
    void OverGame()
    {
        // 타워 공격중지
        curState = GameState.Over;
        readyUI.SetActive(false);
        gameOverUI.SetActive(true);
        foreach (TurretFire turretFire in turretFires)
        {
            turretFire.StopAttack();
        }
    }

}
