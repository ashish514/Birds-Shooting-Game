using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour
{
    public GameObject Death_particle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(Death_particle, transform.position, Quaternion.identity);
        }
    }

}
