namespace ui.Utilities;

/// <summary>
/// A static class responsible to user I/O operations through the Console.
/// </summary>
internal static class Display
{
    /// <summary>
    /// Prints each option from the provided collection to the console as a menu.
    /// </summary>
    /// <param name="options">The collection of available options.</param>
    public static void PrintMenu(IEnumerable<(int index, string name)> options)
    {
        foreach (var (index, name) in options)
            Console.WriteLine($"[{index}] {name}");
    }

    /// <summary>
    /// Read an input from the user, responding to the specified prompt and convert the result to <typeparamref name="T"/> type.
    /// </summary>
    /// <param name="prompt">The prompt user has to respond to.</param>
    /// <typeparam name="T">The type of input supported for this prompt. The type 'T' must be a not null primitive type</typeparam>
    /// <returns>The valid <typeparamref name="T"/> value the user entered.</returns>
    public static T Read<T>(string? prompt = "")
        where T : struct, IConvertible
    {
        return Read<T>(obj => (true, string.Empty), prompt);
    }

    /// <summary>
    /// Read an input from the user, responding to the specified prompt and convert the result to <typeparamref name="T"/> type
    /// </summary>
    /// <param name="validateInput">A delegate specifying specific rules on how to validate the prompt after the conversion</param>
    /// <param name="prompt">The prompt user has to respond to</param>
    /// <typeparam name="T">The type of input supported for this prompt. The type 'T' must be a not null primitive type</typeparam>
    /// <returns>The valid <typeparamref name="T"/> value the user entered</returns>
    public static T Read<T>(Func<T, (bool,string)> validateInput, string? prompt = "")
        where T : struct, IConvertible
    {
        if(!string.IsNullOrEmpty(prompt))
            Console.Write(prompt);

        if (!typeof(T).IsPrimitive && typeof(T) != typeof(decimal))
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

    /// <summary>
    /// Prints an error like message to the console without a line break at the end
    /// </summary>
    /// <param name="message"></param>
    public static void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
