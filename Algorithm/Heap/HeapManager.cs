using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeapManager : MonoBehaviour
{
    public List<int?> heapList = new List<int?>();

    public bool addHeap(int data)
    {
        if (heapList.Count == 0)
        {
            heapList = new List<int?>();
            heapList.Add(null); //0번 인덱스는 사용하지 않음(계산하기 편하게 하기 위해)
            heapList.Add(data); //1번 인덱스부터 데이터를 넣음.
        }
        else
        {
            heapList.Add(data);
            int parent_i, insert_i  = heapList.Count - 1; //추가
            while (is_up(insert_i)) //insert_i를 부모노드와 크기 비교
            {
                parent_i = insert_i / 2;
                swap(heapList, insert_i, parent_i); //두 데이터 위치를 바꿈
                insert_i = parent_i;
            }
        }
        return true;
    }

    public void swap(List<int?> a, int i1, int i2)
    {
        int? temp = a[i1];
        a[i1] = a[i2];
        a[i2] = temp;
    }

    public bool is_up(int insert_i)
    {
        if (insert_i <= 1) return false; //루트일 경우 변경 x
        if ((int)heapList[insert_i / 2] < (int)heapList[insert_i]) return true;
        else return false;
    }

    public bool is_down(int insert_i, int i_left, int i_right)
    {
        if (i_left > heapList.Count) //자식 노드가 없을 때
            return false;
        else if (i_left == heapList.Count)//자식 노드가 하나만 있을 때
        {
            if (heapList[insert_i] < heapList[i_left])
                swap(heapList, i_left, insert_i);
            return false;
        }
        else //자식 노드가 두개 있을 때
        {
            if (heapList[insert_i] < heapList[i_right])
            {
                swap(heapList, i_right, insert_i);
                return true;
            }
            else if (heapList[insert_i] < heapList[i_left])
            {
                swap(heapList, i_left, insert_i);
                return true;
            }
            else return false;
        }
    }

    public int? heapOut()
    {
        if (heapList.Count == 0) return null;
        int? outData = (int)heapList[1]; //최대값을 가져옴
        heapList[1] = heapList[heapList.Count - 1]; //마지막 값을 가져옴
        heapList.RemoveAt(heapList.Count - 1);
        int idx = 1;
        int i_left = idx * 2;
        int i_right = idx * 2 + 1;
        while (is_down(idx, i_left, i_right))
        {
            i_left = idx * 2;
            i_right = idx * 2 + 1;
            if (heapList[idx] < heapList[i_right])
                idx = i_right;
            else if (heapList[idx] < heapList[i_left])
                idx = i_left;
        }
        return outData;
    }

    void Start()
    {
        addHeap(4);
        addHeap(5);
        addHeap(10);
        addHeap(8);
        addHeap(20);
        addHeap(15);
        heapOut();
        for (int i = 0; i < heapList.Count; i++)
        {
            Debug.Log(heapList[i]);
        }
    }
}
