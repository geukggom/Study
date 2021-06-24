using System;

public class Test13  // : 쿼드 압축 후 개수 세기
{
    /// <summary>
    /// 0과 1로 이루어진 2n x 2n 크기의 2차원 정수 배열 arr이 있습니다. 이 arr을 쿼드 트리와 같은 방식으로 압축하고자 합니다.
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public int[] solution(int[,] arr)
    {
        int[] answer = new int[2];
        arrNum = arr.Length;
        DevideFour(arr);
        while (true)
        {
            if (arrNum == 0) break;
        }
        answer[0] = zeroCount;
        answer[1] = oneCount;
        return answer;
    }
    void DevideFour(int[,] testArray)
    {
        int checknum = Check(testArray);
        switch (checknum)
        {
            case -1: break;
            case 0: zeroCount++; arrNum -= testArray.Length; return;
            case 1: oneCount++; arrNum -= testArray.Length; return;
        }
        int n = testArray.GetLength(0) / 2;
        for (int i = 0; i < 4; i++)
        {
            int[,] smallArray = new int[n, n];
            for (int k1 = 0; k1 < n; k1++)
            {
                for (int k2 = 0; k2 < n; k2++)
                {
                    switch (i)
                    {
                        case 0: smallArray[k1, k2] = testArray[k1, k2]; break;
                        case 1: smallArray[k1, k2] = testArray[n + k1, k2]; break;
                        case 2: smallArray[k1, k2] = testArray[k1, n + k2]; break;
                        case 3: smallArray[k1, k2] = testArray[n + k1, n + k2]; break;
                    }
                }
            }
            DevideFour(smallArray);
        }
    }
    int zeroCount;
    int oneCount;
    int arrNum;
    int Check(int[,] testArray)
    {
        int numZero = 0;
        for (int i = 0; i < testArray.GetLength(0); i++)
        {
            for (int j = 0; j < testArray.GetLength(1); j++)
            {
                if (testArray[i, j] == 0) numZero++;
            }
        }
        if (numZero == testArray.Length) return 0;
        else if (numZero == 0) return 1;
        else return -1;
    }
}
