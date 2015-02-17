using UnityEngine;
using System.Collections;

// Singleton class, serves as central command and control for the game as a whole
public class GameManager : MonoBehaviour {

    // Container arrays for prefabs, to be populated from inspector
    public GameObject[] hexprefabcontainer;
    public GameObject[] hexelprefabcontainer;

    // Static references to prefab arrays, for easy referencing
    public static GameObject[] hexprefabs;
    public static GameObject[] hexelprefabs;

    // Current window width and height for restoring size after fullscreen
    private int width = 640;
    private int height = 480;

    // Static references to controllers for easy cross-referencing
    public static GameController gamecontroller;
    public static BoardController boardcontroller;
    public static RowController rowcontroller;
    public static SaveController savecontroller;

    // Tracking reference for ensuring singleton status
    private static GameManager game;

    void Awake()
    {

        // Verify singleton status when GameObject is initialized
        if (game == null)
        {

            DontDestroyOnLoad(gameObject);
            game = this;

        }
        else if (game != this)
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

        // Create controllers
        gamecontroller = (GameController)gameObject.AddComponent("GameController");
        boardcontroller = (BoardController)gameObject.AddComponent("BoardController");
        rowcontroller = (RowController)gameObject.AddComponent("RowController");
        savecontroller = (SaveController)gameObject.AddComponent("SaveController");

        // Start the game
        if (savecontroller.IsGameSaved())
        {

            gamecontroller.LoadGame();

        }
        else
        {

            gamecontroller.NewGame();

        }

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
