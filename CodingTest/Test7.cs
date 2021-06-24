using System;
using System.Collections.Generic;

public class Test7  // : 모의고사
{
    /// <summary>
    /// 수포자는 수학을 포기한 사람의 준말입니다. 수포자 삼인방은 모의고사에 수학 문제를 전부 찍으려 합니다. 수포자는 1번 문제부터 마지막 문제까지 다음과 같이 찍습니다.
    /// 1번 수포자가 찍는 방식: 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, ...
    /// 2번 수포자가 찍는 방식: 2, 1, 2, 3, 2, 4, 2, 5, 2, 1, 2, 3, 2, 4, 2, 5, ...
    /// 3번 수포자가 찍는 방식: 3, 3, 1, 1, 2, 2, 4, 4, 5, 5, 3, 3, 1, 1, 2, 2, 4, 4, 5, 5, ...
    /// </summary>
    /// <param name="answers">정답인 배열</param>
    /// <returns></returns>
    public int[] solution(int[] answers)
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
            else if (correctAnswer[a] == best) correct++;

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
            if (correctAnswer[i] > best)
            {
                best = correctAnswer[i];
                answer.Clear();
                answer.Add(i + 1);
            }
            else if (correctAnswer[i] == best) { answer.Add(i + 1); }
        }
        return answer.ToArray();
    }
}
