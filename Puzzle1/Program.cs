const int puzzleVer = 1;
int finalAnswer = 0;

StreamReader sr = new StreamReader("input.txt");
string line = sr.ReadLine();

while (line != null)
{
    switch(puzzleVer)
    {
        case 1:
            {
                string numString = new string(line.Where(char.IsDigit).ToArray());
                string finalAnswerString = numString[0].ToString() + numString[numString.Length - 1].ToString();
                finalAnswer += Convert.ToInt32(finalAnswerString);
                break;
            }
        default:
            throw new Exception("Incorrect Puzzle Version");
    }

    line = sr.ReadLine();
}

Console.WriteLine(finalAnswer.ToString());