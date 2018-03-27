using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CleanUpDataUtil
{
    public class CleanDuplicateField
    {
        static void Main(string[] args)
        {
            CleanDuplicateField removeDuplicate = new CleanDuplicateField();

            try
           {
                removeDuplicate.processFile();
                Console.WriteLine("File has been clean.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

        }

        public void processFile()
        {
            String ProcessFilePath = @"C:\test.csv";

            StreamReader file = new StreamReader(ProcessFilePath);
            String line = "";
            String previous = "";
            String current = "";
            while ((line = file.ReadLine()) != null)
            {
                try
                {

                    string[] arr = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    current = arr[1]; // index based on csv header --- to be added to configuration

                    if (!previous.Equals(current))
                    {
                        File.AppendAllText(@"C:\clean_test.csv", line + Environment.NewLine);
                    }

                    previous = current;  //future work consider edit distance
                }
                catch (Exception ee)
                {



                }
            }
            file.Close();

        }
    }
}
