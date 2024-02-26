using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    // This class exists in every scene and transfers in between them, keeping all the data.
    // Variables must be public static so every class can access them
    public static GameManager Instance;
    public static bool pinkCharacter = false;
    public static bool blueCharacter = false;
    public static bool greenCharacter = false;
    public static bool redCharacter = false;
    public static bool yellowCharacter = false;
    public static bool cyanCharacter = false;
    public static int GainedCollectables = 0;
    public static int MaxCollectibles = 9;
    public static int currentLevel = 0;
    public static AudioSource collectSound;
    public static bool moustache = false;

    private void Awake()
    {
        // Keeps the game manager data in each scene
        if (Instance != null)
        {
            Instance = this;
            Destroy(gameObject);
            return;
        }
        // This is how we store the collection sound
        collectSound = GetComponent<AudioSource>();

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
