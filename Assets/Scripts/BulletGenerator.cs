using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public int BullettoWant;
    private float Offset = 0.38f;
    public GameObject BulletPrefabs;
    [HideInInspector]
    public int NumberofBullet;
    void Start()
    {
        for (int i = 0; i < BullettoWant; i++)
        {
            transform.position = new Vector3(transform.position.x + Offset, transform.position.y, transform.position.z);
            Instantiate(BulletPrefabs, transform.position,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        NumberofBullet = GameObject.FindGameObjectsWithTag("Active").Length;
    }
    public void Deleted()
    {
        Destroy(GameObject.FindGameObjectsWithTag("Active")[NumberofBullet-1]);
    }
}
