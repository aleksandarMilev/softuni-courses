namespace DirectoryTraversal
{
    using System;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, List<FileInfo>> filesMap = new();
            string[] filesArr = Directory.GetFiles(inputFolderPath);

            foreach (string file in filesArr)
            {
                FileInfo fileInfo = new(file);

                if (!filesMap.ContainsKey(fileInfo.Extension))
                {
                    filesMap.Add(fileInfo.Extension, new List<FileInfo>());
                }

                filesMap[fileInfo.Extension].Add(fileInfo);
            }

            StringBuilder sb = new();
            foreach (var extensionFiles in filesMap.OrderByDescending(ef => ef.Value.Count))
            {
                sb.AppendLine(extensionFiles.Key);

                foreach (var file in extensionFiles.Value.OrderBy(f => f.Length))
                {
                    sb.AppendLine($"--{file.Name} - {(double)file.Length / 1024:f3}kb");
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            File.WriteAllText(filePath, textContent);
        }
    }
}
