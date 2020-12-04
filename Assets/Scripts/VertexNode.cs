using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexNode : MonoBehaviour
{
    private int x;
    private VertexList vertexList;


    public void SetVertex(VertexList _vertexList,int _x)
    {
        vertexList = _vertexList;
        x = _x;
    }

    public void ChooseVertex()
    {
        vertexList.CallNode(x);
    }

}
