using System.Text;
using System.Security.Cryptography;

string CreateMD5(string myText)
{
    var hash = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(myText ?? ""));
    return string.Join("", Enumerable.Range(0, hash.Length).Select(i => hash[i].ToString("x2")));
}

Console.Write("Enter First MD5 -> ");
var FirstMD5 = Console.ReadLine();

Console.Write("Enter Round -> ");
var Round = Console.ReadLine();

long MaxNumber = 999999999999999999;

for (int n = 0; n < MaxNumber; n++)
{
    for (int i = 1; i <= 100; i++)
    {
        var GeneratedNumber = n.ToString("000000000000000000");

        string FinalString = $"{Round}.{i}.{GeneratedNumber}";

        var FinalMD5 = CreateMD5(FinalString);

        Console.WriteLine(FinalString);

        if (FirstMD5 == FinalMD5)
        {
            Console.WriteLine(i);
            Console.ReadLine();
        }
    }
}