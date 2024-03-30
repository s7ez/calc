const int idx = 0;

string[] texts = ["12345", "67890"];
Console.WriteLine("debug: " + string.Join('+', texts) + '=' + (double.Parse(texts[0]) + double.Parse(texts[1])));

int length = texts[idx].Length;
Console.WriteLine("list length: " + length);

List<char> preList = [.. texts[idx]];
Console.WriteLine("preList: " + string.Join(null, preList));

preList.RemoveAt(length - 1);
Console.WriteLine("afterList: " + string.Join(null, preList));

texts[idx] = string.Join(null, preList);
Console.WriteLine("final: " + string.Join('+', texts) + '=' + (double.Parse(texts[0]) + double.Parse(texts[1])));
