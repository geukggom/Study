using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTracking : MonoBehaviour
{
    void Start()
    {
        nQueen(5);
    }

    public void nQueen(int n)
    {
        List<int> answer = new List<int>();
        int row = 0;
        int column = 0;
        bool is_wrongColumn = false;
        while (true)
        {
            if(is_wrongColumn || column == n) //답이 나온 경우 + 현재 row에 배치할 column이 없는 경우 
            {
                is_wrongColumn = false;
                column = answer[answer.Count - 1] + 1; //이전 행의 column+1을 가져옴
                row = answer.Count - 1; //이전 행의 row 가져옴
                if (row == 0 && column == n) return; //모든 경우의 수를 체크한 후, return
                answer.RemoveAt(answer.Count - 1); //list에 추가했던 이전 row를 지움
                continue;
            }
            if (is_available(answer, column)) //지금까지의 리스트에 현재 column이 맞는지 확인
            {
                answer.Add(column);
                row++;
                column = 0;
            }
            else column++;
            if (answer.Count == n)
            {
                string st = "";
                for (int i = 0; i < n; i++)
                {
                    st += answer[i].ToString();
                }
                Debug.Log(st);
                is_wrongColumn = true;
            }
        }
    }

    //이제까지 만든 리스트가 조건에 맞는지 확인 = Promising
    public bool is_available(List<int> candidateList, int column)
    {
        if (candidateList.Count < 1) return true; //리스트에 한개만 있을 때는 그냥 추가
        int row = candidateList.Count;
        for (int i = 0; i < row; i++)
        {
            //대각선일 때 || column 같을 때
            if (Mathf.Abs(candidateList[i] - column) == row - i
                || candidateList[i] == column) return false;
        }
        return true;
    }
}
