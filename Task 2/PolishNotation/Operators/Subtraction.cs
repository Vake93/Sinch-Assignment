namespace PolishNotation.Operators;

public class Subtraction : Operator
{
    public override int RequiredTermCount => 2;

    public override double? Evaluate(Stack<double> numbers)
    {
        if (Validate(numbers))
        {
            var number1 = numbers.Pop();
            var number2 = numbers.Pop();

            return number1 - number2;
        }

        return null;
    }
}
