namespace LabExe2;

class YesNo
{
    public bool Submit(string prompt)
    {
        bool isSelected = false;
        bool yesNo = false;
        int selectedIndex = 0; // 0 for YES, 1 for NO
        string[] options = { "YES", "NO" };

        // Display the initial options
        DisplayCenteredText($"{prompt} ?");
        Console.WriteLine();
        DisplayCenteredText("Use Left and Right arrow keys to navigate and press Enter to select.");
        DisplayOptions(options, selectedIndex, prompt);

        // Loop to capture user input
        while (!isSelected)
        {
            var key = Console.ReadKey(intercept: true).Key; // Read the key without showing it on the console

            // Left arrow key (Navigate to YES)
            if (key == ConsoleKey.LeftArrow)
            {
                selectedIndex = 0; // Move to YES
                DisplayOptions(options, selectedIndex, prompt);
            }
            // Right arrow key (Navigate to NO)
            else if (key == ConsoleKey.RightArrow)
            {
                selectedIndex = 1; // Move to NO
                DisplayOptions(options, selectedIndex, prompt);
            }
            // Enter key (Select the option)
            else if (key == ConsoleKey.Enter)
            {
                isSelected = true; // Selection is made
                Console.Clear();

                if (options[selectedIndex] == "YES")
                {
                    yesNo = true;
                } else if (options[selectedIndex] == "NO")
                {
                    yesNo = false;
                }
                // DisplayCenteredText($"You selected: {options[selectedIndex]}");
            }
        }

        return yesNo;
    }

    // Method to display the options with selection
    private void DisplayOptions(string[] options, int selectedIndex, string prompt)
    {
        Console.Clear(); // Clear the screen to update the display
        Console.WriteLine();
        DisplayCenteredText(prompt);
        Console.WriteLine();
        DisplayCenteredText("Use Left and Right arrow keys to navigate and press Enter to select.");
        Console.WriteLine();

        // Calculate centered positions for options
        string optionsText = "";
        for (int i = 0; i < options.Length; i++)
        {
            if (i == selectedIndex)
            {
                optionsText += $"[{options[i]}] ";
                Console.ResetColor();
            }
            else
            {
                optionsText += $"{options[i]} ";
            }
        }
        DisplayCenteredText(optionsText.Trim());
    }

    // Method to center text in the console
    private void DisplayCenteredText(string text)
    {
        int windowWidth = Console.WindowWidth;
        int centeredPosition = (windowWidth - text.Length) / 2;
        Console.SetCursorPosition(Math.Max(centeredPosition, 0), Console.CursorTop);
        Console.WriteLine(text);
    }
}