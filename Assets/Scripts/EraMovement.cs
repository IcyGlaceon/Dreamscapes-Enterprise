using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EraMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] BackgroundMovement background;
    [SerializeField] Image blackScreen;
    [SerializeField] float wait = 15;
    [SerializeField] float nextSceneTime = 3;
    [SerializeField] float fadeSpeed = 1;

    Vector2 movementTrans;
    [HideInInspector] public bool move = false;
    Color color = Color.black;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        movementTrans = transform.position;
        color.a = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(move)
        {
            wait -= Time.deltaTime;
            if (wait < 0)
            {
                if (blackScreen)
                {
                    blackScreen.gameObject.SetActive(true);
                    color.a += fadeSpeed * Time.deltaTime;
                    blackScreen.color = color;
                }
                spriteRenderer.flipX = true;
                movementTrans += Vector2.right * speed * Time.deltaTime;
                background.maxSpeed = 3;
                transform.position = movementTrans;
                nextSceneTime -= Time.deltaTime;
                if (nextSceneTime < 0)
                {
                    if (GameManager.currentLevel == 4) SceneManager.LoadSceneAsync("StartScreen");
                    if (GameManager.currentLevel != 0 && GameManager.currentLevel != 1) SceneManager.LoadSceneAsync("Level" + GameManager.currentLevel);
                    Destroy(gameObject);
                }
            }
        }
        else if(!move && background.speed == 0)
        {
            
        }
        else
        {
            movementTrans += Vector2.left * background.speed * Time.deltaTime;
            transform.position = movementTrans;
        }
    }
}
