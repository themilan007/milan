/*
//vezérlési szerkezetel

Console.WriteLine("irj be egy egész számot");
string st = Console.ReadLine();
int number = int.Parse(st);
bool iseven; //páros-e
iseven = number % 2 == 0;
if (iseven)
{
    Console.WriteLine("páros");// ctrl + k + d auto formázás
}
else
{
    Console.WriteLine("páratlan");
}
if (number > 0)
{
    Console.WriteLine("pozitiv");
}
else if (number < 0) 
{
    Console.WriteLine("negativ");
}
else
{
    Console.WriteLine("nulla");
}

//switch

string isevenstring;
if (iseven)
{
    isevenstring = "páros";// ctrl + k + d auto formázás
}
else
{
    isevenstring = "páratlan";
}
Console.WriteLine(isevenstring);

string isevenstring2 = iseven ? "páros" ; "páreatlan";//feltételes operátor
//3 bemenete ugyanaz a tipusu
//ciklus

int i = 0;
while (i <10)
{
    Console.WriteLine(i);
    ;//i= i + 1
}
*/
