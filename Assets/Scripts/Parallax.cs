using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    /*
     * ------------VERY IMPORTANT - MUST DO THIS FIRST------------
     * If you are adding a new background layer, in the editor you must
     *      1) Change the images Mesh Type to Full-rect
     *      2) Change the images wrap mode to Repeat
     *      3) Change the images Filter type to Point (no filter)
     * Then on the actual object within the level
     *      1) Change the Draw mode to tiled
     *      2) Multpily the width by 3
     *      3) Change the order in layer to be were you want the layer to be located
     */

    /*
     * Move speed = how fast the layer will move
     * Movement = the Movement script on the player
     * BGMovement = the BackgroundMovement script on the Tilemaps object
     * SlowdownAmount = THIS SHOULD NOT CHANGE! - how much to lsow the background layer when the player is in a slow zone
     */
    [SerializeField] float moveSpeed;
    [SerializeField] Movement movement;
    [SerializeField] BackgroundMovement BGMovement;
    [SerializeField] float SlowdownAmount = 0.5f;

    /*
     * singleTextureWidth = how wide the layer is
     * originalSpeed = gets set to how fast the layer goes when nothing is effecting it
     * slowSpeed = gets set to how fast the layer will move when the player is in a slow zon (moveSpeed * SlowdownAmount)
     * backwardsSpeed = gets set to how fast the layer will move when the player is bounced back to maintain the parallax affect
     */

    float singleTextureWidth;
    float originalSpeed;
    float slowSpeed;
    float backwardsSpeed;

    void Start()
    {
        SetupTexture();

        // flips the movment speed bc it needs to be negatvie to go the proper way
        moveSpeed = -moveSpeed;

        originalSpeed = moveSpeed;
        slowSpeed = moveSpeed * SlowdownAmount;
        backwardsSpeed = moveSpeed * -1.3f;
    }

    // Sets singleTextureWidth
    void SetupTexture()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        singleTextureWidth = sprite.texture.width / sprite.pixelsPerUnit;
    }

    // Allows the background to coninously repeat with the parallax affect
    void Scroll()
    {
        float delta = moveSpeed * Time.deltaTime;
        transform.position += new Vector3(delta, 0, 0);
    }

    // Checks to see if the texture has reached its end and needs to be repeated
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

        // Checks to see if player is in a slow zone
		if (BGMovement.slow == false)
        {
            // Checks to see if the player has been bounced back
            if (BGMovement.bouncedBack == true)
            {
                //Application.Quit();

                // Sets the background to its backwardsSpeed
                moveSpeed = backwardsSpeed;
			}
            else
            {
                // Checks to see if the player is currently bounced back and if the current speed is more than the original speed
                if (BGMovement.bouncedBack == false && moveSpeed > originalSpeed)
                {
                    // Gradually adds back speed until the background is at its original speed
                    moveSpeed += (originalSpeed / 60);
                }
                else
                {
                    // Sets the move speed to the original speed
                    moveSpeed = originalSpeed;
                }
                
            }
        }
        else
        {
            // Sets the moveSpeed to the slowSpeed while the player is in a slow zone
            moveSpeed = slowSpeed;
        }

        // Checks if the BGMovements speed is 0
        if(BGMovement.speed == 0)
        {
            // Sets the moveSpeed to 0, so that the background doesn't move while the world isn't moving
            moveSpeed = 0;
        }
        // Checks to see that the world is moving and the background isn't 
        else if (BGMovement.speed != 0 && moveSpeed == 0)
        {
            // Sets the moveSpeed to the originalSpeed
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