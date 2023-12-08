int finalAnswer = 0;

Dictionary<string, int> digits = new Dictionary<string, int>
{
    { "one",    1 },
    { "two",    2 },
    { "three",  3 },
    { "four",   4 },
    { "five",   5 },
    { "six",    6 },
    { "seven",  7 },
    { "eight",  8 },
    { "nine",   9 },
    { "zero",   0 }
};

StreamReader sr = new StreamReader("input.txt");
string line = sr.ReadLine();

while (line != null)
{
    int firstDigit = SearchStringForNum(line, SearchType.First);
    int secondDigit = SearchStringForNum(line, SearchType.Last);

    finalAnswer += Convert.ToInt32(firstDigit.ToString() + secondDigit.ToString());

    line = sr.ReadLine();
}

Console.WriteLine(finalAnswer.ToString());

int SearchStringForNum(string input, SearchType searchType)
{
    if (searchType == SearchType.Last)
    {
        input = new string(input.Reverse().ToArray());
    }

    for (int i = 0; i < input.Length; i++)
    {
        int maxStringLength = Math.Min(digits.Keys.Max(x => x.Length), input.Length - i);

        for (int j = 1; j <= maxStringLength; j++)
        {
            string subInput = input.Substring(i, j);

            if (int.TryParse(subInput, out int subInputInt))
            {
                return subInputInt;
            }

            if (digits.Keys.Contains(searchType == SearchType.First ? subInput : new string(subInput.Reverse().ToArray())))
            {
                return digits[searchType == SearchType.First ? subInput : new string(subInput.Reverse().ToArray())];
            }
        }
    }

    throw new Exception("Did not find int in string");
}

enum SearchType
{
    First,
    Last
}