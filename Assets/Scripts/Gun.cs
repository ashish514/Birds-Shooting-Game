using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour
{
    public GameObject Ball;
    private AimScripts aimScripts;
    public AudioSource FireMusic;
    public GameObject WinMenu;
    public GameObject LossMenu;
    private LineRenderer lineRenderer;
    private int Bullet;
    public AudioSource WinMenuMusic;
    public AudioSource LossMenuMusic;
    private Touch touch;
    private BulletGenerator bulletGenerator;
    private int soundPlay = 1;
    private int birdsSize;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        bulletGenerator = FindObjectOfType<BulletGenerator>();
        aimScripts = FindObjectOfType<AimScripts>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, transform.position);


    }

    void Update()
    {

        birdsSize = GameObject.FindGameObjectsWithTag("Birds").Length;

        // Touch Input
        if (Input.touchCount == 1)
        {
            // AimScript to move 
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                var touchPosition = touch.position;
                var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
                var offset = new Vector2(touchPosition.x - screenPoint.x, touchPosition.y - screenPoint.y);
                var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg; // angle to rotate object return
                if (aimScripts.GetComponent<SpriteRenderer>().sprite == aimScripts.AimSprite && Time.timeScale == 1)
                {
                    transform.rotation = Quaternion.Euler(0, 0, angle);
                }

            }
            // Fire to gun
            if (touch.phase == TouchPhase.Ended)
            {
                if (WinMenu.activeSelf == false && LossMenu.activeSelf == false && bulletGenerator.NumberofBullet > 0 && aimScripts.GetComponent<SpriteRenderer>().sprite == aimScripts.AimSprite && Time.timeScale == 1 && Input.touchCount == 1)
                {
                    FireMusic.Play();
                    Fire();
                }
            }
        }

        // Computer function
        if (WinMenu.activeSelf == false && LossMenu.activeSelf == false)
        {
            lineRenderer.SetPosition(1, aimScripts.transform.position);
            var mouse = Input.mousePosition; // Mouse Position
            var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
            var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
            var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg; // angle to rotate object return
            if (aimScripts.GetComponent<SpriteRenderer>().sprite == aimScripts.AimSprite && Time.timeScale == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }

        if ((bulletGenerator.NumberofBullet == 0) && birdsSize > 0 || birdsSize == 0)
        {
            StartCoroutine(wait());
        }
    }
    // Fire to function
    void Fire()
    {
        bulletGenerator.Deleted();
        var direction = (aimScripts.transform.position - transform.position).normalized;
        GameObject gameObject = (GameObject)Instantiate(Ball, transform.position,Quaternion.identity);
        Destroy(gameObject, 4f);
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction * 80000 * Time.deltaTime);
    }                                                               // 110000
    // loss menu show
    IEnumerator wait()
    {
        yield return new WaitForSeconds(4f);

        if ((bulletGenerator.NumberofBullet < 1) && birdsSize > 0)
        {
            if (soundPlay == 1)
            {
                LossMenuMusic.Play();
                soundPlay = 2;
            }
            aimScripts.GetComponent<SpriteRenderer>().sprite = aimScripts.sprite;
            aimScripts.enabled = false;
            LossMenu.SetActive(true);
        }
        else if ((birdsSize == 0))
        {
            if (soundPlay == 1)
            {
                WinMenuMusic.Play();
                soundPlay = 2;
            }
            aimScripts.GetComponent<SpriteRenderer>().sprite = aimScripts.sprite;
            aimScripts.enabled = false;
            WinMenu.SetActive(true);
            int CurrentLevel = SceneManager.GetActiveScene().buildIndex;
            if (CurrentLevel > PlayerPrefs.GetInt("LevelCompleted"))
            {
                PlayerPrefs.SetInt("LevelCompleted", CurrentLevel);
            }
        }

    }

}
