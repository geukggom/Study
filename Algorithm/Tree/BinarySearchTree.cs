using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Node left_node;
    public Node right_node;
    public int data;
    public Node(int data) { this.data = data; }
}

public class BinarySearchTree : MonoBehaviour
{
    Node head = null;

    public bool AddNode(int data)
    {
        if(this.head == null) //전체 노드가 텅 비었을 때
            this.head = new Node(data);
        else //노드가 하나 이상 있을 때
        {
            Node FindNode = this.head;
            while (true)
            {
                //조건(작은 수는 왼쪽, 큰 수는 오른쪽으로)
                if (data < FindNode.data) //현재 노드의 왼쪽에 새 노드가 들어가게 될 때
                {
                    if (FindNode.left_node != null) //왼쪽 노드를 현재 노드로 지정하고 반복문 다시
                        FindNode = FindNode.left_node;
                    else //현재 노드의 왼쪽에 새 노드 추가하고 반복문 break
                    {
                        FindNode.left_node = new Node(data);
                        break;
                    }
                }
                else if (data > FindNode.data) //현재 노드의 오른쪽에 새 노드가 들어가게 될 때
                {
                    if (FindNode.right_node != null) //오른쪽 노드를 현재 노드로 지정하고 반복문 다시
                        FindNode = FindNode.right_node;
                    else //현재 노드의 오른쪽에 새 노드 추가하고 반복문 break
                    {
                        FindNode.right_node = new Node(data);
                        break;
                    }
                }
                else return false; //중복된 값의 노드가 이미 존재할 때
            }
        }
        return true;
    }

    public Node SearchNode(int data)
    {
        if (this.head == null) return null; //노드가 텅 비었을 때
        else //노드가 하나 이상 있을 때
        {
            Node FindNode = this.head;
            while(FindNode != null) //원하는 data를 가진 노드를 찾아 FindNode에 넣음
            {
                if (FindNode.data == data)
                    return FindNode;
                else if (FindNode.data > data)
                    FindNode = FindNode.left_node;
                else FindNode = FindNode.right_node;
            }
        }
        return null;
    }

    public bool DeleteNode(int data)
    {
        Node CurrParentNode = this.head;
        Node CurrNode = this.head;
        bool is_searched = false;

        if (this.head == null) return false; //노드가 없을 경우

        while (CurrNode != null) // 해당 data의 노드를 찾지 못하면 반복문 끝남
        {
            if(CurrNode.data == data)
            {
                is_searched = true;
                break;
            }
            else if(CurrNode.data > data) //왼쪽 노드 가져옴
            {
                CurrParentNode = CurrNode;
                CurrNode = CurrNode.left_node;
            }
            else // 오른쪽 노드 가져옴
            {
                CurrParentNode = CurrNode;
                CurrNode = CurrNode.right_node;
            }
        }

        if(!is_searched) return false; //해당 data의 노드를 찾지 못했을 경우
        else //해당 data의 노드를 찾았을 경우
        //해당 노드가 리프인지, 어느쪽 노드가 있는지 경우의 수를 따져야 함
        {
            //경우의 수 1. 해당 노드가 리프일 경우
            if(CurrNode.left_node == null && CurrNode.right_node == null)
            {
                if (data < CurrParentNode.data) CurrParentNode.left_node = null;
                else if (data > CurrParentNode.data) CurrParentNode.right_node = null;
                else CurrParentNode = null; //해당 노드 = head
            }
            //경우의 수 2. 해당 노드가 왼쪽 자식노드만 가지고 있을 경우
            else if(CurrNode.left_node != null && CurrNode.right_node == null)
            {
                if (data < CurrParentNode.data) CurrParentNode.left_node = CurrNode.left_node;
                else if (data > CurrParentNode.data) CurrParentNode.right_node = CurrNode.left_node;
            }
            //경우의 수 3. 해당 노드가 오른쪽 자식노드만 가지고 있을 경우
            else if (CurrNode.left_node == null && CurrNode.right_node != null)
            {
                if (data < CurrParentNode.data) CurrParentNode.left_node = CurrNode.right_node;
                else if (data > CurrParentNode.data) CurrParentNode.right_node = CurrNode.right_node;
            }
            //경우의 수 4. 해당 노드가 자식노드를 2개 가지고 있을 경우
            //CurrNode의 왼쪽 브랜치 전부를 오른쪽 브랜치의 제일 작은 노드로 붙이지 않는 이유는
            //Depth가 달라질 수 있기 때문에 여기서 경우의 수를 더 자세히 쪼개는 것.
            //아래와 같은 두 가지 과정을 거침
            //1)삭제할 노드의 오른쪽 브랜치에서 가장 작은 data를 가진 노드를 찾아서 ChangeNode에 넣음.
            //2)ChangeNod는 브랜치가 오른쪽 꺼 아예 하나만 있거나, 전혀 없거나의 경우의 수를 가짐
            else
            {
                Node ChangeNode = CurrNode.right_node;
                Node ChangeParentNode = CurrNode.right_node;
                //1)
                while (CurrNode.left_node != null)
                {
                    ChangeParentNode = ChangeNode;
                    ChangeNode = ChangeNode.left_node;
                }
                if (ChangeNode.right_node == null) //ChangeNode의 자식 노드가 없을 때
                    ChangeParentNode.left_node = null;
                else //ChangeNode의 오른쪽 자식 노드가 있을 때
                    ChangeParentNode.left_node = ChangeNode.right_node;
                //2) 
                if (data < CurrParentNode.data) //해당 노드가 부모 노드의 왼쪽에 있음
                    CurrParentNode.left_node = ChangeNode;
                else //해당 노드가 부모 노드의 오른쪽에 있음
                    CurrParentNode.right_node = ChangeNode;
                ChangeNode.right_node = CurrNode.right_node;
                ChangeNode.left_node = CurrNode.left_node;
            }
            CurrNode = null; //해당 객체 삭제
            return true;
        }
    }

    void Start()
    {
        BinarySearchTree myTree = new BinarySearchTree();
        myTree.AddNode(4);
        myTree.AddNode(6);
        myTree.AddNode(14);
        myTree.AddNode(20);
        myTree.AddNode(24);
        Node test = myTree.SearchNode(20);
    }
}
