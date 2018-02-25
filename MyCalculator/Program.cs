using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator
{
    class Program
    {
        enum Op { Add, Subtract, Multiply, Divide };
        static string Nl = Environment.NewLine;

        /*
         * Executes calculator loop that gathers user input and prints the result.
         */
        static void Main(string[] args)
        {
            while (true)
            {
                int val1 = getVal();
                int val2 = getVal();
                Op op = getOp();
                string result = execute(val1, val2, op);
                Console.WriteLine("Final result: {0}{1}", result, Nl);
            }
        }

        /*
         * Returns input int after prompting the user.
         */
        static int getVal()
        {
            Console.Write("Please enter a number: ");
            string input = Console.ReadLine();
            int val;
            bool success = Int32.TryParse(input, out val);

            while (!success)
            {
                Console.Write("Please enter a valid number: ");
                input = Console.ReadLine();
                success = Int32.TryParse(input, out val);
            }
            // val contains parsed int

            return val;
        }

        /*
         * Returns input operator after prompting the user.
         */
        static Op getOp()
        {
            Console.Write("Please select (A)ddition, (S)ubtraction," + Nl +
                "(M)ultiplication, or (D)ivision: ");
            char input = Console.ReadKey(true).KeyChar;
            Console.WriteLine(); // add newline after user input

            switch (Char.ToUpper(input))
            {
                case 'A':
                    return Op.Add;

                case 'S':
                    return Op.Subtract;

                case 'M':
                    return Op.Multiply;

                case 'D':
                    return Op.Divide;

                default:
                    Console.WriteLine("Invalid operation");
                    return getOp();
            }

        }

        /*
         * Returns string representing result of math expression with values
         * [v1] and [v2] and operation [op].
         */
        static string execute(int v1, int v2, Op op)
        {
            switch (op)
            {
                case Op.Add:
                    return exAdd(v1, v2);

                case Op.Subtract:
                    return exSub(v1, v2);

                case Op.Multiply:
                    return exMult(v1, v2);

                case Op.Divide:
                    return exDiv(v1, v2);

            }

            return ""; // execution will never reach here
        }

        /*
         * Returns string representing result of addition expression [v1+v2].
         */
        static string exAdd(int v1, int v2)
        {
            int result = v1 + v2;

            return $"{v1} + {v2} = {result}";
        }

        /*
         * Returns string representing result of subtraction expression [v1-v2].
         */
        static string exSub(int v1, int v2)
        {
            int result = v1 - v2;

            return $"{v1} - {v2} = {result}";
        }

        /*
         * Returns string representing result of multiplication expression [v1*v2].
         */
        static string exMult(int v1, int v2)
        {
            int result = v1 * v2;

            return $"{v1} * {v2} = {result}";
        }

        /*
         * Returns string representing result of division expression [v1/v2].
         * 
         * Handles division by zero by prompting user for new value.
         */
        static string exDiv(float v1, float v2)
        {
            float result;

            if (v2 == 0)
            {
                Console.WriteLine("Cannot divide by zero. You need a " +
                    "valid divisor.");
                v2 = getVal();

                return exDiv(v1, v2);
            }
            else
            {
                result = v1 / v2;
            }

            return $"{v1} / {v2} = {result}";
        }

    }
}
