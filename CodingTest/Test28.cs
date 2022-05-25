using System;
using System.Collections.Generic;

public class Test28
{
    public class Document
}   {
        public int index;
        public int priority;
        public Document(int _index,int _priority)
        {
            index = _index;
            priority = _priority;
        }
    }

    public int solution(int[] priorities, int location)
    {
        List<Document> documentlist = new List<Document>();
        for (int i = 0; i < priorities.Length; i++)
        {
            Document d = new Document(i, priorities[i]);
            documentlist.Add(d);
        }
        int count = documentlist.Count;
        for (int i = 0; i < count - 1; i++)
        {
            if(documentlist[i + 1].priority > documentlist[i].priority)
            {
                int nowPriority = documentlist[i + 1].priority;
                Stack<Document> s = new Stack<Document>();
                for (int j = i; j >= 0; j--)
                {
                    if (nowPriority > documentlist[j].priority)
                    {
                        s.Push(documentlist[j]);
                        documentlist.RemoveAt(j);
                        i -= 1;
                    }
                    else j = 0;
                }
                documentlist.AddRange(s);
            }
        }
        for (int i = 0; i < documentlist.Count; i++)
        {
            Console.WriteLine(documentlist[i].index + ":" + documentlist[i].priority);
        }
        int answer = documentlist.FindIndex(x => x.index == location) + 1;
        Console.WriteLine(answer);
        return answer;
    }