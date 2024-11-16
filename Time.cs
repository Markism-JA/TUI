namespace LabExe2
{
    class Time
    {
        public string Date()
        {
            // Initial values for Day, Month, Year
            int day = 1;
            int month = 1;
            int year = 2024;

            // Array for month names
            string[] monthNames = new string[] 
            {
                "January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"
            };

            // Index to track which part (Day, Month, or Year) is selected
            int selectedIndex = 0;

            // Variable to store the final date input
            string finalDate = string.Empty;
            // Set up the console for navigation
            Console.CursorVisible = false;
            ConsoleKey key;
            do
            {
                // Clear the console and redraw the current state
                Console.Clear();
                DisplayDate(day, month, year, monthNames, selectedIndex);

                // Read the key pressed
                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        // Move left between Day, Month, Year
                        selectedIndex = (selectedIndex == 0) ? 2 : selectedIndex - 1;
                        break;

                    case ConsoleKey.RightArrow:
                        // Move right between Day, Month, Year
                        selectedIndex = (selectedIndex == 2) ? 0 : selectedIndex + 1;
                        break;

                    case ConsoleKey.UpArrow:
                        // Increase the value of the selected part (Day, Month, or Year)
                        if (selectedIndex == 0) // Day
                        {
                            day = (day < 31) ? day + 1 : 31; // Ensure day doesn't go above 31
                        }
                        else if (selectedIndex == 1) // Month
                        {
                            month = (month < 12) ? month + 1 : 12; // Ensure month doesn't go above 12
                        }
                        else if (selectedIndex == 2) // Year
                        {
                            year++; // Increase year by 1
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        // Decrease the value of the selected part (Day, Month, or Year)
                        if (selectedIndex == 0) // Day
                        {
                            day = (day > 1) ? day - 1 : 1; // Ensure day doesn't go below 1
                        }
                        else if (selectedIndex == 1) // Month
                        {
                            month = (month > 1) ? month - 1 : 1; // Ensure month doesn't go below 1
                        }
                        else if (selectedIndex == 2) // Year
                        {
                            year--; // Decrease year by 1
                        }
                        break;

                    case ConsoleKey.Enter:
                        // Finalize the input and store the final date
                        finalDate = $"{day.ToString("D2")}/{month.ToString("D2")}/{year}";
                        break;
                }

            } while (key != ConsoleKey.Escape && string.IsNullOrEmpty(finalDate)); // Exit on Escape or if the date is finalized

            return finalDate;
        }

        // Function to display the date and highlight the selected field (Day, Month, Year)
        static void DisplayDate(int day, int month, int year, string[] monthNames, int selectedIndex)
        {
            Console.WriteLine("\n  Use Left/Right arrow keys to navigate (Day/Month/Year).");
            Console.WriteLine("  Use Up/Down arrow keys to change the value.");
            Console.WriteLine("  Press Enter to finalize the date.");

            string dayStr = (day < 10) ? "0" + day.ToString() : day.ToString();
            string monthStr = monthNames[month - 1];
            string yearStr = year.ToString();

            // Display the date with highlighting for the selected part
            Console.Write("  Day: ");
            if (selectedIndex == 0)
                Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write(dayStr);
            if (selectedIndex == 0)
                Console.ResetColor();
            Console.Write("  ");

            Console.Write("Month: ");
            if (selectedIndex == 1)
                Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write(monthStr);
            if (selectedIndex == 1)
                Console.ResetColor();
            Console.Write("  ");

            Console.Write("Year: ");
            if (selectedIndex == 2)
                Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write(yearStr);
            if (selectedIndex == 2)
                Console.ResetColor();
            
            Console.WriteLine();
        }
    }
}
