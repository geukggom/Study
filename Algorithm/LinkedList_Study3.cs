using System;

public class LinkedList_Study3<T> //이중 링크 리스트 구현
{
    public T Data { get; set; }
    public LinkedList_Study3<T> Prev { get; set; }
    public LinkedList_Study3<T> Next { get; set; }

    public LinkedList_Study3(T data, LinkedList_Study3<T> prev, LinkedList_Study3<T> next)
    {
        this.Data = data;
        this.Prev = prev;
        this.Next = next;
    }
    private LinkedList_Study3<T> head;

    public void Add(LinkedList_Study3<T> newNode) //새 노드 추가.
    {
        if (head == null) //리스트가 비어있으면 head에 새 노드 할당
        {
            head = newNode;
            head.Next = head;
            head.Prev = head;
        }
        else //비어 있지 않을 때
        {
            var tail = head.Prev;
            head.Prev = newNode;
            tail.Next = newNode;
            newNode.Prev = tail;
            newNode.Next = head;
        }
    }

    public void AddAfter(LinkedList_Study3<T> current, LinkedList_Study3<T> newNode) //새 노드를 중간에 삽입
    {
        if (head == null || current == null || newNode == null)
            throw new InvalidOperationException();
        newNode.Next = current.Next;
        current.Next.Prev = newNode;
        newNode.Prev = current;
        newNode.Next = newNode;
    }

    public void Remove(LinkedList_Study3<T> removeNode) //특정 노드 삭제
    {
        if (head == null || removeNode == null) return;
        if (removeNode == head && head == head.Next) //삭제할 노드가 헤드 노드이고, 노드가 1개일 때
            head = null;
        else //아니면 Prev 노드와 Next 노드를 연결
        {
            removeNode.Prev.Next = removeNode.Next;
            removeNode.Next.Prev = removeNode.Prev;
        }
        removeNode = null;
    }

    public LinkedList_Study3<T> GetNode(int index) //지정한 위치의 노드 반환
    {
        if (head == null) return null;
        int cnt = 0;
        var current = head;
        while(cnt < index)
        {
            current = current.Next;
            cnt++;
            if (current == head) return null;
        }
        return current;
    }

    public int Count()
    {
        int cnt = 0;
        var current = head;
        do
        {
            cnt++;
            current = current.Next;
        } while (current != head);
        return cnt;
    }

    public static bool is_Circular(LinkedList_Study3<T> head) // 원형 연결 리스트인지 체크
    {
        if (head == null) return true;
        var current = head;
        while(current != null)
        {
            current = current.Next;
            if (current == head) return true;
        }
        return false;
    }

    public static bool is_Cyclic(LinkedList_Study3<int> head) //연결리스트 중간에 원형이 있는지 체크
    {
        var p1 = head;
        var p2 = head;
        do
        {
            p1 = p1.Next;
            p2 = p2.Next;
            if (p1 == null || p2 == null || p2.Next == null) return false;
            p2 = p2.Next;
        } while (p1 != p2);
        return true;
    }
}
