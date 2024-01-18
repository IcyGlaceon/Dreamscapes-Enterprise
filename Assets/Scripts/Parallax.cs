using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    float singleTextureWidth;

    void Start()
    {
        SetupTexture();
        moveSpeed = -moveSpeed;
    }

    void SetupTexture()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        singleTextureWidth = sprite.texture.width / sprite.pixelsPerUnit;
    }

    void Scroll()
    {
        float delta = moveSpeed * Time.deltaTime;
        transform.position += new Vector3(delta, 0, 0);
    }

    void CheckReset()
    {
        if ((Mathf.Abs(transform.position.x) - singleTextureWidth) > 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }
    private void Update()
    {
        Scroll();
        CheckReset();
    }
}
