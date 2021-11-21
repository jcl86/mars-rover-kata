using System;

namespace MarsRover.Core
{
    public static class Ensure
    {
        public static void IsNotNullOrEmpty(this string text, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException($"{parameterName} can not be null or empty");
            }
        }
    }
}
