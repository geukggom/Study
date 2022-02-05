using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace js_0130
{
    public class Edge : IComparer
    {
        public int distance;
        public string vertex;
        public Edge(int distance, string vertex)
        {
            this.distance = distance;
            this.vertex = vertex;
        }

        public int Compare(object x, object y)
        {
            Edge _x = x as Edge;
            Edge _y = y as Edge;
            return _x.distance - _y.distance;
        }
    }

    public class PriorityQueue : MonoBehaviour
    {
        Hashtable graph = new Hashtable();
        private void Start()
        {
            graph.Add("A", new Edge[] { new Edge(7,"B"), new Edge(8, "D"), new Edge(12, "C") });
            graph.Add("B", new Edge[] { new Edge(5,"D"), new Edge(9, "E") });
            graph.Add("C", new Edge[] { new Edge(6,"G"), new Edge(9, "F") });
            graph.Add("D", new Edge[] { new Edge(2,"E"), new Edge(14, "G") });
            graph.Add("E", new Edge[] { new Edge(3,"H") });
            graph.Add("F", new Edge[] { new Edge(12,"G") });
            graph.Add("G", new Edge[] { new Edge(7,"H") });
            graph.Add("H", new Edge[] { new Edge(5,"F") });
            //ICollection keyColl = graph.Keys;
            //foreach (string a in keyColl)
            //{
            //    Debug.Log(a);
            //}
            //Debug.Log(graph);
            dijkstraFunc(graph, "A");
        }

        public Hashtable dijkstraFunc(Hashtable graph, string start)
        {
            Edge edgeNode, adjNode;
            int currentDistance, weight, distance;
            string currentNode, adjacent;
            Edge[] nodeList;
            Hashtable shortDistance = new Hashtable();

            ICollection keyColl = graph.Keys;
            foreach (string a in keyColl)
            {
                shortDistance.Add(a, int.MaxValue);
            }
            shortDistance[start] = 0;
            MinHeap prioQueue = new MinHeap();
            prioQueue.addHeap(new Edge((int)shortDistance[start], start));
            int count=0;
            while (prioQueue.minHeap.Count > 1 && count<150)
            {
                count++;
                edgeNode = prioQueue.heapOut();
                currentDistance = edgeNode.distance;
                currentNode = edgeNode.vertex;

                if ((int)shortDistance[currentNode] < currentDistance) continue;

                nodeList = (Edge[])graph[currentNode];
                for (int i = 0; i < nodeList.Length; i++)
                {
                    adjNode = nodeList[i];
                    adjacent = adjNode.vertex;
                    weight = adjNode.distance;
                    distance = currentDistance + weight;
                    if (distance < (int)shortDistance[adjacent])
                    {
                        shortDistance[adjacent] = distance;
                        prioQueue.addHeap(new Edge(distance, adjacent));
                    }
                }
            }
            foreach (string a in keyColl)
            {
                Debug.Log(a+"?"+ shortDistance[a]);
            }
            return shortDistance;
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
            if (minHeap[insert_i / 2].distance > minHeap[insert_i].distance) return true;
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
                if (minHeap[insert_i].distance > minHeap[i_left].distance) return true;
                return false;
            }
            else //자식 노드가 두개 있을 때
            {
                if (minHeap[i_right].distance < minHeap[i_left].distance
                    && minHeap[insert_i].distance > minHeap[i_right].distance) return true;
                else if (minHeap[i_right].distance >= minHeap[i_left].distance
                    && minHeap[insert_i].distance > minHeap[i_left].distance) return true;
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
                if (i_right >= minHeap.Count && minHeap[idx].distance > minHeap[i_left].distance)
                {
                    swap(minHeap, idx, i_left);
                    idx = i_left;
                }
                else if (i_right < minHeap.Count)
                {
                    if (minHeap[i_left].distance < minHeap[i_right].distance)
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
    }
}

