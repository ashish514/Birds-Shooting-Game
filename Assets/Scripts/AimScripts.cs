using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScripts : MonoBehaviour
{

    public Sprite sprite;
    public Sprite AimSprite;

    void Update()
    {
        if (Time.timeScale == 1)
        {
        transform.position = new Vector3
           (Camera.main.ScreenToWorldPoint(Input.mousePosition).x + -1f,
           Camera.main.ScreenToWorldPoint(Input.mousePosition).y+1f,
           transform.position.z);
        }

        if (transform.position.x > 7.32 || transform.position.x < -7.32 || transform.position.y > 4.70 || transform.position.y < -4.185)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }
        else if (transform.position.x < 7.32 || transform.position.x > -7.32 || transform.position.y < 4.70 || transform.position.y > -4.185)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = AimSprite;
        }
        

    }
}
