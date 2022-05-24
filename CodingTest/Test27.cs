using System;
using System.Collections.Generic;

public class play : IComparable
{
    public int allCount = 0;
    public int count1 = 0;
    public int count2 = 0;
    public int index1 = -1;
    public int index2 = -1;
    public void InputList(int _count, int _index)
    {
        allCount += _count;
        if (_count >= count1)
        {
            count2 = count1;
            count1 = _count;
            index2 = index1;
            index1 = _index;
            if (count1 == count2 && index1 > index2)
            {
                int temp = index2;
                index2 = index1;
                index1 = temp;
            }
        }
        else if (_count > count2)
        {
            count2 = _count;
            index2 = _index;
        }
        else if (_count == count2 && index2 > _index)
        {
            index2 = _index;
        }
    }
    public int CompareTo(object obj)
    {
        play p = obj as play;
        return -allCount.CompareTo(p.allCount);
    }
}

public class Test27 : MonoBehaviour
{
    public int[] solution(string[] genres, int[] plays)
    {
        List<int> answer = new List<int>();
        Dictionary<string, play> streamList = new Dictionary<string, play>();
        for (int i = 0; i < genres.Length; i++)
        {
            if (streamList.ContainsKey(genres[i]))
            {
                streamList[genres[i]].InputList(plays[i], i);
            }
            else
            {
                play p = new play();
                p.InputList(plays[i], i);
                streamList.Add(genres[i], p);
            }
        }
        List<play> playList = new List<play>(streamList.Values);
        playList.Sort();
        for (int i = 0; i < playList.Count; i++)
        {
            answer.Add(playList[i].index1);
            if (playList[i].index2 != -1) answer.Add(playList[i].index2);
        }
        Console.WriteLine(answer.Count);
        for (int i = 0; i < answer.Count; i++)
        {
            Console.WriteLine(answer[i]);
        }
        return answer.ToArray();
    }
}
