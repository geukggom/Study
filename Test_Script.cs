﻿using System;

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

    void Start()
    {
        
    }
}
