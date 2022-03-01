using System.Runtime;
using System.Runtime.InteropServices;

namespace PolishNotation.API.Extensions;

public static class WebApplicationExtensions
{
    public static void Execute(this WebApplication webApplication)
    {
        Console.WriteLine("============================== Polish Notation API ===============================");
        Console.WriteLine($"Runtime    : {RuntimeInformation.FrameworkDescription} {RuntimeInformation.ProcessArchitecture}");
        Console.WriteLine($"Platform   : {RuntimeInformation.OSDescription} {RuntimeInformation.OSArchitecture}");
        Console.WriteLine($"Server GC  : {GCSettings.IsServerGC}");
        Console.WriteLine("==================================================================================");
        webApplication.Run();
    }
}
