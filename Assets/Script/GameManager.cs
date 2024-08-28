using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Map map;

    [SerializeField] Player player;

    [SerializeField] Turret turret;
    [SerializeField] GameObject[] turrets;

    private void Start()
    {
        map.transform.position = new Vector3(0, 0, 0);
        Instantiate(map.gameObject);
        
        player.transform.position = new Vector3(0, 0, 0);
        Instantiate(player.gameObject);
               
        turrets = new GameObject[4];
        for(int i = 0; i < 4; i++)
        {
            turrets[i] = turret.Clone();
        }
        turrets[0].transform.position = new Vector3 (-6, 0, -6);
        turrets[1].transform.position = new Vector3(-6, 0, 6);
        turrets[2].transform.position = new Vector3(6, 0, -6);
        turrets[3].transform.position = new Vector3(6, 0, 6);

    }

}
