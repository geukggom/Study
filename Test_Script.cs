using System;
using System.Collections.Generic;

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
    /// 두 정수 a, b가 주어졌을 때 a와 b 사이에 속한 모든 정수의 합을 리턴하는 함수, solution을 완성하세요.
    /// 예를 들어 a = 3, b = 5인 경우, 3 + 4 + 5 = 12이므로 12를 리턴합니다.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public long solution6(int a, int b)
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

    /// <summary>
    /// 수포자는 수학을 포기한 사람의 준말입니다. 수포자 삼인방은 모의고사에 수학 문제를 전부 찍으려 합니다. 수포자는 1번 문제부터 마지막 문제까지 다음과 같이 찍습니다.
    /// 1번 수포자가 찍는 방식: 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, ...
    /// 2번 수포자가 찍는 방식: 2, 1, 2, 3, 2, 4, 2, 5, 2, 1, 2, 3, 2, 4, 2, 5, ...
    /// 3번 수포자가 찍는 방식: 3, 3, 1, 1, 2, 2, 4, 4, 5, 5, 3, 3, 1, 1, 2, 2, 4, 4, 5, 5, ...
    /// </summary>
    /// <param name="answers">정답인 배열</param>
    /// <returns></returns>
    public int[] solution7(int[] answers)
    {
        int best = 0;
        int correct = 0;
        int[] person1 = new int[5] { 1, 2, 3, 4, 5 }; 
        int[] person2 = new int[8] { 2, 1, 2, 3, 2, 4, 2, 5 }; 
        int[] person3 = new int[10] { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 };
        int[] correctAnswer = new int[3];
        for (int a = 0; a < 3; a++)
        {
            correctAnswer[a] = 0;
            int[] person = new int[] { };
            if (a == 0) person = person1; 
            else if (a == 1) person = person2; 
            else person = person3; 
            for (int i = 0; i < answers.Length; i++)
            {
                if (person[i % person.Length] == answers[i]) correctAnswer[a]++;
            }
            if (correctAnswer[a] > best)
            {
                best = correctAnswer[a];
                correct = 1;
            }
            else if(correctAnswer[a] == best) correct++;

        }
        int[] answer = new int[correct];
        int newindex = 0;
        for (int i = 0; i < correctAnswer.Length; i++)
        {
            if (correctAnswer[i] == best)
            {
                answer[newindex] = i + 1;
                newindex++;
            }
        }
        return answer;
    }
    public int[] solution7Again(int[] answers)
    {
        int best = 0;
        int[] person1 = new int[5] { 1, 2, 3, 4, 5 };
        int[] person2 = new int[8] { 2, 1, 2, 3, 2, 4, 2, 5 };
        int[] person3 = new int[10] { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 };
        List<int> answer = new List<int>();
        int[] correctAnswer = new int[3];
        for (int i = 0; i < answers.Length; i++)
        {
            if (person1[i % person1.Length] == answers[i]) ++correctAnswer[0];
            if (person2[i % person2.Length] == answers[i]) ++correctAnswer[1];
            if (person3[i % person3.Length] == answers[i]) ++correctAnswer[2];
        }
        for (int i = 0; i < correctAnswer.Length; i++)
        {
            if(correctAnswer[i] > best)
            {
                best = correctAnswer[i];
                answer.Clear();
                answer.Add(i + 1);
            }
            else if(correctAnswer[i] == best) { answer.Add(i+1); }
        }
        return answer.ToArray();
    }

    /// <summary>
    /// rows x columns 크기인 행렬이 있습니다. 행렬에는 1부터 rows x columns까지의 숫자가 한 줄씩 순서대로 적혀있습니다. 
    /// 이 행렬에서 직사각형 모양의 범위를 여러 번 선택해, 테두리 부분에 있는 숫자들을 시계방향으로 회전시키려 합니다.
    /// 그 회전에 의해 위치가 바뀐 숫자들 중 가장 작은 숫자들을 순서대로 배열에 담아 return 하도록 solution 함수를 완성해주세요.
    /// </summary>
    /// <param name="rows">행</param>
    /// <param name="columns">열</param>
    /// <param name="queries">회전 행렬 목록(row1,column1,row2,column2)</param>
    /// <returns></returns>
    public int[] solution8(int rows, int columns, int[,] queries)
    {
        int[] answer = new int[queries.GetLength(0)];
        int[,] TestArray = new int[rows, columns];
        int columnNum = 0;
        int rowNum = 0;
        for (int i = 0; i < TestArray.Length; i++)
        {
            TestArray[rowNum, columnNum] = i + 1; //처음 행렬 설정
            columnNum++;
            if (columnNum == columns)
            {
                rowNum++;
                columnNum = 0;
            }
        }
        List<int> chosenArray = new List<int>();
        for (int i = 0; i < answer.Length; i++)
        {
            chosenArray.Clear();
            int TempArrayNum = 2 * (queries[i, 2] + queries[i, 3] - queries[i, 1] - queries[i, 0]);
            int Row = queries[i, 0] - 1;
            int Column = queries[i, 1] - 1;
            int rowCount = queries[i, 3] - queries[i, 1];
            int columnCount = queries[i, 2] - queries[i, 0];
            for (int j = 0; j < TempArrayNum; j++)
            {
                chosenArray.Add(TestArray[Row, Column]);
                if(j!=0) TestArray[Row, Column] = chosenArray[j - 1];
                if (j < rowCount) Column++;
                else if (j >= rowCount && j < (rowCount + columnCount)) Row++;
                else if (j >= (rowCount + columnCount) && j < (rowCount * 2 + columnCount)) Column--;
                else Row--;
            }
            TestArray[queries[i, 0] - 1, queries[i, 1] - 1] = chosenArray[TempArrayNum - 1];
            int leastNum = chosenArray[0];
            for (int k = 1; k < chosenArray.Count; k++)
            {
                if (chosenArray[k] < leastNum) leastNum = chosenArray[k];
                
            }
            answer[i] = leastNum;
        }
        return answer;
    }

    /// <summary>
    /// 자연수 n이 매개변수로 주어집니다. n을 3진법 상에서 앞뒤로 뒤집은 후, 이를 다시 10진법으로 표현한 수를 return 하도록 solution 함수를 완성해주세요.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int solution9(int n)
    {
        List<int> List_Num = new List<int>();
        while (true)
        {
            List_Num.Add(n % 3);
            int newNum = n / 3;
            if (newNum == 0) break;
            else n = newNum;
        }
        int answer = 0;
        for (int i = 0; i < List_Num.Count; i++)
        {
            int a = 1;
            for (int j = 0; j < List_Num.Count - i -1; j++) { a *= 3; }
            answer += List_Num[i] * a;
        }
        return answer;
    }

    /// <summary>
    /// 정수 배열 numbers가 주어집니다. 
    /// numbers에서 서로 다른 인덱스에 있는 두 개의 수를 뽑아 더해서 만들 수 있는 모든 수를 배열에 오름차순으로 담아 
    /// return 하도록 solution 함수를 완성해주세요.
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public int[] solution10(int[] numbers)
    {
        List<int> answerNum = new List<int>();
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < numbers.Length; j++)
            {
                if (j > i)
                {
                    int plusNum = numbers[i] + numbers[j];
                    bool is_same = false;
                    for (int k = 0; k < answerNum.Count; k++)
                    {
                        if (plusNum == answerNum[k]) is_same = true;
                    }
                    if (!is_same) answerNum.Add(plusNum);
                } 
            }
        }
        for (int i = 1; i < answerNum.Count; i++)
        {
            if(answerNum[i] < answerNum[i-1])
            {
                int temp = answerNum[i];
                answerNum[i] = answerNum[i - 1];
                answerNum[i-1] = temp;
                i = 0;
            }
        }
        return answerNum.ToArray();
    }
    public int[] solution10Again(int[] numbers)
    {
        List<int> answerNum = new List<int>();
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                int plusNum = numbers[i] + numbers[j];
                if (answerNum.Contains(plusNum)) answerNum.Add(plusNum);
            }
        }
        answerNum.Sort();
        return answerNum.ToArray();
    }

    /// <summary>
    /// 정수 n이 매개변수로 주어집니다. 
    /// 밑변의 길이와 높이가 n인 삼각형에서 맨 위 꼭짓점부터 반시계 방향으로 달팽이 채우기를 진행한 후, 
    /// 첫 행부터 마지막 행까지 모두 순서대로 합친 새로운 배열을 return 하도록 solution 함수를 완성해주세요.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[] solution11(int n)
    {
        int[,] indexNum = new int[n, n];
        int row = -1;
        int column = 0;
        int num2 = 1;

        for (int i = 0; i < n; i++)
        {
            int replayNum = n - i;
            for (int k = 0; k < replayNum; k++)
            {
                if (i % 3 == 0) row += 1;
                else if (i % 3 == 1) column += 1;
                else
                {
                    column -= 1;
                    row -= 1;
                }
                indexNum[row, column] = num2;
                num2++;
            }
        }
        List<int> answer = new List<int>();
        for (int i = 0; i < n; i++)
        {
            for (int k = 0; k < n; k++)
            {
                if (indexNum[i, k] != 0) answer.Add(indexNum[i, k]);
            }
        }
        return answer.ToArray();
    }

    /// <summary>
    /// 0과 1로 이루어진 어떤 문자열 x에 대한 이진 변환을 다음과 같이 정의합니다.
    /// x의 모든 0을 제거합니다.
    /// x의 길이를 c라고 하면, x를 "c를 2진법으로 표현한 문자열"로 바꿉니다.
    /// </summary>
    /// <param name="s">문자 길이</param>
    /// <returns>[이진 변환의 횟수, 변환 과정에서 제거된 모든 0의 개수]</returns>
    public int[] solution12(string s)
    {
        int[] answer = new int[2];
        string newS = s;
        while (true)
        {
            answer[0]++;
            char[] chars = newS.ToCharArray();
            int num1 = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '0') answer[1]++;
                else num1++;
            }
            int a = num1;
            List<int> list1 = new List<int>();
            while (true)
            {
                list1.Add(a % 2);
                if (a / 2 == 0) break;
                else a = a / 2;
            }
            newS = "";
            for (int i = list1.Count - 1; i > -1; i--) { newS += list1[i].ToString(); }
            if (newS == "1") break;
        }
        return answer;
    }

    /// <summary>
    /// 0과 1로 이루어진 2n x 2n 크기의 2차원 정수 배열 arr이 있습니다. 이 arr을 쿼드 트리와 같은 방식으로 압축하고자 합니다.
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public int[] solution13(int[,] arr)
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

    /// <summary>
    /// 인접한 두 풍선 중에서 번호가 더 작은 풍선을 터트리는 행위는 최대 1번만 할 수 있습니다. 
    /// 즉, 어떤 시점에서 인접한 두 풍선 중 번호가 더 작은 풍선을 터트렸다면, 그 이후에는 인접한 두 풍선을 고른 뒤 번호가 더 큰 풍선만을 터트릴 수 있습니다.
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public int solution14(int[] a)
    {
        int answer = 2;
        int smallest = a[0];
        int smallestNum = 0;
        for (int i = 1; i < a.Length; i++)
        {
            if (smallest > a[i])
            {
                smallest = a[i];
                smallestNum = i;
            }
        }
        int left = a[0];
        int right = a[a.Length - 1];
        for (int i = a.Length - 2; i > smallestNum; i--)
        {
            if (right > a[i + 1]) right = a[i + 1];
            if (a[i] < right) answer++;
        }
        for (int i = 1; i < smallestNum; i++)
        {
            if (left > a[i - 1]) left = a[i - 1];
            if (a[i] < left) answer++;
        }
        if (smallestNum != 0 && smallestNum != a.Length - 1) answer++;
        return answer;
    }

    /// <summary>
    /// 한자리 숫자가 적힌 종이 조각이 흩어져있습니다. 흩어진 종이 조각을 붙여 소수를 몇 개 만들 수 있는지 알아내려 합니다.
    /// 각 종이 조각에 적힌 숫자가 적힌 문자열 numbers가 주어졌을 때, 종이 조각으로 만들 수 있는 소수가 몇 개인지 return 하도록 solution 함수를 완성해주세요.
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public int solution15(string numbers)
    {
        char[] numberArray = numbers.ToCharArray();
        List<int> numberList = new List<int>();
        List<int> indexList = new List<int>();
        for (int i = 0; i < numberArray.Length; i++)
        {
            numberList.Add(numberArray[i] - '0');
        }
        for (int i = 1; i <= numberArray.Length; i++)  //몇글자인지
        {
            plusNum(i, numberList, indexList, "");
        }
        int answer = 0;
        for (int i = 0; i < answerlist.Count; i++)
        {
            if (is_prime(answerlist[i])) answer++;
        }
        return answer;
    }
    public List<int> answerlist = new List<int>();
    void plusNum(int stringNum, List<int> numberList, List<int> indexList, string makeNum)
    {
        string tempmakeNum = makeNum;
        for (int i = 0; i < numberList.Count; i++)
        {
            if (!indexList.Contains(i))
            {
                makeNum = tempmakeNum + numberList[i].ToString();
                indexList.Add(i);
                int n = int.Parse(makeNum);
                if(stringNum == makeNum.Length && !answerlist.Contains(n)) answerlist.Add(n);
                else if(stringNum != makeNum.Length) plusNum(stringNum, numberList, indexList, makeNum);
                indexList.RemoveAt(indexList.Count - 1);
            }

        }
    }
    bool is_prime(int num)
    {
        if (num < 2) return false;
        bool is_true = true;
        for (int i = 2; i <= num/2; i++)
        {
            if (num % i == 0) is_true = false;
        }
        return is_true;
    }

    void Start()
    {
        
    }
}
