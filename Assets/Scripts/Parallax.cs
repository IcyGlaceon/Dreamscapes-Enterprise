using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Movement movement;
    [SerializeField] BackgroundMovement BGMovement;
    [SerializeField] float SlowdownAmount = 0.5f;

    float singleTextureWidth;
    float originalSpeed;
    float slowSpeed;
    float backwardsSpeed;

    void Start()
    {
        SetupTexture();
        moveSpeed = -moveSpeed;
        originalSpeed = moveSpeed;
        slowSpeed = moveSpeed * SlowdownAmount;
        backwardsSpeed = moveSpeed * -1.3f;
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

        // if the parallax isint working on bounceback, uncomment this and applcation.quit, build the game, bounce on the level that is broken and it usually fixes it
		//var objects = FindObjectsByType<BackgroundMovement>(FindObjectsSortMode.InstanceID);
		//foreach (var thing in objects)
		//{
		//	string destination = Application.persistentDataPath + "/" + gameObject.name + ".log";
		//	FileStream file;

		//	if (File.Exists(destination)) file = File.OpenWrite(destination);
		//	else file = File.Create(destination);
		//	string data_to_store = JsonUtility.ToJson(new GAData(BGMovement.bouncedBack, thing.bouncedBack), true);
		//	using (StreamWriter writer = new StreamWriter(file))
		//	{
		//		writer.Write(data_to_store);
		//	}
		//	file.Close();
		//}

		if (BGMovement.slow == false)
        {
            if (BGMovement.bouncedBack == true)
            {
                //Application.Quit();
                moveSpeed = backwardsSpeed;
			}
            else
            {
                if (BGMovement.bouncedBack == false && moveSpeed > originalSpeed)
                {
                    moveSpeed += (originalSpeed / 60);
                }
                else
                {
                    moveSpeed = originalSpeed;
                }
                
            }
        }
        else
        {
            moveSpeed = slowSpeed;
        }

        if(BGMovement.speed == 0)
        {
            moveSpeed = 0;
        }
        else if (BGMovement.speed != 0 && moveSpeed == 0)
        {
            moveSpeed = originalSpeed;
        }
    }
}

// this is needed for the file logging. dont question it
public class GAData
{
    public bool bounced;
    public bool findBounce;

    public GAData(bool bounced, bool findBounce) 
    { 
        this.bounced = bounced;
        this.findBounce = findBounce;
    }
}