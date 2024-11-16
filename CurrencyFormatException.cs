namespace LabExe2;

class CurrencyFormatException : Exception
{
    public override string Message { get; } = "Invalid currency";
}