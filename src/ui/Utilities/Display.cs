namespace ui.Utilities;

internal static class Display
{
    public static void PrintMenu(IEnumerable<(int index, string name)> options)
    {
        foreach (var (index, name) in options)
            Console.WriteLine($"[{index}] {name}");
    }

    public static T Read<T>(string? prompt = "")
        where T : struct, IConvertible
    {
        return Read<T>(obj => (true, string.Empty), prompt);
    }

    public static T Read<T>(Func<T, (bool,string)> validateInput, string? prompt = "")
        where T : struct, IConvertible
    {
        if(!string.IsNullOrEmpty(prompt))
            Console.Write(prompt);

        if (!typeof(T).IsPrimitive)
            throw new ArgumentException("T must be a primitive type");
        bool firstLoop = true;
        bool valid = false;
        string message = string.Empty;
        T result = default;
        do
        {
            try
            {
                if (!firstLoop)
                {
                    WriteError(message);
                }
                firstLoop = false;
                string input = Console.ReadLine() ?? string.Empty;
                result = (T)Convert.ChangeType(input, typeof(T));
                (valid, message) = validateInput(result);
            }
            catch (Exception)
            {
                message = "Invalid conversion. The input you entered is not in a valid format. Try again: ";
            }

        } while (!valid);
        return result;
    }

    public static void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
