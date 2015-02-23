using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

public class UIController : MonoBehaviour{

    private static List<GameObject> highscoredigits = new List<GameObject>();
    private static List<GameObject> scoredigits = new List<GameObject>();
    private static List<GameObject> linesdigits = new List<GameObject>();
    private static List<GameObject> leveldigits = new List<GameObject>();
    private static GameObject hexelpreview = new GameObject();

    public static void UpdateUI(int highscore, int score, int lines, int level)
    {

        highscoredigits = DrawNumber(273, 207, highscore, highscoredigits);

        scoredigits = DrawNumber(273, 185, score, scoredigits);

        linesdigits = DrawNumber(273, 163, lines, linesdigits);

        leveldigits = DrawNumber(238, 123, level, leveldigits);

        Destroy(hexelpreview);

        hexelpreview = null;

    }

    public static void UpdateUI(int highscore, int score, int lines, int level, int nexthexel)
    {

        highscoredigits = DrawNumber(273, 207, highscore, highscoredigits);

        scoredigits = DrawNumber(273, 185, score, scoredigits);

        linesdigits = DrawNumber(273, 163, lines, linesdigits);

        leveldigits = DrawNumber(238, 123, level, leveldigits);

        Destroy(hexelpreview);

        hexelpreview = Instantiate(GameManager.hexelpreviews[nexthexel], new
                    Vector3(250, 65), Quaternion.identity) as GameObject;

    }

    private static List<GameObject> DrawNumber(int xpos, int ypos, int number,
        List<GameObject> digitcontainer)
    {

        foreach (GameObject digit in digitcontainer)
        {

            Destroy(digit);

        }

        leveldigits.Clear();

        foreach (char digit in number.ToString().Reverse<char>())
        {

            if (digit == '1')
            {

                xpos -= 2;

                digitcontainer.Add((GameObject)Instantiate(GameManager.numbers[1],
                    new Vector3(xpos, ypos), Quaternion.identity));

            }
            else
            {

                xpos -= 5;

                digitcontainer.Add((GameObject)Instantiate(GameManager.numbers[
                    (int)Char.GetNumericValue(digit)
                    ], new Vector3(xpos, ypos), Quaternion.identity));

            }

        }

        return digitcontainer;

    }
}
