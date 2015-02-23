using UnityEngine;

// Controller for detecting, manipulating, and removing rows of hexes
public class RowController : MonoBehaviour
{

    // Returns an array of bools indicating which rows are complete
    public bool[] CheckForRows()
    {

        bool[] rows = new bool[15];

        for (int row = 0; row < 15; row++)
        {

            bool thisrow = true;

            for (int col = 0; col < 15; col++)
            {

                if (!GameManager.boardcontroller.IsHex(col, row))
                {

                    thisrow = false;
                    col = 15;

                }

            }

            rows[row] = thisrow;

        }

        return rows;

    }

    // Makes the specified rows invisible
    public void HideRows(bool[] rows)
    {

        for (int row = 0; row < rows.Length; row++)
        {

            if (rows[row])
            {

                for (int col = 0; col < 15; col++)
                {

                    GameManager.boardcontroller.hideHex(col, row);

                }

            }

        }

    }

    // Makes the specified rows visible
    public void ShowRows(bool[] rows)
    {

        for (int row = 0; row < rows.Length; row++)
        {

            if (rows[row])
            {

                for (int col = 0; col < 15; col++)
                {

                    GameManager.boardcontroller.showHex(col, row);

                }

            }

        }

    }

    // Deletes the specified rows
    public void ClearRows(bool[] rows)
    {

        for (int row = 0; row < rows.Length; row++)
        {

            if (rows[row])
            {

                for (int col = 0; col < 15; col++)
                {

                    GameManager.boardcontroller.RemoveHex(col, row);

                }

            }

        }

    }

    // Drops existing hexes to fill the specified rows
    public void DropRows(bool[] rows)
    {

        int counter = 0;

        for (int row = 0; row < rows.Length; row++)
        {

            if (rows[row])
                counter++;

            for (int drops = 0; drops < counter; drops++)
            {

                for (int col = 0; col < 15; col++)
                {

                    GameManager.boardcontroller.MoveHex(col, row - drops, col, row - drops - 1);

                }

            }

        }

    }

    public void FillRows(bool[] rows, int color)
    {

        for (int row = 0; row < rows.Length; row++)
        {

            if (rows[row])
            {

                for (int col = 0; col < 15; col++)
                {

                    GameManager.boardcontroller.RemoveHex(col, row);
                    GameManager.boardcontroller.AddHex(col, row, color);

                }

            }

        }

    }

}
