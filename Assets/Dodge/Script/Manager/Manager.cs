using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static GameManager Game { get { return GameManager.Instance;  } }
    public static UIManager UI { get { return UIManager.Instance; } }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    public static void Initialize()
    {
        GameManager.Create();
        UIManager.Create();
    }
}
