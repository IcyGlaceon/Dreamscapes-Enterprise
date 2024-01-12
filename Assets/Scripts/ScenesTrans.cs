using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesTrans : MonoBehaviour
{
    public static ScenesTrans Instance;

    public static int currentCollectables = 0;
    public static bool pinkCharacter = false;
    public static bool blueCharacter = false;
    public static bool greenCharacter = false;
    public static bool redCharacter = false;
    public static bool yellowCharacter = false;
    public static bool cyanCharacter = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

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
