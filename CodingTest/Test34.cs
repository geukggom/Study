using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Test34
{
    public class Edge : IComparable
    {
        public int length;
        public int node1;
        public int node2;

        public Edge(int _length, int _node1, int _node2)
        {
            length = _length;
            node1 = _node1;
            node2 = _node2;
        }

        public int CompareTo(object obj)
        {
            Edge e = obj as Edge;
            return -length.CompareTo(e.length);
        }
    }

    public class Heap
    {
        public List<Edge> heapList = new List<Edge>();
        public void AddHeap(Edge edge)
        {
            if (heapList.Count == 0)
            {
                heapList.Add(null); //0번 인덱스는 편의상 사용하지 않음
                heapList.Add(edge);
            }
            else
            {
                heapList.Add(edge);
                int nowIndex = heapList.Count - 1;
                while (true)
                {
                    if (nowIndex <= 1) break;
                    if (heapList[nowIndex / 2].length > heapList[nowIndex].length)
                    {
                        Edge temp = heapList[nowIndex / 2];
                        heapList[nowIndex / 2] = heapList[nowIndex];
                        heapList[nowIndex] = temp;
                        nowIndex = nowIndex / 2;
                    }
                    else break;
                }
            }
        }

        public Edge HeapOut()
        {
            if (heapList.Count <= 1) return null;
            int leftIdx, rightIdx, idx = 1;
            Edge outData = heapList[1];
            heapList[1] = heapList[heapList.Count - 1];
            heapList.RemoveAt(heapList.Count - 1);
            while (true)
            {
                leftIdx = idx * 2;
                rightIdx = idx * 2 + 1;
                if (heapList.Count <= leftIdx) break; //자식 노드가 없을 때
                else if (heapList.Count - 1 == leftIdx) //왼쪽 자식 노드만 있을 때
                {
                    if (heapList[leftIdx].length < heapList[idx].length)
                    {
                        Edge temp = heapList[leftIdx];
                        heapList[leftIdx] = heapList[idx];
                        heapList[idx] = temp;
                    }
                    break;
                }
                else //자식 노드가 둘 다 있을 때
                {
                    if (heapList[leftIdx].length < heapList[rightIdx].length && heapList[leftIdx].length < heapList[idx].length)
                    {
                        Edge temp = heapList[leftIdx];
                        heapList[leftIdx] = heapList[idx];
                        heapList[idx] = temp;
                        idx = leftIdx;
                    }
                    else if (heapList[leftIdx].length >= heapList[rightIdx].length && heapList[rightIdx].length < heapList[idx].length)
                    {
                        Edge temp = heapList[rightIdx];
                        heapList[rightIdx] = heapList[idx];
                        heapList[idx] = temp;
                        idx = rightIdx;
                    }
                    else break;
                }
            }
            return outData;
        }
    }

    public class Solution
    {
        static public int solution(int n, int[,] costs)
        {
            if (n == 1) return 0;
            var edgeList = new List<Edge>();
            for (int i = 0; i < costs.GetLength(0); i++)
            {
                Edge nowEdge = new Edge(costs[i, 2], costs[i, 0], costs[i, 1]);
                edgeList.Add(nowEdge);
            }

            edgeList.Sort();
            Edge shortestEdge = edgeList[edgeList.Count - 1];
            edgeList.RemoveAt(edgeList.Count - 1);

            int node1, node2, answer = 0;
            var candidateHeap = new Heap(); //후보 Edge를 저장하는 리스트
            var addedNodeList = new List<int>(); //연결된 노드를 저장하는 리스트
            while (true)
            {
                node1 = shortestEdge.node1;
                node2 = shortestEdge.node2;
                answer += shortestEdge.length;
                Console.WriteLine("결정 : " + shortestEdge.node1 + ":" + shortestEdge.node2 + ":" + shortestEdge.length);
                if (!addedNodeList.Contains(node1)) addedNodeList.Add(node1);
                if (!addedNodeList.Contains(node2)) addedNodeList.Add(node2);
                if (addedNodeList.Count >= n) break;
                if (edgeList.Count > 0)
                {
                    for (int i = edgeList.Count - 1; i >= 0; i--)
                    {
                        if (edgeList[i].node1 == node1 || edgeList[i].node1 == node2 || edgeList[i].node2 == node1 || edgeList[i].node2 == node2)
                        {
                            Console.WriteLine(edgeList[i].node1 + ":" + edgeList[i].node2 + ":" + edgeList[i].length);
                            candidateHeap.AddHeap(edgeList[i]);
                            edgeList.RemoveAt(i);
                        }
                    }
                }
                while (true)
                {
                    shortestEdge = candidateHeap.HeapOut();
                    if (!addedNodeList.Contains(shortestEdge.node1) || !addedNodeList.Contains(shortestEdge.node2)) break;
                }
            }
            Console.WriteLine(answer);
            return answer;
        }

        static void Main(string[] args)
        {
            //solution(5, new int[,] { { 0, 1, 1 }, { 3, 1, 1 }, { 0,2,2 }, { 0,3,2 }, { 0,4,100} }); 
            //solution(5, new int[,] { { 0, 1, 5 }, { 1, 2, 3 }, { 2,3,3 }, { 3,1,2 }, { 3,0,4}, { 2, 4, 6 }, { 4, 0, 7 } }); 
            solution(5, new int[,] { { 0, 1, 1 }, { 0, 2, 2 }, { 0, 3, 3 }, { 0, 4, 4 }, { 1, 3, 1 } });
            //solution(3, new int[,] { { 0, 1, 1 }, { 0, 2, 3 } }); 
            //solution(4, new int[,] { { 0, 1, 1 }, { 2, 3, 4 }, { 1, 3, 100 }, { 0, 2, 100 } }); 
            //solution(4, new int[,] { { 0, 1, 5 }, { 1, 2, 3 }, { 2, 3, 3 }, { 3, 1, 2 }, { 3,0, 4 } }); 
            //solution(6, new int[,] { { 0, 1, 5 }, { 0,3, 2 }, { 0, 4, 3 }, { 1, 4, 1 }, { 3, 4, 10 }, { 1,2, 2 }, { 2, 5, 3 }, { 4, 5, 4} }); 
            for (; ; );
        }
    }