using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dzzz
{
    public class FileId
    {
        private string name;

        public string Name { 
            get { return name; } 
            set { name = value;} }


        private string path;
        public string Path
        {
            get { return path; }
        }
        public FileId(string _name)
        {
            name = _name;
            path = Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments);
           
        }

        public void WriteData(string text, bool append = true)
        {
            StreamWriter streamWriter =
               new StreamWriter(path + "\\" + Name, append);
            //запись файла в мои документы и дача имени
            streamWriter.WriteLine(
                $"{DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss.fff")}" +
                $"{text}\n");
            streamWriter.Close();
        }

        public static string ReadData(string name)
        {
            StreamReader reader = new StreamReader(name);
            string result = reader.ReadToEnd();
            //reader.ReadLine();
            return result;
        }

    }
    public class MultipleTable
    {

        private string table;
        public string Table { get { return table; } }   
        public MultipleTable(int start, int finish)
        {
            string tmpTable = string.Empty;
            for (int i = start; i <= finish; i++)
            {
                for (int j = start; j <= finish; j++)
                {
                    tmpTable += $"\t{i * j}";
                }
                tmpTable += $"\n";
            }
            table = tmpTable;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            MultipleTable myTable = new MultipleTable(1, 9);
            Console.WriteLine(myTable.Table);

            //CREATE FILE WITH INFO
            FileId fileId = new FileId("test.txt");
            fileId.WriteData(myTable.Table);

            //чтение из файла
            Console.WriteLine(FileId.ReadData(
                fileId.Path + "\\" + fileId.Name)); ;

            Console.ReadLine();
        }
        
    }
}
