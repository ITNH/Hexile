using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour
{

    void Start(){

        UIController.UpdateUI(
            GameManager.gamecontroller.highscore,
            GameManager.gamecontroller.score,
            GameManager.gamecontroller.lines,
            GameManager.gamecontroller.level);

    }

}
