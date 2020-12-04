using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verification : MonoBehaviour
{
    public Node[,] verticies;
    public Grid grid;

    private int _numRooms;
    private int _pairDoors;

    private void Start()
    {
        grid = GetComponent<Grid>();
    }

    public bool CheckTheSolution()
    {
        _numRooms = 0;
        _pairDoors = 0;

        verticies = grid.GetGrid();
        //Go for every vertex and check the edges
        for (int x = 0; x < grid._width; x++)
        {
            for(int y = 0; y < grid._height; y++)
            {
                if (verticies[x, y].Top == null && verticies[x, y].TopType != ConnectionType.none)
                {
                    return false;
                }
                if (verticies[x, y].Right == null && verticies[x, y].RightType != ConnectionType.none)
                {
                    return false;
                }
                if (verticies[x, y].Bot == null && verticies[x, y].BotType != ConnectionType.none)
                {
                    return false;
                }
                if (verticies[x, y].Left == null && verticies[x, y].LeftType != ConnectionType.none)
                {
                    return false;
                }

                //Check for the corner verticies:
                //    |
                //  - *
                //
                if (verticies[x, y].LeftType == ConnectionType.wall && verticies[x, y].TopType == ConnectionType.wall &&
                    verticies[x, y].RightType == ConnectionType.floor) // this is a door corner
                {
                    //Check ajecent corner:
                    if (verticies[x + 1, y].RightType == ConnectionType.wall && verticies[x + 1, y].TopType == ConnectionType.wall &&
                    verticies[x + 1, y].LeftType == ConnectionType.floor)
                        _pairDoors++;
                    else if (verticies[x, y - 2].LeftType == ConnectionType.wall && verticies[x, y - 2].BotType == ConnectionType.wall &&
                    verticies[x, y - 2].RightType == ConnectionType.floor)
                        _pairDoors++;

                    _numRooms++;

                }

                //    |
                //    *-
                //
                else if (verticies[x, y].RightType == ConnectionType.wall && verticies[x, y].TopType == ConnectionType.wall &&
                    verticies[x, y].LeftType == ConnectionType.floor)
                {
                    //Check ajecent corner:
                    if (verticies[x - 1, y].LeftType == ConnectionType.wall && verticies[x - 1, y].TopType == ConnectionType.wall &&
                    verticies[x - 1, y].RightType == ConnectionType.floor)
                        _pairDoors++;
                    else if (verticies[x, y - 2].RightType == ConnectionType.wall && verticies[x, y - 2].BotType == ConnectionType.wall &&
                    verticies[x, y - 2].LeftType == ConnectionType.floor)
                        _pairDoors++;

                    _numRooms++;
                }

                //      
                //    - *
                //      |
                else if (verticies[x, y].LeftType == ConnectionType.wall && verticies[x, y].BotType == ConnectionType.wall &&
                    verticies[x, y].RightType == ConnectionType.floor)
                {
                    //Check ajecent corner:
                    if (verticies[x, y + 2].LeftType == ConnectionType.wall && verticies[x, y + 1].TopType == ConnectionType.wall &&
                    verticies[x, y + 2].RightType == ConnectionType.floor)
                        _pairDoors++;
                    else if (verticies[x + 1, y].RightType == ConnectionType.wall && verticies[x + 1, y].BotType == ConnectionType.wall &&
                    verticies[x + 1, y].LeftType == ConnectionType.floor)
                        _pairDoors++;

                    _numRooms++;
                }

                //      
                //      *-
                //      |
                else if (verticies[x, y].RightType == ConnectionType.wall && verticies[x, y].BotType == ConnectionType.wall &&
                    verticies[x, y].LeftType == ConnectionType.floor)
                {
                    //Check ajecent corner:
                    if (verticies[x, y + 2].RightType == ConnectionType.wall && verticies[x, y + 1].TopType == ConnectionType.wall &&
                    verticies[x, y + 2].LeftType == ConnectionType.floor)
                        _pairDoors++;
                    else if (verticies[x-1, y].LeftType == ConnectionType.wall && verticies[x-1, y].BotType == ConnectionType.wall &&
                    verticies[x-1, y].RightType == ConnectionType.floor)
                        _numRooms++;
                }
            }
        }
        return true;
    }

    public void Verify()
    {
        //Check if all verices match
        bool result = CheckTheSolution();

        //Calculate the result of the total possible rooms:
        int NumberOfRooms;
        if (_pairDoors!= 0)
            NumberOfRooms = (_numRooms - _pairDoors) + (_pairDoors / 2);
        else
        {
            NumberOfRooms = _numRooms;
        }
        Debug.Log(NumberOfRooms);
        GetComponent<Output>().SetOutput(result);
    }
}

