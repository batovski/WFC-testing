using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Grid mainGrid;


    public Node Top;
    public Node Right;
    public Node Bot;
    public Node Left;

    //Types of connections betwen the vertices (CONSTRAINTS)
    public ConnectionType TopType = ConnectionType.none;
    public ConnectionType RightType = ConnectionType.none;
    public ConnectionType BotType = ConnectionType.none; 
    public ConnectionType LeftType = ConnectionType.none;

    private int _x;
    private int _y;
    private bool _empty = true;

    public void SetPosition(int x, int y)
    {
        _x = x;
        _y = y;
    }
    public void Click()
    {
        mainGrid.OpenList();
        mainGrid.SetNode(_x, _y);
    }

    public bool IsEmpty()
    {
        return _empty;
    }

    public void Empty(bool empty)
    {
        _empty = empty;
    }
}
