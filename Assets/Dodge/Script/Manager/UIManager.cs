using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {  get; private set; }

    [Header("UI")]
    [SerializeField] GameObject uiManager;
    [SerializeField] GameObject readyUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject goalUI;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else
        {
            Destroy(gameObject);
        }
    }
    public static void Create()
    {
        UIManager UIManagerPrefab = Resources.Load<UIManager>("UIManager");
        Instantiate(UIManagerPrefab);
    }
    public static void Release()
    {
        if (Instance == null) return;

        Destroy(Instance.gameObject);
        Instance = null;
    }

    private void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("UI");

        Transform readyUITF = uiManager.transform.Find("ReadyUI");
        readyUI = readyUITF.gameObject;
        Transform gameOverUITF = uiManager.transform.Find("GameOverUI");
        gameOverUI = gameOverUITF.gameObject;
        Transform goalUITF = uiManager.transform.Find("GoalUI");
        goalUI = goalUITF.gameObject;

        Manager.Game.OnStart += StartUI;
        Manager.Game.OnGameOver += GameOverUI;
        Manager.Game.OnGoal += GoalUI;

        ReadyUI();

        
    }


    public void ReadyUI()
    {
        readyUI.gameObject.SetActive(true);
        gameOverUI.SetActive(false);
        goalUI.SetActive(false);
    }
    public void StartUI()
    {
        readyUI.SetActive(false);
        gameOverUI.SetActive(false);
        goalUI.SetActive(false);
    }
    public void GameOverUI()
    {
        readyUI.SetActive(false);
        gameOverUI.SetActive(true);
        goalUI.SetActive(false);
    }
    public void GoalUI()
    {
        readyUI.SetActive(false);
        gameOverUI.SetActive(false);
        goalUI.SetActive(true);
    }


}
