using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid: MonoBehaviour
{
    [SerializeField] GameObject VertexList;
    [SerializeField]
    private Transform Node;

    public int _width;
    public int _height;
    public float _nodeSize;
    public Vector3 offSet;

    private Node[,] gridArray;
    private int currentNodeX;
    private int currentNodeY;

    public void Start()
    {
        CreateGrid(_width, _height, _nodeSize);
    }
    private void CreateGrid(int width,int height,float nodeSize)
    {
        _width = width;
        _height = height;
        _nodeSize = nodeSize;

        gridArray = new Node[width, height];

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                CreateNode(GetWorldPosition(x, y),x,y);
            }
        }
        CloseList();
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * _nodeSize + transform.position+offSet;
    }

    public void CreateNode(Vector3 position,int x,int y)
    {
        Transform node = Instantiate(Node);
        node.SetParent(gameObject.transform);
        node.transform.position = position;

        gridArray[x, y] = node.GetComponent<Node>();
        gridArray[x, y].mainGrid = this;
        gridArray[x, y].SetPosition(x, y);
    }

    private Node GetNode(int x, int y)
    {
        if(x >= 0 && x < _width)
        {
            if (y >= 0 && y < _height && !gridArray[x,y].IsEmpty())

                return gridArray[x, y];
        }
        return null;
    }

    public void SetNode(int x, int y)
    {
        currentNodeX = x;
        currentNodeY = y;
    }

    public void OpenList()
    {
        VertexList.SetActive(true);
    }

    public void CloseList()
    {
        VertexList.SetActive(false);
    }

    public void SetNodeProperty(Vertex vertex, Image image)
    {
        //Close selection menu:
        CloseList();

        //Set Type of connections to the current grid:
        gridArray[currentNodeX, currentNodeY].TopType = vertex.TopType;
        gridArray[currentNodeX, currentNodeY].RightType = vertex.RightType;
        gridArray[currentNodeX, currentNodeY].BotType = vertex.BotType;
        gridArray[currentNodeX, currentNodeY].LeftType = vertex.LeftType;

        //State that it is not empty node anymore:
        gridArray[currentNodeX, currentNodeY].Empty(false);

    //Set pointers of the nodes:

        //Top
        if (gridArray[currentNodeX, currentNodeY].TopType != ConnectionType.none)
            gridArray[currentNodeX, currentNodeY].Top = GetNode(currentNodeX, currentNodeY + 1);

        //Right
        if (gridArray[currentNodeX, currentNodeY].RightType != ConnectionType.none)
            gridArray[currentNodeX, currentNodeY].Right = GetNode(currentNodeX+1, currentNodeY);

        //Bot
        if (gridArray[currentNodeX, currentNodeY].BotType != ConnectionType.none)
            gridArray[currentNodeX, currentNodeY].Bot = GetNode(currentNodeX, currentNodeY - 1);

        //Left
        if (gridArray[currentNodeX, currentNodeY].LeftType != ConnectionType.none)
            gridArray[currentNodeX, currentNodeY].Left = GetNode(currentNodeX-1, currentNodeY);

    //Connected other vertice/ nodes to this if possible

        //Top
        if(gridArray[currentNodeX, currentNodeY].Top!= null)
        {
            if (GetNode(currentNodeX, currentNodeY + 1).BotType == gridArray[currentNodeX, currentNodeY].TopType)
                GetNode(currentNodeX, currentNodeY + 1).Bot = gridArray[currentNodeX,currentNodeY];
        }

        //Right
        if (gridArray[currentNodeX, currentNodeY].Right != null)
        {
            if (GetNode(currentNodeX + 1, currentNodeY).LeftType == gridArray[currentNodeX, currentNodeY].RightType)
                GetNode(currentNodeX + 1, currentNodeY).Left = gridArray[currentNodeX, currentNodeY];
        }

        //Bot
        if (gridArray[currentNodeX, currentNodeY].Bot != null)
        {
            if (GetNode(currentNodeX, currentNodeY - 1).TopType == gridArray[currentNodeX, currentNodeY].BotType)
                GetNode(currentNodeX, currentNodeY - 1).Top = gridArray[currentNodeX, currentNodeY];
        }

        //Left
        if (gridArray[currentNodeX, currentNodeY].Left != null)
        {
            if (GetNode(currentNodeX - 1, currentNodeY).RightType == gridArray[currentNodeX, currentNodeY].LeftType)
                GetNode(currentNodeX - 1, currentNodeY).Right = gridArray[currentNodeX, currentNodeY];
        }

        //Set image to this node:
        gridArray[currentNodeX, currentNodeY].GetComponent<Image>().sprite = image.sprite;
    }

    public Node[,] GetGrid()
    {
        return gridArray;
    }
}
