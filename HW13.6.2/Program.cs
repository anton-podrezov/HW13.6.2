string Text = File.ReadAllText("C:\\Text1.txt");

var noPunctuationText = new string(Text.Where(c => !char.IsPunctuation(c)).ToArray());

string[] Subs = noPunctuationText.Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

Dictionary<string, int> Words = new Dictionary<string, int>();

foreach (string item in Subs)
{
    if (Words.ContainsKey(item))
    {
        Words[item]++;
    }
    else
    {
        Words.Add(item, 1);
    }
}

var top10 = Words.OrderByDescending(mostWord => mostWord.Value).Take(10);

Console.WriteLine("10 слов, наиболее часто встречающихся в Тексте:");

foreach (var item in top10)
{
    Console.WriteLine($"Слово \'{item.Key}\'  встречается в тексте {item.Value} раз");
}
