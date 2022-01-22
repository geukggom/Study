using System;

public class LinkedList_Study<T> // 단일 링크 리스트 구현
{
    public T Data { get; set; }
    public LinkedList_Study<T> Next { get; set; }
    public LinkedList_Study(T data)
    {
        this.Data = data;
        this.Next = null;
    }

    private LinkedList_Study<T> head;

    public void Add(LinkedList_Study<T> newNode) // 새 노드를 추가.
    {
        if (head == null) head = newNode; //리스트가 비어 있을 때 head에 새 노드를 할당.
        else // 리스트가 비어있지 않을 때.
        {
            var current = head;
            while (current != null && current.Next != null)  // 마지막 노드(Tail)로 이동하여 추가.
                current = current.Next;
            current.Next = newNode;
        }
    }

    public void AddAfter(LinkedList_Study<T> current, LinkedList_Study<T> newNode) //새 노드를 중간에 삽입.
    {
        if (head == null || current == null || newNode == null)
            throw new InvalidOperationException();
        newNode.Next = current.Next;
        current.Next = newNode;
    }

    public void Remove(LinkedList_Study<T> removeNode) // 특정 노드를 삭제.
    {
        if (head == null || removeNode == null) return;
        if(removeNode == head)
        {
            head = head.Next;
            removeNode = null;
        }
        else
        {
            var current = head;
            while (current != null && current.Next != removeNode) current = current.Next;
            if(current != null)
            {
                current.Next = removeNode.Next;
                removeNode = null;
            }
        }
    }

    public LinkedList_Study<T> GetNode(int index) // 지정한 위치에 있는 노드를 반환.
    {
        var current = head;
        for (int i = 0; i < index && current != null; i++)
        {
            current = current.Next;
        }
        return current;
    }

    public int Count() // head부터 마지막 노드까지 이동하면서 카운트 증가(노드가 몇개 있는지)
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
