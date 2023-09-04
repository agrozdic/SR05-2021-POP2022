using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.utilities
{
    class FileHandler
    {

        public static string[] ReadFile(string filePath)
        {
            try
            {
                string[] readedFile = File.ReadAllLines(filePath);
                return readedFile;
            }
            catch
            {
                return Array.Empty<String>();
            }
        }


        public static void UpdateFile(string filePath, string content)
        {
            try
            {
                string[] exContent = ReadFile(filePath);
                string id = content.Split('|')[0];
                for(int i=0;i<exContent.Length;i++)
                {
                    string splittedIndex = exContent[i].Split('|')[0];
                    if (splittedIndex == id)
                    {
                        exContent[i] = content;
                    }
                }
                File.WriteAllLines(filePath, exContent);
            }
            catch (IOException err)
            {
                throw new FileLoadException(err.Message);
            }
        }

        public static void RemoveFileContent(string path)
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write("");
                }
            }
            catch (Exception err)
            {
                throw new IOException(err.Message);
            }
        }

        public static void WriteFile(string filePath, string content)
        {
            try
            {
                string[] exContent = ReadFile(filePath);
                exContent = exContent.Append(content).ToArray();
                File.WriteAllLines(filePath, exContent);
            }
            catch (IOException)
            {
                throw new IOException("Exception error at WriteFile, unable to handle it!");
            }
        }
    }
}
