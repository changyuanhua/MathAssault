using System;
using System.Collections;
using System.Collections.Generic;

public class math_questions
{
    public math_questions(difficulty diff)
    {
        range random_range;
        switch (diff)
        {
            case difficulty.Easy:
                random_range = new range(0, 10);
                break;
            case difficulty.Normal:
                random_range = new range(10, 20);
                break;
            case difficulty.Hard:
                random_range = new range(20, 50);
                break;
            default:
                random_range = new range(0, 10);
                break;
        }
        Random random = new Random();
        math_operator = RandomEnumValue<operators>();
        first_value = random.Next(random_range.min, random_range.max);
        second_value = random.Next(random_range.min, random_range.max);
        switch (math_operator)
        {
            case operators.Addition:
                answer = first_value + second_value;
                break;
            case operators.Subtraction:
                answer = first_value - second_value;
                break;
            case operators.Multiplication:
                answer = first_value * second_value;
                break;
            default:
                answer = 0;
                break;
        }
    }

    static T RandomEnumValue<T>()
    {
        var value = Enum.GetValues(typeof(T));
        return (T)value.GetValue(new Random().Next(value.Length));
    }

    public string OperatorToString()
    {
        string op;
        switch (math_operator)
        {
            case operators.Addition:
                op = "+";
                break;
            case operators.Subtraction:
                op = "-";
                break;
            case operators.Multiplication:
                op = "*";
                break;
            default:
                op = " ";
                break;
        }
        return op;
    }

    public struct range
    {
        public int min, max;
        public range(int x, int y)
        {
            min = x;
            max = y;
        }
    }

    public readonly operators math_operator;
    public readonly int first_value;
    public readonly int second_value;
    public readonly int answer;
}
