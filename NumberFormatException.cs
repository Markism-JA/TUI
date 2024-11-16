namespace LabExe2;

class NumberFormatException : Exception
{
    public override string Message { get; } = "Invalid quantity";
}