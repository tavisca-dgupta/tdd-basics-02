﻿using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private string operand = "";
        private double result=0.0;
        private char operation= '+';
        private string error= "-E-";
        
        public string SendKeyPress(char key)
        {
            if (char.IsDigit(key))
            {
                if (PreCondition(key))
                {
                    operand = operand + key;
                }
                return operand;
            }
            else
            {
                return DoOperation(key);

            }
        }

        public string DoOperation(char key)
        {

            switch (char.ToLower(key))
            {
                case 's': return ChangeSign();
                case 'c': return Clear();
                case '+':
                    operation = '+';
                    return GetAddition();
                case '-':
                    operation = '-';
                    return GetSubtraction();
                case '/':
                    operation = '/';
                    return GetDivision();
                case '*':
                    operation = '*';
                    return GetMultiplication();
                case '=': return Equals(operation);
                case '.': return AddDecimal();
                default: return error;

            }
        }

        public string GetAddition()
        {
            double num = 0.0;
            if (double.TryParse(operand, out num))
            {
                if (result == 0.0)
                    result = num;
                else
                    result = result + num;
            }
            operand = "";
            return result.ToString();
        }
        public string GetSubtraction()
        {

            double num = 0.0;
            if (double.TryParse(operand, out num))
            {
                if (result == 0.0)
                    result = num;
                else
                    result = result - num;
            }
            operand = "";
            return result.ToString();
        }
        public string GetDivision()
        {
            double num = 0.0;

            if (double.TryParse(operand, out num))
            {
                if (num == 0)
                {
                    return error;
                }
                else if (result == 0.0)
                    result = num;
                else
                    result = result / num;
            }
            operand = "";
            return result.ToString();

        }
        public string ChangeSign()
        {
            double num = 0.0;
            if (double.TryParse(operand, out num))
            {
                num = num * (-1);
            }
            operand = num.ToString();
            return num.ToString();
        }

        public string GetMultiplication()
        {
            double num = 0.0;
            if (double.TryParse(operand, out num))
            {
                if (result == 0.0)
                    result = num;
                else
                    result = result * num;
            }
            operand = "";
            return result.ToString();
        }

        public string AddDecimal()
        {
            if (operand.Contains("."))
            {
                return operand;
            }
            else
            {
                operand = operand + ".";
                return operand;
            }
        }
        public string Clear()
        {
            return "0";
        }
        public bool PreCondition(char key)
        {
            if (operand.Contains(".") && key.Equals('0'))
            {
                return true;
            }
            else if (operand.Equals("0") && key.Equals('0'))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string Equals(char operation)
        {
            if (operand == "")
                return error;
            else
                return DoOperation(operation);
        }

    }
}

