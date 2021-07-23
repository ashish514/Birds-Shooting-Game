using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public AudioSource BrickMusic;
    public AudioSource BirdKilledMusic;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider)
        {
            BrickMusic.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Birds")
        {
            BirdKilledMusic.Play();
        }
    }

}
