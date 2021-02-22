namespace RobotField.Extensions
{
    public static class StringExtensions
    {
        public static string[] GetInputParts(this string rawInput)
        {
            return rawInput?.Split(' ');
        }
        public static short GetFromParts(this string rawInput, int index)
        {
            var parts = GetInputParts(rawInput);
            if (parts == null || parts.Length <= index)
            {
                return default(short);
            }
            var firstPart = parts[index] ?? "0";
            var canParse = short.TryParse(firstPart, out var parsedValue);
            if (canParse)
            {
                return parsedValue < 0 ? default(short) : parsedValue;
            }
            return default(short);
        }
    }
}
