﻿using UnityEngine;

public class ContinueButton : MonoBehaviour
{

    /*
    void OnMouseEnter()
    {

        if (GameManager.savecontroller.IsGameSaved())
        {

            gameObject.renderer.enabled = true;

        }

    }

    void OnMouseExit()
    {

        gameObject.renderer.enabled = false;

    }
    */

    void OnMouseDown()
    {

        GameManager.soundcontroller.PlaySound(3);

        if (GameManager.savecontroller.IsGameSaved())
        {

            Application.LoadLevel("Game");

            GameManager.gamecontroller.LoadGame();

        }

    }

}