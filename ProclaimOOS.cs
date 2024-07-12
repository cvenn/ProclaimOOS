using Newtonsoft.Json;
using ProclaimOOS;
using RazorEngine;
using RazorEngine.Templating;
using System.Diagnostics;
using System.IO.Compression;

internal partial class Program {
    internal class ProclaimOOS {

        internal bool Process(string filename, string dataFolder) {

            // Open Proclaim Backup (.prs) file - it is a disguised ZIP archive
            ZipArchive zip;
            try {
                zip = ZipFile.Open(filename, ZipArchiveMode.Read);
            }
            catch {
                Console.WriteLine($"Failed to open file: {filename}");
                return false;
            }

            // Locate Presentation Descriptor entry in archive
            ZipArchiveEntry entry;
            try {
                entry = zip.Entries.First(e => e.Name == "BackupPresentation.json");
            }
            catch {
                Console.WriteLine($"The Proclaim backup archive did not contain the expected descriptor file");
                return false;
            } 

            // Parse JSON content and create model objects
            try {
                JsonSerializer serializer = new();

                using StreamReader sr = new(entry.Open());
                using JsonReader jr = new JsonTextReader(sr);
                Presentation? pres = serializer.Deserialize<Presentation>(jr);
                if (null == pres) {
                    throw new Exception("Could not interpret Presentation Backup file data");
                }

                // Transform model objects and render as HTML (using Razor template)
                string template = File.ReadAllText(@$"{dataFolder}/css/Presentation.cshtml");
                string htmlFile = @$"{dataFolder}/OrderOfService.html";
                RenderHtml(pres, template, htmlFile);

                // Open final HTML file in default application (usually a web browser)
                OpenHtmlFileInBrowser(htmlFile);
            }
            catch (Exception ex) {
                Console.WriteLine($"Failed to process Proclaim backup file: {ex.Message}");
                return false;
            }

            return true;
        }

        private void RenderHtml(Presentation obj, string template, string fileName) {
            const string key = "PresentationKey";
            string html = Engine.Razor.RunCompile(template, key, null, obj);
            File.WriteAllText(fileName, html);
        }

        private void OpenHtmlFileInBrowser(string htmlFile) {
            Process p = new() {
                StartInfo = new ProcessStartInfo(htmlFile) {
                    UseShellExecute = true
                }
            };
            p.Start();
        }
    }
}
