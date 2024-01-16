using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text collectText;

    public static GameManager Instance;
    public static int currentCollectables = 0;
    public static bool pinkCharacter = false;
    public static bool blueCharacter = false;
    public static bool greenCharacter = false;
    public static bool redCharacter = false;
    public static bool yellowCharacter = false;
    public static bool cyanCharacter = false;
    public static int GainedCollectables = 0;
    public static int MaxCollectibles = 15;

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
        collectText.text = GainedCollectables.ToString();
    }
}
