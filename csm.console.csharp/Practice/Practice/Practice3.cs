class Practice3
{
    public static string solution(string cipher, int code)
    {
        string answer = "";
        
        int index = -1; 


        while (index + code < cipher.Length)
        {
            index += code;
            answer += cipher[index]; // string은 char 배열의 형태이기 때문에, 인덱서를 사용하여 값에 접근할 수 있다.
            
        }

        return answer;
    }
}



