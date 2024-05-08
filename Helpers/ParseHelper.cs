using TaskManagement.Exceptions;
using System;
using System.Globalization;
using TaskManagement.Models.Enums;

namespace TaskManagement.Helpers
{
    public static class ParseHelper
    {
        public static int ParseIntParameter(string value, string parameterName)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be an integer number.");
        }

        public static decimal ParseDecimalParameter(string value, string parameterName)
        {
            if (decimal.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be a real number.");
        }

        public static bool ParseBoolParameter(string value, string parameterName)
        {
            if (bool.TryParse(value, out bool result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be either true or false.");
        }

        public static Severity ParseSeverityParameter(string enumString)
        {
            Severity parsedEnum;
            if (Enum.TryParse(enumString,true, out parsedEnum))
            {
                return parsedEnum;
            } 
            throw new InvalidUserInputException("Invalid Severity input!");
        }
        public static Size ParseSizeParameter(string enumString)
        {
            Size parsedEnum;
            if (Enum.TryParse(enumString, true, out parsedEnum))
            {
                return parsedEnum;
            }
            throw new InvalidUserInputException("Invalid Size input!");
        }
        public static Status ParseStatusParameter(string enumString)
        {
            Status parsedEnum;
            if (Enum.TryParse(enumString, true, out parsedEnum))
            {
                return parsedEnum;
            }
            throw new InvalidUserInputException("Invalid Status input!");
        }
        public static Priority ParsePriorityParameter(string enumString)
        {
            Priority parsedEnum;
            if (Enum.TryParse(enumString, true, out parsedEnum))
            {
                return parsedEnum;
            }
            throw new InvalidUserInputException("Invalid Priority input!");
        }
    }
}
