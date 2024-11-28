namespace LabExe2;

class TUIManager
{
    public void DisplayCategory(string[] options, int selectedIndex)
    {
        Console.Clear();
        Console.WriteLine("\nUse Up/Down arrows to navigate and Enter to select:\n");

        for (int i = 0; i < options.Length; i++)
        {
            if (i == selectedIndex)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ResetColor();
            }

            Console.WriteLine($"  {options[i]} ");
        }

        Console.ResetColor();
    }

    public void DisplayForm(List<string> fields, Dictionary<string, string> inputData, int selectedIndex)
    {
        Console.Clear();
        Console.WriteLine("\nAdd Product (Use Up/Down arrows to navigate, Enter to edit field):\n");

        for (int i = 0; i < fields.Count; i++)
        {
            if (i == selectedIndex)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ResetColor();
            }

            Console.Write($"  {fields[i]}: ");
            Console.WriteLine(inputData.ContainsKey(fields[i]) ? inputData[fields[i]] : "");
        }

        Console.ResetColor();
    }
}