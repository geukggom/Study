using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

public class MinHeap
{
    public List<Edge> minHeap = new List<Edge>();

    public bool addHeap(Edge data)
    {
        if (minHeap.Count == 0)
        {
            minHeap = new List<Edge>();
            minHeap.Add(null); //0번 인덱스는 사용하지 않음(계산하기 편하게 하기 위해)
            minHeap.Add(data); //1번 인덱스부터 데이터를 넣음.
        }
        else
        {
            minHeap.Add(data);
            int parent_i, insert_i = minHeap.Count - 1; //추가
            while (is_up(insert_i)) //insert_i를 부모노드와 크기 비교
            {
                parent_i = insert_i / 2;
                swap(minHeap, insert_i, parent_i); //두 데이터 위치를 바꿈
                insert_i = parent_i;
            }
        }
        return true;
    }

    public void swap(List<Edge> a, int i1, int i2)
    {
        Edge temp = a[i1];
        a[i1] = a[i2];
        a[i2] = temp;
    }

    public bool is_up(int insert_i)
    {
        if (insert_i <= 1) return false; //루트일 경우 변경 x
        if (minHeap[insert_i / 2].weight > minHeap[insert_i].weight) return true;
        else return false;
    }

    public bool is_down(int insert_i)
    {
        int i_left = insert_i * 2;
        int i_right = insert_i * 2 + 1;
        if (i_left >= minHeap.Count) //자식 노드가 없을 때
            return false;
        else if (i_right >= minHeap.Count)//자식 노드가 하나만 있을 때
        {
            if (minHeap[insert_i].weight > minHeap[i_left].weight) return true;
            return false;
        }
        else //자식 노드가 두개 있을 때
        {
            if(minHeap[i_right].weight < minHeap[i_left].weight 
                && minHeap[insert_i].weight > minHeap[i_right].weight) return true;
            else if (minHeap[i_right].weight >= minHeap[i_left].weight 
                && minHeap[insert_i].weight > minHeap[i_left].weight) return true;
            else return false;
        }
    }

    public Edge heapOut()
    {
        if (minHeap.Count == 0) return null;
        Edge outData = minHeap[1]; //최소값을 가져옴
        minHeap[1] = minHeap[minHeap.Count - 1]; //마지막 값을 가져옴
        minHeap.RemoveAt(minHeap.Count - 1);
        int idx = 1;
        int i_left, i_right;
        while (is_down(idx))
        {
            i_left = idx * 2;
            i_right = idx * 2 + 1;
            if (i_right >= minHeap.Count && minHeap[idx].weight > minHeap[i_left].weight)
            {
                swap(minHeap, idx, i_left);
                idx = i_left;
            }
            else if (i_right < minHeap.Count)
            {
                if (minHeap[i_left].weight < minHeap[i_right].weight)
                {
                    swap(minHeap, idx, i_left);
                    idx = i_left;
                }
                else
                {
                    swap(minHeap, idx, i_right);
                    idx = i_right;
                }
            }
        }
        return outData;
    }

    //해당 노드를 가지고 있는 간선 리스트
    public List<Edge> containNode(string node)
    {
        List<Edge> edges = new List<Edge>();
        for (int i = 0; i < minHeap.Count; i++)
        {
            if (minHeap[i].node1 == node || minHeap[i].node2 == node)
                edges.Add(minHeap[i]);
        }
        return edges;
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
        List<string> nodeList = new List<string>() { "A", "B", "C", "D", "E", "F", "G" };
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

        /*  //크루스칼 알고리즘 테스트 코드
        for (int i = 0; i < nodeList.Count; i++)
        {
            makeSet(nodeList[i]); //Union-Find에서 1)초기화 단계
        }
        edgeList.Sort();
        //for (int i = 0; i < edgeList.Count; i++)
        //{
        //    Debug.Log(edgeList[i].myData()); //Sort 되었는지 확인
        //}
        List<Edge> mst = kruskalFunc(nodeList, edgeList);
        for (int i = 0; i < mst.Count; i++)
        {
            Debug.Log(mst[i].myData());
        }
        */

        List<Edge> dd = primFunc(edgeList, "A");
        for (int i = 0; i < dd.Count; i++)
        {
            Debug.Log(dd[i].myData());
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

    public List<Edge> primFunc(List<Edge> edgeList, string startNode)
    {
        List<Edge> mst = new List<Edge>();
        List<Edge> currentEdgeList, candidateEdgeList, adjacentEdgeList = new List<Edge>();
        Edge currentEdge, popEdge, adjacentEdge;

        List<string> connectedNodeList = new List<string>(); //mst에 연결된 노드 리스트

        Hashtable edgesHash = new Hashtable();
        for (int i = 0; i < edgeList.Count; i++)
        {
            currentEdge = edgeList[i];
            if (!edgesHash.Contains(currentEdge.node1)) edgesHash.Add(currentEdge.node1, new List<Edge>());
            if (!edgesHash.Contains(currentEdge.node2)) edgesHash.Add(currentEdge.node2, new List<Edge>());
        } //Hashtable에 Key값만 넣어줌(아직 리스트에 아무것도 없음)

        for (int i = 0; i < edgeList.Count; i++)
        {
            currentEdge = edgeList[i];
            currentEdgeList = (List<Edge>)edgesHash[currentEdge.node1];
            currentEdgeList.Add(new Edge(currentEdge.weight, currentEdge.node1, currentEdge.node2));
            currentEdgeList = (List<Edge>)edgesHash[currentEdge.node2];
            currentEdgeList.Add(new Edge(currentEdge.weight, currentEdge.node2, currentEdge.node1));
        } //Hashtable에 Edge도 마저 넣어줌

        connectedNodeList.Add(startNode); //시작 노드 넣어줌

        if (edgesHash.Contains(startNode)) candidateEdgeList = (List<Edge>)edgesHash[startNode];
        else candidateEdgeList = new List<Edge>(); 
        MinHeap heap = new MinHeap();
        for (int i = 0; i < candidateEdgeList.Count; i++)
        {
            heap.addHeap(candidateEdgeList[i]);
        }//minHeap에 시작 노드에 있는 Edge들 넣어줌

        while (heap.minHeap.Count > 1)
        {
            popEdge = heap.heapOut(); //간선 중 제일 짧은거 가져옴

            //popEdge.node2 = 선택한 간선에 연결된 반대쪽 노드
            //popEdge.node2가 이미 연결된 노드일 경우에는 패스
            if (!connectedNodeList.Contains(popEdge.node2))
            {
                connectedNodeList.Add(popEdge.node2);
                mst.Add(new Edge(popEdge.weight, popEdge.node1, popEdge.node2)); //mst에 간선 추가함

                //adjacentEdgeList에 node2에 연결된 간선들 넣어줌
                if (edgesHash.Contains(popEdge.node2)) adjacentEdgeList = (List<Edge>)edgesHash[popEdge.node2];
                else adjacentEdgeList = new List<Edge>();

                for (int i = 0; i < adjacentEdgeList.Count; i++)
                {
                    adjacentEdge = adjacentEdgeList[i];
                    if (!connectedNodeList.Contains(adjacentEdge.node2)) heap.addHeap(adjacentEdge);
                } //minHeap에 node2에 연결된 간선이 중복이 아닐 경우 추가해줌
            }
        }

        return mst;
    }
}