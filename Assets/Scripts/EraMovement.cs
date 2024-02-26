using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// SCENE TRANSITIONS IN THIS SCRIPT!
public class EraMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] BackgroundMovement background;
    [SerializeField] Image blackScreen;
    [SerializeField] float wait = 15;
    [SerializeField] float nextSceneTime = 3;
    [SerializeField] float moustacheTimer = 10;
    [SerializeField] float fadeSpeed = 1;
    [SerializeField] bool forward = false;
    [SerializeField] GameObject levelTxt;

    Vector2 movementTrans;
    [HideInInspector] public bool move = false;
    Color color = Color.black;
    SpriteRenderer spriteRenderer;

    // Setting variables to defaults
    void Start()
    {
        movementTrans = transform.position;
        color.a = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // if the player is stopped it causes Era to stop moving for a specified time and than transition to the next scene
        if(move)
        {
            // if the player got the secret with no dreams and got the moustache it goes to the secret credits. Different timer so it looks good timing wise
            if(GameManager.moustache)
            {
                moustacheTimer -= Time.deltaTime;
                if(moustacheTimer < 0)
                {
                    if (GameManager.currentLevel == 4 && GameManager.moustache) SceneManager.LoadSceneAsync("CreditsMustache");
                }
            }
            // After a specified time the screne fades to black, Era "runs away", and it transitions to the next scene
            wait -= Time.deltaTime;
            if (wait < 0)
            {
                // Changes the alpha of a see through image to fade to black
                if (blackScreen)
                {
                    blackScreen.gameObject.SetActive(true);
                    color.a += fadeSpeed * Time.deltaTime;
                    blackScreen.color = color;
                    if(levelTxt) levelTxt.SetActive(true);
                }
                // Era turns and runs away from the player
                spriteRenderer.flipX = true;
                movementTrans += Vector2.right * speed * Time.deltaTime;
                background.maxSpeed = 3;
                transform.position = movementTrans;

                // This transitions scenes. It gets the current level variable from player stop
                nextSceneTime -= Time.deltaTime;
                if (nextSceneTime < 0)
                {
                    if (GameManager.currentLevel == 4) SceneManager.LoadSceneAsync("Credits");
                    if (GameManager.currentLevel != 0 && GameManager.currentLevel != 1) SceneManager.LoadSceneAsync("Level" + GameManager.currentLevel);
                    Destroy(gameObject);
                }
            }
        }
        // This is for the Era sprites in the beginning of each level. This allows them to "run away"
        else if(forward)
        {
            movementTrans += Vector2.right * speed * Time.deltaTime;
            transform.position = movementTrans;
            nextSceneTime -= Time.deltaTime;
            if(nextSceneTime < 0) Destroy(gameObject);
        }
        // if the player isn't stopped the Era sprites keep moving with the rest of the world
        else
        {
            movementTrans += Vector2.left * background.speed * Time.deltaTime;
            transform.position = movementTrans;
        }
    }
}
