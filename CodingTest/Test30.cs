using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Test30 
{
    public class Data
    {
        public int startTime = 0;
        public int workTime = 0;

        public Data(int _startTime, int _workTime)
        {
            startTime = _startTime;
            workTime = _workTime;
        }
    }

    public class Heap
    {
        public List<Data> heapList = new List<Data>();
        public void AddHeap(Data _worktime)
        {
            if (heapList.Count == 0)
            {
                heapList.Add(null); //0번 인덱스는 편의상 사용하지 않음
                heapList.Add(_worktime);
            }
            else
            {
                heapList.Add(_worktime);
                int nowIndex = heapList.Count - 1;
                while (true)
                {
                    if (nowIndex <= 1) break;
                    if (heapList[nowIndex / 2].workTime > heapList[nowIndex].workTime)
                    {
                        Data temp = heapList[nowIndex / 2];
                        heapList[nowIndex / 2] = heapList[nowIndex];
                        heapList[nowIndex] = temp;
                        nowIndex = nowIndex / 2;
                    }
                    else break;
                }
            }
            for (int i = 1; i < heapList.Count; i++)
            {
                Console.Write(heapList[i].workTime + "-");
            }
            Console.WriteLine();
        }

        public Data HeapOut()
        {
            if (heapList.Count <= 1) return null;
            int leftIdx, rightIdx, idx = 1;
            Data outData = heapList[1];
            heapList[1] = heapList[heapList.Count - 1];
            heapList.RemoveAt(heapList.Count - 1);
            while (true)
            {
                leftIdx = idx * 2;
                rightIdx = idx * 2 + 1;
                if (heapList.Count - 1 < leftIdx) break; //자식 노드가 없을 때
                else if (heapList.Count - 1 == leftIdx) //왼쪽 자식 노드만 있을 때
                {
                    if (heapList[leftIdx].workTime < heapList[idx].workTime)
                    {
                        Data temp = heapList[leftIdx];
                        heapList[leftIdx] = heapList[idx];
                        heapList[idx] = temp;
                    }
                    break;
                }
                else //자식 노드가 둘 다 있을 때
                {
                    if (heapList[leftIdx].workTime < heapList[rightIdx].workTime && heapList[leftIdx].workTime < heapList[idx].workTime)
                    {
                        Data temp = heapList[leftIdx];
                        heapList[leftIdx] = heapList[idx];
                        heapList[idx] = temp;
                        idx = leftIdx;
                    }
                    else if (heapList[leftIdx].workTime >= heapList[rightIdx].workTime && heapList[rightIdx].workTime < heapList[idx].workTime)
                    {
                        Data temp = heapList[rightIdx];
                        heapList[rightIdx] = heapList[idx];
                        heapList[idx] = temp;
                        idx = rightIdx;
                    }
                    else break;
                }
            }
            for (int i = 1; i < heapList.Count; i++)
            {
                Console.Write(heapList[i].workTime + "-");
            }
            Console.WriteLine();
            return outData;
        }
    }

    static public int solution(int[,] jobs)
    {
        Queue<Data> dataQ = new Queue<Data>();
        for (int i = 0; i < jobs.GetLength(0); i++)
        {
            dataQ.Enqueue(new Data(jobs[i, 0], jobs[i, 1]));
        }
        dataQ.OrderBy(x => x.startTime);
        int time = 0;
        int workAverage = 0;
        Heap dataHeap = new Heap();
        while (true)
        {
            int QCount = dataQ.Count;
            for (int i = 0; i < QCount; i++)
            {
                if (dataQ.Peek().startTime <= time) dataHeap.AddHeap(dataQ.Dequeue());
                else break;
            }
            Data work = dataHeap.HeapOut();
            if (work == null) time++;
            else
            {
                time += work.workTime;
                workAverage += (time - work.startTime);
                Console.WriteLine("time" + time + "- work " + work.startTime + ":" + work.workTime + "/" + workAverage);
            }
            if (QCount == 0 && work == null) break;
        }
        workAverage = workAverage / jobs.GetLength(0);
        // Console.WriteLine(workAverage);
        return workAverage;
    }

    static void Main(string[] args)
    {
        //string[] genres = new string[5] { "a", "b", "a", "a", "b" };
        //int[] priorities = new int[6] { 1,1,9,1,1,1 };
        solution(new int[13, 2] { { 0, 3 }, { 1, 9 }, { 2, 6 }, { 42, 16 }, { 12, 26 }, { 22, 36 }, { 1, 26 }, { 52, 10 }, { 83, 9 }, { 0, 4 }, { 97, 25 }, { 32, 6 }, { 8, 16 } });
        //solution(new int[7] {1,5,2,6,3,7,4 },new int[2, 3] { {4,4,1 },{1,7,3} });
        for (; ; );
    }
}
