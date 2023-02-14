
/*
//1 feladata
int x = 3, y = 3, z = 5, q = 9, m = 11;
float d = (x + y + z + q + m) / 5f;
Console.WriteLine("az átlag a 2,3,5,9,11-nek");
Console.Write(d);

Console.Write("adjon meg a kör sugarát: ");
string sugár = Console.ReadLine();
float xy = float.Parse(sugár);

float p = 3.14f;
float számolás = 2 * xy * p;
float számolás2 = xy * xy * p;
Console.Write(számolás);
Console.Write(számolás2);

Console.WriteLine("irj egy számot");
string aa = Console.ReadLine();
int number = int.Parse(aa);
int ggg = 0;
for (int xxy = 1; xxy <= number; xxy++)
    ggg += xxy;
Console.WriteLine(ggg);


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

for (int jjj = 1; jjj <= 10; jjj++)
{
   for (int jjj2 = 1; jjj2 <= 10; jjj2++)
    {


        Console.WriteLine(jjj + "*" + jjj2 + "=" + jjj * jjj2); 
        
    }
}
//házi 2-----------------------------------------------------------------

float clamp(float a, float b, float c)
{
    if (a <= b)
    {
        return b;
    }
    else if (a >= c)
    {
        return c;
    }
    else
    {
        return a;
    }
}

float ceiling( float cc)
{
    float ww = cc % 1;
    float kk = cc - ww;
    kk = kk++;
}

float ceiling(float xd)
{
    float we = xd % 1;
    float kh = xd - we;
    if (xd == 0)
    {

        return xd;
    }
    else
    {

        return kh++;
    }

}

float round(float cd)
{
    float sb = cd % 1;
    float ddr = cd - sb;
    if (sb >= 0.5)
    {

        return ddr++;


    }

    else
    {

        return ddr;

    }

}
bool prim(int ffs)
{
    for (int fks = 2; fks <= ffs; fks++)
    {
        if (ffs % fks == 0) ;
        return false;


    }
    return true;
}


int fv(int rdd, int cod)
{
    int uganda = Math.Max(rdd, cod);
    int uganda2 = Math.Min(rdd, cod);
    int ww2 = uganda2 / 2;
    for (int zw = ww2; zw > 1; zw--)
    {
        if (rdd % zw == 0 && cod % zw == 0)
        {
            return zw;

        }
    }

    return 1;
}


int fpp(int rddd, int codd, int bdd)
{
    int uganda3 = Math.Max(rddd, codd);
    int nuk = Math.Max(uganda3, bdd);
    int uganda4 = Math.Min(rddd, codd);
    int sugar = Math.Min(uganda4, bdd);
    int tarzan = rddd + codd + bdd - nuk - sugar;
    int szam = nuk * nuk;
    int szam2 = sugar * sugar + tarzan * tarzan;
    if (szam2 == szam)
    {
        return 1;
    }
    return 0;
}
*/











