using System;

public class Test_Script
{
    /// <summary>
    /// 길이가 같은 두 1차원 정수 배열 a, b가 매개변수로 주어집니다. a와 b의 내적을 return 하도록 solution 함수를 완성해주세요.
    /// 이때, a와 b의 내적은 a[0]*b[0] + a[1]*b[1] + ... + a[n - 1]*b[n - 1] 입니다. (n은 a, b의 길이)
    /// </summary>
    /// <param name="a">배열 a</param>
    /// <param name="b">배열 b</param>
    /// <returns></returns>
    public int solution1(int[] a, int[] b)
    {
        int answer = 0;
        for (int i = 0; i < a.Length; i++)
        {
            answer += (a[i] * b[i]);
        }
        return answer;
    }

    /// <summary>
    /// 점심시간에 도둑이 들어, 일부 학생이 체육복을 도난당했습니다. 다행히 여벌 체육복이 있는 학생이 이들에게 체육복을 빌려주려 합니다. 
    /// 학생들의 번호는 체격 순으로 매겨져 있어, 바로 앞번호의 학생이나 바로 뒷번호의 학생에게만 체육복을 빌려줄 수 있습니다. 
    /// 예를 들어, 4번 학생은 3번 학생이나 5번 학생에게만 체육복을 빌려줄 수 있습니다. 
    /// 체육복이 없으면 수업을 들을 수 없기 때문에 체육복을 적절히 빌려 최대한 많은 학생이 체육수업을 들어야 합니다.
    /// 체육수업을 들을 수 있는 학생의 최댓값을 return 하도록 solution 함수를 작성해주세요.
    /// </summary>
    /// <param name="n">전체 학생의 수</param>
    /// <param name="lost">체육복을 도난당한 학생들의 번호가 담긴 배열</param>
    /// <param name="reserve">여벌의 체육복을 가져온 학생들의 번호가 담긴 배열</param>
    /// <returns></returns>
    public int solution2(int n, int[] lost, int[] reserve)
    {
        int me = 0;
        for (int i = 0; i < lost.Length; i++)
        {
            for (int j = 0; j < reserve.Length; j++)
            {
                if (lost[i] == reserve[j])
                {
                    reserve[j] = -2;
                    lost[i] = -4;
                    me++;
                    j = reserve.Length - 1;
                }
            }
        }
        int answer = n - lost.Length + me;
        for (int i = 0; i < lost.Length; i++)
        {
            for (int j = 0; j < reserve.Length; j++)
            {
                if(lost[i] - reserve[j] >= -1 && lost[i] - reserve[j] <= 1)
                {
                    reserve[j] = -2;
                    answer++;
                    j = reserve.Length - 1;
                }
            }
        }
        return answer;
    }

    /// <summary>
    /// 민우의 동생이 로또에 낙서를 하여, 일부 번호를 알아볼 수 없게 되었습니다. 
    /// 당첨 번호 발표 후, 민우는 자신이 구매했던 로또로 당첨이 가능했던 최고 순위와 최저 순위를 알아보고 싶어 졌습니다.
    /// 알아볼 수 없는 번호를 0으로 표기.
    /// 순서와 상관없이, 구매한 로또에 당첨 번호와 일치하는 번호가 있으면 맞힌 걸로 인정됩니다.
    /// 알아볼 수 없는 두 개의 번호를 각각 10, 6이라고 가정하면 3등에 당첨될 수 있습니다.
    /// 3등을 만드는 다른 방법들도 존재합니다. 하지만, 2등 이상으로 만드는 것은 불가능합니다.
    /// 알아볼 수 없는 두 개의 번호를 각각 11, 7이라고 가정하면 5등에 당첨될 수 있습니다.
    /// 5등을 만드는 다른 방법들도 존재합니다. 하지만, 6등(낙첨) 으로 만드는 것은 불가능합니다.
    /// </summary>
    /// <param name="lottos">민우가 산 로또(0이상 45이하)</param>
    /// <param name="win_nums">당첨 로또 번호(1이상 45이하)</param>
    /// <returns></returns>
    public int[] solution3(int[] lottos, int[] win_nums)
    {
        int[] answer = new int[2];
        int zeroNum = 0;
        int winNum = 0;
        for (int i = 0; i < lottos.Length; i++)
        {
            if (lottos[i] == 0) zeroNum++;
            else
            {
                for (int j = 0; j < win_nums.Length; j++)
                {
                    if (lottos[i] == win_nums[j]) winNum++;
                }
            }
        }
        for (int i = 0; i < answer.Length; i++)
        {
            int rank = 0;
            if (i == 0) rank = winNum + zeroNum;
            else rank = winNum;
            if (rank < 2) answer[i] = 6;
            else answer[i] = 7 - 1;
        }
        return answer;
    }

