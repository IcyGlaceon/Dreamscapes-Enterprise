using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EraMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] BackgroundMovement background;
    [SerializeField] float wait = 15;
    [SerializeField] float nextSceneTime = 3;

    Vector2 movementTrans;
    [HideInInspector] public bool move = false;

    void Start()
    {
        movementTrans = transform.position;
    }

    void Update()
    {
        if(move)
        {
            wait -= Time.deltaTime;
            if (wait < 0)
            {
                movementTrans += Vector2.right * speed * Time.deltaTime;
                background.maxSpeed = 3;
                transform.position = movementTrans;
                nextSceneTime -= Time.deltaTime;
                if (nextSceneTime < 0)
                {
                    if (GameManager.currentLevel != 0 && GameManager.currentLevel != 1) SceneManager.LoadSceneAsync("Level" + GameManager.currentLevel); ;
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            movementTrans += Vector2.left * background.speed * Time.deltaTime;
            transform.position = movementTrans;
        }
    }
}
