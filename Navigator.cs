namespace LabExe2;

class Navigator
{
    public int NavigateMenu(string[] options, Action<int> displayCallback)
    {
        int selectedIndex = 0;
        ConsoleKey key;
        do
        {
            displayCallback(selectedIndex);
            key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;
                    break;
                case ConsoleKey.Enter:
                    return selectedIndex;
            }
        } while (key != ConsoleKey.Escape);

        return -1; // Exit condition
    }

    public int NavigateForm(List<string> fields, Dictionary<string, string> inputData, Action<int> displayCallback)
    {
        int selectedIndex = 0;
        ConsoleKey key;
        do
        {
            displayCallback(selectedIndex);
            key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex == 0) ? fields.Count - 1 : selectedIndex - 1;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex == fields.Count - 1) ? 0 : selectedIndex + 1;
                    break;
                case ConsoleKey.Enter:
                    return selectedIndex;
            }
        } while (key != ConsoleKey.Escape);

        return -1; // Exit condition
    }
    
}