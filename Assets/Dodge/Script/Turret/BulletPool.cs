using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] Bullet bullet;

    [SerializeField] Queue<Bullet> bulletPool;

    [SerializeField] int size;

    private void Awake()
    {
        bulletPool = new Queue<Bullet>();
        for (int i = 0; i < size; i++) 
        {
            Bullet instance = Instantiate(bullet);
            instance.gameObject.SetActive(false);
            instance.transform.parent = transform;
            instance.bulletPool = this;
            bulletPool.Enqueue(instance);
        }
    }

    public Bullet GetPool(Vector3 pos,Quaternion rot)
    {
        if(bulletPool.Count > 0)
        {
            Bullet instance = bulletPool.Dequeue();
            instance.transform.position = pos;
            instance.transform.rotation = rot;
            instance.transform.parent = null;
            instance.gameObject.SetActive(true);
            return instance;
        }
        else
        {
            Bullet instance = Instantiate(bullet, pos, rot);
            instance.bulletPool = this;
            instance.transform.parent = null;
            return instance;
        }
    }

    public void ReturnPool(Bullet instance)
    {
        instance.gameObject.SetActive(false);
        instance.transform.parent = transform;
        bulletPool.Enqueue(instance);
    }
}
