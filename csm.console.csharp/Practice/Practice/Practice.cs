using System;

public class Solution
{
    public string solution(string my_string)
    {
        string answer = "";

        char[] vowel = new char[5] { 'a', 'e', 'i', 'o', 'u' };
        int[] deleteIndex = new int[my_string.Length];

        for(int i =0; i<my_string.Length; i++)
        {
            for(int j=0; j<vowel.Length; j++)
            {
                if (my_string[i] == vowel[j])
                {
                    deleteIndex[i] = 1;
                }
            }
        }

        string res = DeleteIndex(my_string, deleteIndex);
        answer = res;

        return answer;
    }

    string DeleteIndex(string myString, int[] deleteIndex)
    {
        string res = "";

        for(int i=0; i<myString.Length; i++)
        {
            if (deleteIndex[i] != 1)
            {
                res += myString[i];
            }
        }

        return res;
    }

}