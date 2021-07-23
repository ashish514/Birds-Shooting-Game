using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    private AimScripts aimScripts;
    public GameObject player;

    private void Start()
    {
        aimScripts = FindObjectOfType<AimScripts>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            var direction = (aimScripts.transform.position - transform.position).normalized;
            player.GetComponent<Rigidbody2D>().AddForce(direction * 30000 * Time.deltaTime);
        }
    }

}
