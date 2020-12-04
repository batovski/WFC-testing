using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex:MonoBehaviour
{

    //Pointers to other vertices = edges
    public Vertex Top;
    public Vertex Right;
    public Vertex Bot;
    public Vertex Left;

    //Types of connections betwen the vertices (CONSTRAINTS)
    public ConnectionType TopType;
    public ConnectionType RightType;
    public ConnectionType BotType;
    public ConnectionType LeftType;

    public bool CheckTopEdge()
    {
        if (Top != null)
            return true;
        else
        {
            if (TopType == ConnectionType.none)
                return true;
        }
        return false;

    }

    public bool CheckRightEdge()
    {
        if (Right != null)
            return true;
        else
        {
            if (RightType == ConnectionType.none)
                return true;
        }
        return false;
    }

    public bool CheckBotEdge()
    {
        if (Bot!= null)
            return true;
        else
        {
            if (BotType == ConnectionType.none)
                return true;
        }
        return false;
    }

    public bool CheckLeftEdge()
    {
        if (Left != null)
            return true;
        else
        {
            if (LeftType == ConnectionType.none)
                return true;
        }
        return false;
    }
};
    public enum ConnectionType
    {
        none = 0,
        floor,
        wall,
    };
