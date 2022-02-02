using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : IComparable
{
    public int weight; //가중치
    public string node1;
    public string node2;
    public Edge(int weight, string node1, string node2)
    {
        this.weight = weight;
        this.node1 = node1;
        this.node2 = node2;
    }

    public int CompareTo(object obj)
    {
        Edge edge = obj as Edge;
        return this.weight - edge.weight;
    }

    public string myData()
    {
        return this.weight + ":" + this.node1 + "," + this.node2;
    }
}

public class MST : MonoBehaviour
{
    Hashtable parent = new Hashtable(); //내 노드, 루트 노드
    Hashtable rank = new Hashtable(); 

    public void union(string node1, string node2)
    {
        string root1 = find(node1);
        string root2 = find(node2);

        //랭크가 더 높은 쪽을 루트로 삼음
        if ((int)rank[root1] > (int)rank[root2]) parent[root2] = root1;
        else
        {
            parent[root1] = root2;
            if ((int)rank[root1] == (int)rank[root2])
                rank[root2] = (int)rank[root2] + 1;
        }
    }

    public string find(string node)
    {
        if ((string)parent[node] != node) 
            parent[node] = find((string)parent[node]);
        return (string)parent[node];
    }

    public void makeSet(string node)
    {
        parent.Add(node, node);
        rank.Add(node, 0);
    }

    private void Start()
    {
        List<string> nodeList = new List<string>() { "A", "B" , "C" , "D" , "E" , "F" , "G" };
        List<Edge> edgeList = new List<Edge>();
        edgeList.Add(new Edge(29, "A", "B"));
        edgeList.Add(new Edge(10, "A", "F"));
        edgeList.Add(new Edge(16, "B", "C"));
        edgeList.Add(new Edge(15, "B", "G"));
        edgeList.Add(new Edge(18, "D", "G"));
        edgeList.Add(new Edge(12, "C", "D"));
        edgeList.Add(new Edge(25, "G", "E"));
        edgeList.Add(new Edge(22, "D", "E"));
        edgeList.Add(new Edge(27, "E", "F"));
        for (int i = 0; i < nodeList.Count; i++)
        {
            makeSet(nodeList[i]); //Union-Find에서 1)초기화 단계
        }
        edgeList.Sort();
        //for (int i = 0; i < edgeList.Count; i++)
        //{
        //    Debug.Log(edgeList[i].myData());
        //}
        List<Edge> mst = kruskalFunc(nodeList, edgeList);
        for (int i = 0; i < mst.Count; i++)
        {
            Debug.Log(mst[i].myData());
        }
    }

    public List<Edge> kruskalFunc(List<string> nodeList, List<Edge> edgeList)
    {
        Edge currentEdge;
        List<Edge> mst = new List<Edge>();
        for (int i = 0; i < edgeList.Count; i++)
        {
            currentEdge = edgeList[i];
            if (find(currentEdge.node1) != find(currentEdge.node2)) //사이클 방지
            {
                union(currentEdge.node1, currentEdge.node2);
                mst.Add(currentEdge);
            }
        }
        return mst;
    }
}