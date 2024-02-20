using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static bool pinkCharacter = false;
    public static bool blueCharacter = false;
    public static bool greenCharacter = false;
    public static bool redCharacter = false;
    public static bool yellowCharacter = false;
    public static bool cyanCharacter = false;
    public static int GainedCollectables = 9;
    public static int MaxCollectibles = 9;
    public static int currentLevel = 0;
    public static AudioSource collectSound;
    public static bool moustache = false;

    private void Awake()
    {

        if (Instance != null)
        {
            Instance = this;
            Destroy(gameObject);
            return;
        }
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
