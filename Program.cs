using System.Reflection;

internal partial class Program {
    private static void Main(string[] args) {
        bool ret = true;
        if (args.Length == 0) {
            Console.WriteLine("Usage: ProclaimOOS <fileName.prs>");
            ret = false;
        } else {
            string filename = args[0];
            string exePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            //Console.WriteLine($"EXE path: {exePath}");
            ret = new ProclaimOOS().Process(filename, @$"{exePath}\..\output");
        }
        if (!ret) {
            Console.WriteLine("Press any key to close this window . . .");
            Console.ReadKey();
        }
    }
}
