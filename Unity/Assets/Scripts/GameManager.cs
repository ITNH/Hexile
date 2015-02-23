using UnityEngine;

// Singleton controller in charge of managing the game window, audio, and static references
public class GameManager : MonoBehaviour {

    // Container arrays for objects, to be populated from inspector
    public GameObject[] hexprefabcontainer;
    public GameObject[] hexelprefabcontainer;
    public AudioClip[] soundcontainer;
    public GameObject[] numbercontainer;
    public GameObject[] hexelpreviewcontainer;

    // Static references to object arrays, for easy referencing
    public static GameObject[] hexprefabs;
    public static GameObject[] hexelprefabs;
    public static AudioClip[] sounds;
    public static GameObject[] numbers;
    public static GameObject[] hexelpreviews;

    // Current window width and height for restoring size after fullscreen
    private int width = 640;
    private int height = 480;

    // Static references to controllers for easy cross-referencing
    public static GameController gamecontroller;
    public static BoardController boardcontroller;
    public static RowController rowcontroller;
    public static SaveController savecontroller;
    public static SoundController soundcontroller;

    // Static self-reference for singleton tracking and audio access
    public static GameManager gamemanager { get; private set; }

    void Awake()
    {

        // Verify singleton status when GameObject is initialized
        if (gamemanager == null)
        {

            DontDestroyOnLoad(gameObject);
            gamemanager = this;

        }
        else if (gamemanager != this)
        {

            Destroy(gameObject);

        }

    }

    void Start()
    {

        // Store current window size for restoration after fullscreen
        // will remain at default (640x480) if already fullscreen
        if (!Screen.fullScreen)
        {

            width = Screen.width;
            height = Screen.height;

        }

        // Set static prefab array references
        hexprefabs = hexprefabcontainer;
        hexelprefabs = hexelprefabcontainer;
        sounds = soundcontainer;
        numbers = numbercontainer;
        hexelpreviews = hexelpreviewcontainer;

        // Create controllers
        gamecontroller = (GameController)gameObject.AddComponent<GameController>();
        boardcontroller = (BoardController)gameObject.AddComponent<BoardController>();
        rowcontroller = (RowController)gameObject.AddComponent<RowController>();
        savecontroller = (SaveController)gameObject.AddComponent<SaveController>();
        soundcontroller = (SoundController)gameObject.AddComponent<SoundController>();

    }

    void Update()
    {

        // Restore to window if F11 is pressed during fullscreen
        if (Input.GetButtonDown("Fullscreen") && Screen.fullScreen)
        {

            Screen.SetResolution(width, height, false);

        }

        // Store current size and go fullscreen if F11 is pressed while windowed
        if (Input.GetButtonDown("Fullscreen") && !Screen.fullScreen)
        {

            width = Screen.width;
            height = Screen.height;
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);

        }
        
        // Exit the game if escape or backspace is pressed
        if (Input.GetButton("Back"))
        {

            Application.Quit();

        }
        
    }

}
