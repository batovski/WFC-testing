using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VertexList : MonoBehaviour
{
    public Transform[] list;
    public GameObject[] buttonList;
    public Grid grid;

    public void Start()
    {
        CreateList();
    }

    public void CreateList()
    {
        for (int x = 0; x < list.Length; x++)
        {
            buttonList[x].GetComponent<VertexNode>().SetVertex(this, x);
            buttonList[x].GetComponent<Image>().sprite = list[x].GetComponent<Image>().sprite;
        }
    }

    public void CallNode(int x)
    {
        grid.SetNodeProperty(list[x].GetComponent<Vertex>(), list[x].GetComponent<Image>());
    }

}
