using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectingAdapter : MonoBehaviour, IDetectable
{
    public UnityEvent<Player> OnDetect;
    public void Detect(Player player)
    {
        OnDetect?.Invoke(player);
    }

}
