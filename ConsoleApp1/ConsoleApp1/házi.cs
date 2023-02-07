/*
//1. feladat
int x = 3, y = 3, z = 5, q = 9, m = 11;
float d = (x + y + z + q + m) / 5f;
Console.WriteLine("az átlag a 3,3,5,9,11-nek");
Console.Write(d);


//2. feladat
Console.Write("adjon meg a kör sugarát: ");
string sugár = Console.ReadLine();
float xy = float.Parse(sugár);

float p = 3.14f;
float számolás = 2 * xy * p;
float számolás2 = xy * xy * p;
Console.Write(számolás);
Console.Write(számolás2);


//3. feladat
Console.WriteLine("irj egy számot");
string aa = Console.ReadLine();
int number = int.Parse(aa);
int ggg = 0;
for (int xxy = 1; xxy <= number; xxy++)
    ggg += xxy;
Console.WriteLine(ggg);


//4. feladat
Console.WriteLine("irj be egy számot");
string ttt = Console.ReadLine();
int number3 = int.Parse(ttt);
for (int abc = 1; abc <= number3; abc++)
{
    bool fizz = abc % 3 == 0;
    bool buzz = abc % 5 == 0;

    if (fizz && buzz)
    {
        Console.WriteLine("fizzbuzz");
    }
    else if (fizz)
    {
        Console.WriteLine("fizz");
    }
    else if (buzz)
    {
        Console.WriteLine("buzz");
    }
    else
    {
        Console.WriteLine(abc);
    }
}
?=


//5. feladat
for (int jjj = 1; jjj <= 10; jjj++)
{
    for (int jjj2 = 1; jjj2 <= 10; jjj2++)
    {


        Console.WriteLine(jjj + "*" + jjj2 + "=" + jjj * jjj2);

    }
}



*/