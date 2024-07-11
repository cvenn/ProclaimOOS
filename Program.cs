using System.Reflection;

internal partial class Program {
    private static void Main(string[] args) {
        bool ret = true;

        if (args.Length != 1) {
            Console.WriteLine("Usage: ProclaimOOS <fileName.prs>");
            ret = false;
        
        } else {
            string filename = args[0];
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            ret = new ProclaimOOS().Process(filename, @$"{dataPath}/cvImaging/ProclaimOOS");
        }
        
        if (!ret) {
            Console.WriteLine("Press any key to close this window . . .");
            Console.ReadKey();
        }

    }
}
