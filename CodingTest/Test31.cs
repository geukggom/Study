using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Test31
{
    public class Heap
    {
        public List<int> minHeap = new List<int>();
        public List<int> maxHeap = new List<int>();

        public Heap()
        {
            minHeap.Add(0);
            maxHeap.Add(0);
        }

        public void AddHeap(int num)
        {
            minHeap.Add(num);
            maxHeap.Add(num);
            if (minHeap.Count <= 2) return;
            int idx = minHeap.Count - 1;
            while (true)
            {
                if (idx == 1) break;
                if (minHeap[idx / 2] > minHeap[idx])
                {
                    int temp = minHeap[idx];
                    minHeap[idx] = minHeap[idx / 2];
                    minHeap[idx / 2] = temp;
                    idx = idx / 2;
                }
                else break;
            }
            idx = minHeap.Count - 1;
            while (true)
            {
                if (idx == 1) break;
                if (maxHeap[idx / 2] < maxHeap[idx])
                {
                    int temp = maxHeap[idx];
                    maxHeap[idx] = maxHeap[idx / 2];
                    maxHeap[idx / 2] = temp;
                    idx = idx / 2;
                }
                else break;
            }
        }

        public int HeapOut(bool is_Min)
        {
            int num = 0;
            if (minHeap.Count <= 1) return num;
            if (is_Min)
            {
                num = minHeap[1];
                minDown(1);
                maxDown(maxHeap.FindIndex(x => x == num));
            }
            else
            {
                num = maxHeap[1];
                maxDown(1);
                minDown(minHeap.FindIndex(x => x == num));
            }
            return num;
        }

        public void maxDown(int index)
        {
            maxHeap[index] = maxHeap[maxHeap.Count - 1];
            maxHeap.RemoveAt(maxHeap.Count - 1);
            int left, right, idx = index;
            while (true)
            {
                left = idx * 2;
                right = left + 1;
                if (left >= maxHeap.Count) break;
                else if (right == maxHeap.Count)
                {
                    if (maxHeap[left] > maxHeap[idx])
                    {
                        int temp = maxHeap[idx];
                        maxHeap[idx] = maxHeap[left];
                        maxHeap[left] = temp;
                    }
                    idx = left;
                    break;
                }
                else
                {
                    if (maxHeap[left] > maxHeap[right] && maxHeap[left] > maxHeap[idx])
                    {
                        int temp = maxHeap[idx];
                        maxHeap[idx] = maxHeap[left];
                        maxHeap[left] = temp;
                        idx = left;
                    }
                    else if (maxHeap[left] <= maxHeap[right] && maxHeap[right] > maxHeap[idx])
                    {
                        int temp = maxHeap[idx];
                        maxHeap[idx] = maxHeap[right];
                        maxHeap[right] = temp;
                        idx = right;
                    }
                    else break;
                }
            }
        }

        public void minDown(int index)
        {
            minHeap[index] = minHeap[minHeap.Count - 1];
            minHeap.RemoveAt(minHeap.Count - 1);
            int left, right, idx = index;
            while (true)
            {
                left = idx * 2;
                right = left + 1;
                if (left >= minHeap.Count) break;
                else if (right == minHeap.Count)
                {
                    if (minHeap[left] < minHeap[idx])
                    {
                        int temp = minHeap[idx];
                        minHeap[idx] = minHeap[left];
                        minHeap[left] = temp;
                    }
                    idx = left;
                    break;
                }
                else
                {
                    if (minHeap[left] < minHeap[right] && minHeap[left] < minHeap[idx])
                    {
                        int temp = minHeap[idx];
                        minHeap[idx] = minHeap[left];
                        minHeap[left] = temp;
                        idx = left;
                    }
                    else if (minHeap[left] >= minHeap[right] && minHeap[right] < minHeap[idx])
                    {
                        int temp = minHeap[idx];
                        minHeap[idx] = minHeap[right];
                        minHeap[right] = temp;
                        idx = right;
                    }
                    else break;
                }
            }
        }
    }


    public int[] solution(string[] operations)
    {
        Heap heap = new Heap();
        for (int i = 0; i < operations.Length; i++)
        {
            string[] s = operations[i].Split(' ');
            if (s[0] == "I")
            {
                Console.WriteLine("추가:" + s[1]);
                heap.AddHeap(int.Parse(s[1]));
            }
            else if (s[0] == "D")
            {
                if (s[1] == "1") Console.WriteLine("최대:" + heap.HeapOut(false));
                else if (s[1] == "-1") Console.WriteLine("최소:" + heap.HeapOut(true));
            }
        }
        int[] answer = new int[2];
        if (heap.minHeap.Count <= 1)
        {
            answer[0] = 0;
            answer[1] = 0;
        }
        else
        {
            answer[0] = heap.maxHeap[1];
            answer[1] = heap.minHeap[1];
        }
        return answer;
    }
}
