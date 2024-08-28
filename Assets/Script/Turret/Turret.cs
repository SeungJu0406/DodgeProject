using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject Clone()
    {
        return Instantiate(this.gameObject);
    }
}
