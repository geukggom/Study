using System.Collections.Generic;

public class Test33
{
    static public Dictionary<int, List<int>> network = new Dictionary<int, List<int>>();
    static public List<int> addList = new List<int>();

    static public int solution(int n, int[,] computers)
    {
        for (int i = 0; i < n; i++)
        {
            addList.Add(i);
        }
        DFS(computers, 0, 0);
        return network.Keys.Count;
    }

    static void DFS(int[,] computers, int x, int key)
    {
        for (int y = key; y < computers.GetLength(0); y++)
        {
            if (!addList.Contains(y)) continue;
            if (computers[x, y] == 1)
            {
                if (!network.ContainsKey(key)) network.Add(key, new List<int>());
                network[key].Add(y);
                addList.Remove(y);
                if (x != y) DFS(computers, y, key);
            }
        }
        if (x == key && addList.Count != 0) DFS(computers, addList[0], addList[0]);
    }

    static void Main(string[] args)
    {
        //solution(4,new int[,] { { 1, 0, 1, 0 },{ 0, 1, 1, 0 },{ 1, 1, 1, 0 },{ 0, 0, 0, 1 } });
        solution(4, new int[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } });
        for (; ; );
    }
}