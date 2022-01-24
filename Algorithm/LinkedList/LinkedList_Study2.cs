using System;

public class LinkedList_Study2<T> //이중 링크 리스트 구현
{
    public T Data { get; set; }
    public LinkedList_Study2<T> Prev { get; set; }
    public LinkedList_Study2<T> Next { get; set; }

    public LinkedList_Study2(T data, LinkedList_Study2<T> prev, LinkedList_Study2<T> next)
    {
        this.Data = data;
        this.Prev = prev;
        this.Next = next;
    }

    public LinkedList_Study2(T data) 
        : this(data, null, null) { }

    private LinkedList_Study2<T> head;

    public void Add(LinkedList_Study2<T> newNode) //새 노드 추가.
    {
        if (head == null) head = newNode; //리스트가 비어있으면 head에 새 노드 할당
        else //비어 있지 않을 때
        {
            var current = head;
            while (current != null && current.Next != null)
                current = current.Next;
            current.Next = newNode;
            newNode.Prev = current;
            newNode.Next = null;
        }
    }

    public void AddAfter(LinkedList_Study2<T> current, LinkedList_Study2<T> newNode) //새 노드를 중간에 삽입
    {
        if (head == null || current == null || newNode == null)
            throw new InvalidOperationException();
        newNode.Next = current.Next;
        current.Next.Prev = newNode;
        newNode.Prev = current;
        newNode.Next = newNode;
    }

    public void Remove(LinkedList_Study2<T> removeNode) //특정 노드 삭제
    {
        if (head == null || removeNode == null) return;
        if(removeNode == head)
        {
            head = head.Next;
            if (head != null) head.Prev = null;
        }
        else
        {
            removeNode.Prev.Next = removeNode.Next;
            if (removeNode.Next != null)
                removeNode.Next.Prev = removeNode.Prev;
        }
        removeNode = null;
    }

    public LinkedList_Study2<T> GetNode(int index) //지정한 위치의 노드 반환
    {
        var current = head;
        for (int i = 0; i < index && current != null; i++)
        {
            current = current.Next;
        }
        return current;
    }

    public int Count()
    {
        int cnt = 0;
        var current = head;
        while(current != null)
        {
            cnt++;
            current = current.Next;
        }
        return cnt;
    }
}
