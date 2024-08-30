using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static GameManager Game { get { return GameManager.Instance; } }
    public static UIManager UI { get { return UIManager.Instance; } }

    public void OnEnable()
    {
        GameManager.Create();
        UIManager.Create();
    }
}
