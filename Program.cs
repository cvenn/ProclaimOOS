using System.Reflection;

internal partial class Program {
    private static void Main(string[] args) {
        bool ret = true;

        if (args.Length != 1) {
            Console.WriteLine("Usage: ProclaimOOS <fileName.prs>");
            ret = false;
        
        } else {
            string filename = args[0];
#if DEBUG
            string dataPath = Path.GetFullPath("../../../output");
#else
            string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string dataPath = $"{localAppDataPath}/cvImaging/ProclaimOOS";
#endif
            ret = new ProclaimOOS().Process(filename, dataPath);
        }
        
        if (!ret) {
            Console.WriteLine("Press any key to close this window . . .");
            Console.ReadKey();
        }

    }
}
