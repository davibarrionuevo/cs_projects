Console.WriteLine("This is the four basic operations calculator.");
Console.WriteLine("Input the first number:");
string firstInput = Console.ReadLine();
int number1 = int.Parse(firstInput);
// parses the first input into an integer
Console.WriteLine("Input the second number:");
string secondInput = Console.ReadLine();
int number2 = int.Parse(secondInput);
// parses the second input into an integer
Console.WriteLine("What do you want to do with those numbers?");
Console.WriteLine("[A]dd");
Console.WriteLine("[S]ubtract");
Console.WriteLine("[M]ultiply");
Console.WriteLine("[D]ivide");
string operationChoice = Console.ReadLine();
if (EqualsCaseInsensitive(operationChoice, "A"))
{
    var addition = number1 + number2;
    PrintFinalEquation(number1, number2, addition, "+");
}
else if (EqualsCaseInsensitive(operationChoice, "S"))
{
    var subtraction = number1 - number2;
    PrintFinalEquation(number1, number2, subtraction, "-");
}
else if (EqualsCaseInsensitive(operationChoice, "M"))
{
    var multiplication = number1 * number2;
    PrintFinalEquation(number1, number2, multiplication, "*");
}
else if (EqualsCaseInsensitive(operationChoice, "D"))
{
    var division = number1 / number2;
    PrintFinalEquation(number1, number2, division, "/");
}
else
{
    Console.WriteLine("Invalid option!");
}

Console.WriteLine("Press any key to close");
Console.ReadKey();

// this method gathers the operation components and prints it into an equation
void PrintFinalEquation(int number1, int number2, int result, string @operator)
{
    Console.WriteLine(number1 + " " + @operator + " " + number2 + " = " + result);
}

// this method checks if the operationChoice input given by the user is equal to a certain letter,
// whether upper or lowercase, that will select the operation to be done:
// A or a for addition, S or s for subtraction, M or m for multiplication, D or d for division
bool EqualsCaseInsensitive(string left, string right)
{
    return left.ToUpper() == right.ToUpper();
}