    /// <summary>
    /// 주어진 숫자 중 3개의 수를 더했을 때 소수가 되는 경우의 개수를 구하려고 합니다. 
    /// 숫자들이 들어있는 배열 nums가 매개변수로 주어질 때, nums에 있는 숫자들 중 서로 다른 3개를 골라 더했을 때 소수가 되는 경우의 개수를 return 하도록 solution 함수를 완성해주세요.
    /// </summary>
    /// <param name="nums">1~1000의 자연수 배열(배열 길이는 3~50)</param>
    /// <returns></returns>
    public int solution4(int[] nums)
    {
        int answer = 0;
        int arrayLength = nums.Length * (nums.Length - 1) * (nums.Length - 2) / 6;
        int[] numberSum = new int[arrayLength];
        arrayLength = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                for (int k = j + 1; k < nums.Length; k++)
                {
                    numberSum[arrayLength] = (nums[i] + nums[k] + nums[j]);
                    arrayLength++;
                }
            }
        }
        for (int i = 0; i < numberSum.Length; i++)
        {
            bool is_true = true;
            for (int j = 2; j < (numberSum[i] / 2 + 1); j++)
            {
                if(numberSum[i] % j == 0) { is_true = false; }
            }
            if (is_true) answer++;
        }
        return answer;
    }

    /// <summary>
    /// 배열 array의 i번째 숫자부터 j번째 숫자까지 자르고 정렬했을 때, k번째에 있는 수를 구하려 합니다.
    /// 예를 들어 array가[1, 5, 2, 6, 3, 7, 4], i = 2, j = 5, k = 3이라면 array의 2번째부터 5번째까지 자르면[5, 2, 6, 3]입니다.
    /// 1에서 나온 배열을 정렬하면[2, 3, 5, 6]입니다.
    /// 2에서 나온 배열의 3번째 숫자는 5입니다.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="commands"></param>
    /// <returns></returns>
    public int[] solution5(int[] array, int[,] commands)
    {
        int[] answer = new int[commands.Length / 3];
        for (int a = 0; a < commands.Length / 3; a++)
        {
            int ArrayLength = commands[a, 1] - commands[a, 0] + 1;
            int[] ArrayNew = new int[ArrayLength];
            int NewIndex = commands[a, 0] - 1;
            for (int i = 0; i < ArrayNew.Length; i++)
            {
                ArrayNew[i] = array[NewIndex + i];
            }
            for (int i = 0; i < ArrayNew.Length - 1; i++)
            {
                if (ArrayNew[i + 1] < ArrayNew[i])
                {
                    int temp = ArrayNew[i + 1];
                    ArrayNew[i + 1] = ArrayNew[i];
                    ArrayNew[i] = temp;
                    i = -1;
                }
            }
            answer[a] = ArrayNew[commands[a, 2] - 1];
        }
        return answer;
    }

    /// <summary>
    /// rows x columns 크기인 행렬이 있습니다. 행렬에는 1부터 rows x columns까지의 숫자가 한 줄씩 순서대로 적혀있습니다. 
    /// 이 행렬에서 직사각형 모양의 범위를 여러 번 선택해, 테두리 부분에 있는 숫자들을 시계방향으로 회전시키려 합니다. 
    /// 각 회전은 (x1, y1, x2, y2)인 정수 4개로 표현하며, 그 의미는 다음과 같습니다.
    /// x1 행 y1 열부터 x2 행 y2 열까지의 영역에 해당하는 직사각형에서 테두리에 있는 숫자들을 한 칸씩 시계방향으로 회전합니다.
    /// 각 회전들을 배열에 적용한 뒤, 그 회전에 의해 위치가 바뀐 숫자들 중 가장 작은 숫자들을 순서대로 배열에 담아 return 하도록 solution 함수를 완성해주세요.
    /// </summary>
    /// <param name="rows"></param>
    /// <param name="columns"></param>
    /// <param name="queries"></param>
    /// <returns></returns>
    public int[] solution6(int rows, int columns, int[,] queries)
    {
        int[] answer = new int[queries.GetLength(0)];

        //int[,] SquareArray = new int[rows, columns];
        //int num = 1;
        //for (int i = 0; i < rows; i++)
        //{
        //    for (int j = 0; j < columns; j++)
        //    {
        //        SquareArray[i, j] = num;
        //        num++;
        //    }
        //}
        //for (int a = 0; a < answer.Length; a++)
        //{
        //    int TempArrayNum = 2 * (queries[0, 2] + queries[0, 3] - queries[0, 1] - queries[0, 0]);
            //int[] TempArray = new int[TempArrayNum];
            //int TempNum = 0;

        //    for (int i = 0; i < rows; i++)
        //    {
        //        for (int j = 0; j < columns; j++)
        //        {
        //            if ((i == queries[0, 0] && (j < queries[0, 3] && j >= queries[0, 1])) || (j == queries[0, 3] && (i <= queries[0, 2] && i > queries[0, 0])))
        //            {
        //                TempArray[TempNum] = SquareArray[i, j];
        //                if (TempNum != 0) SquareArray[i, j] = TempArray[TempNum - 1];
        //                TempNum++;
        //            }
        //        }
        //    }
        //    for (int i = rows - 1; i < -1; i--)
        //    {
        //        for (int j = columns - 1; j < -1; j--)
        //        {
        //            if ((i == queries[0, 2] && (j < queries[0, 3] && j >= queries[0, 1])) || (j == queries[0, 1] && (j < queries[0, 3] && j >= queries[0, 1])))
        //            {
        //                TempArray[TempNum] = SquareArray[i, j];
        //                if (TempNum != TempArrayNum - 1) SquareArray[i, j] = TempArray[TempNum - 1];
        //                else SquareArray[i, j] = TempArray[0];
        //                TempNum++;
        //            }
        //        }
        //    }

        //    int t = TempArray[0];
        //    for (int i = 0; i < TempArray.Length; i++) { if (t > TempArray[i]) t = TempArray[i]; }
        //    answer[a] = t;
        //}
        return answer;
    }

    /// <summary>
    /// 두 정수 a, b가 주어졌을 때 a와 b 사이에 속한 모든 정수의 합을 리턴하는 함수, solution을 완성하세요.
    /// 예를 들어 a = 3, b = 5인 경우, 3 + 4 + 5 = 12이므로 12를 리턴합니다.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public long solution7(int a, int b)
    {
        int answer = 0;
        if (a > b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        else if (a == b) return a;
        for (int i = a; i < b + 1; i++)
        {
            answer += i;
        }
        return answer;
    }

    void Start()
    {
        
    }
}
