namespace Task1;

class BreakMeCompletely
{
    static void Main(string[] args)
    {
        try
        {
            FailProcess();
        }
        catch
        {
        }

        Console.WriteLine("Failed to fail process");
        Console.ReadKey();
    }
    static void FailProcess()
    {
        // Process.GetCurrentProcess().Kill();
        
        // Environment.Exit(0);
        
        // Environment.FailFast("");
        
        FailProcess();
    }
}
