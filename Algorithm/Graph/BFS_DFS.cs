using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFS_DFS : MonoBehaviour
{
    Hashtable mapData = new Hashtable();
    void Start()
    {
        dataAdd("A", new string[] { "B", "C" });
        dataAdd("B", new string[] { "A", "D" });
        dataAdd("C", new string[] { "A", "G", "H", "I" });
        dataAdd("D", new string[] { "B", "E", "F" });
        dataAdd("E", new string[] { "D" });
        dataAdd("F", new string[] { "D" });
        dataAdd("G", new string[] { "C" });
        dataAdd("H", new string[] { "C" });
        dataAdd("I", new string[] { "C", "J" });
        dataAdd("J", new string[] { "I" });
        List<string> answer = new List<string>();
        answer = bfsSearch(mapData, "A");
        for (int i = 0; i < answer.Count; i++)
        {
            //Debug.Log(answer[i]);
        }
        Hashtable aa = new Hashtable();
        aa = dfsSearch2(mapData, "A", aa);
        foreach (var a in aa.Keys)
        {
            //Debug.Log();
        }
    }

    void dataAdd(string key, string[] array)
    {
        mapData.Add(key, array);
    }

    public List<string> bfsSearch(Hashtable data, string startKey)
    {
        List<string> visited = new List<string>();
        List<string> nextKeys = new List<string>();
        nextKeys.Add(startKey);
        while (nextKeys.Count > 0)
        {
            string node = nextKeys[0];
            visited.Add(node);
            nextKeys.RemoveAt(0);
            string[] keyArray = (string[])data[node];
            for (int i = 0; i < keyArray.Length; i++)
            {
                if (!visited.Contains(keyArray[i])) nextKeys.Add(keyArray[i]);
            }
        }
        return visited;
    }

    public List<string> dfsSearch(Hashtable data, string startKey)
    {
        List<string> visited = new List<string>();
        List<string> nextKeys = new List<string>();
        nextKeys.Add(startKey);
        while (nextKeys.Count > 0)
        {
            string node = nextKeys[nextKeys.Count - 1];
            visited.Add(node);
            nextKeys.RemoveAt(nextKeys.Count - 1);
            string[] keyArray = (string[])data[node];
            for (int i = 0; i < keyArray.Length; i++)
            {
                if (!visited.Contains(keyArray[i])) nextKeys.Add(keyArray[i]);
            }
        }
        return visited;
    }

    public Hashtable dfsSearch2(Hashtable data, string startKey, Hashtable answerList)
    {

        if (answerList.ContainsKey(startKey))
        {
            return answerList;
        }
        Debug.Log(startKey);
        string[] keyArray = (string[])data[startKey];
        answerList.Add(startKey, keyArray.Length);
        for (int i = 0; i < keyArray.Length; i++)
        {
            dfsSearch2(data, keyArray[i], answerList);
        }
        return answerList;
    }
}
