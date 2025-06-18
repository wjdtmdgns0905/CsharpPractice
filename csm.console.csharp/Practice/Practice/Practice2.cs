using System;
using System.Diagnostics;

public class Practice2
{
    public string solution(int age)
    {
        string answer = "";
        int numberCount= 0;

        
        int digit1000 = age / 1000;
        age %= 1000;
        int digit100 = age / 100;
        age %= 100;
        int digit10 = age / 10;
        age %= 10;
        int digit1 = age;

        if (digit1000 != 0)
        {
            answer += (char)(digit1000+97);
            numberCount++;
        }
        if(numberCount != 0 || digit100 !=0)
        {
            answer += (char)(digit100+97);
            numberCount++;
        }
        if (numberCount != 0 || digit10 != 0)
        {
            answer += (char)(digit10 + 97);
            numberCount++;
        }
        if (numberCount != 0 || digit1 != 0)
        {
            answer += (char)(digit1 + 97);
            numberCount++;
        }


        return answer;

    }
}