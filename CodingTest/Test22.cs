using System;
using System.Text;

public class Test22  // : 가장 큰 수
{
    /// <summary>
    /// 정수를 이어 붙여 만들 수 있는 가장 큰 수를 알아내 주세요.
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public string solution(int[] numbers)
    {
        string[] nn = Array.ConvertAll(numbers, a => a.ToString());
        Array.Sort(nn, (x, y) => string.Compare(y + x, x + y));
        if (nn[0] == "0") return "0";
        StringBuilder answer = new StringBuilder();
        for (int i = 0; i < nn.Length; i++) answer.Append(nn[i]);
        return answer.ToString();
    }
}
