using System;

public class Test4  // : 소수만들기
{
    /// <summary>
    /// 주어진 숫자 중 3개의 수를 더했을 때 소수가 되는 경우의 개수를 구하려고 합니다. 
    /// 숫자들이 들어있는 배열 nums가 매개변수로 주어질 때, nums에 있는 숫자들 중 서로 다른 3개를 골라 더했을 때 소수가 되는 경우의 개수를 return 하도록 solution 함수를 완성해주세요.
    /// </summary>
    /// <param name="nums">1~1000의 자연수 배열(배열 길이는 3~50)</param>
    /// <returns></returns>
    public int solution(int[] nums)
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
                if (numberSum[i] % j == 0) { is_true = false; }
            }
            if (is_true) answer++;
        }
        return answer;
    }
}
