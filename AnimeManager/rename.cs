using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnimeManager
{
    class rename
    {

        public static void renameAll(string type)
        {
            string folder = "C:\\Users\\asdadasfff\\Downloads";
            DirectoryInfo dInfo = new DirectoryInfo(@folder);
            FileInfo[] files = dInfo.GetFiles();
            string[] temp = null;
            string newName = null;
            foreach (FileInfo f in files)
            {
                if (f.ToString().EndsWith(".mkv"))
                {
                    temp = tokenizer(f.ToString());
                    temp[0] = DataModel.newFileName(temp[0]);
                    newName = folder + "\\" + temp[0].Trim() + " - " + temp[1].Trim() + ".mkv";
                    Console.WriteLine("renaming...");
                    try
                    {
                        File.Move(f.FullName, newName);
                    }
                    catch (Exception err)
                    {

                    }
                }
            }
        }
        private static string[] tokenizer(string filename)
        {
            string[] temp = filename.Split(']', '[', '_', '(', '-');
            string[] name = new string[3];
            if (temp[1].ToLower() == "animeout")
            {
                //Console.WriteLine(temp);
                //Console.WriteLine(temp[2] + " episode " + temp[3]);
                name[0] = temp[2];
                name[1] = temp[3];
                //name[2] = temp[temp.Length-1];
            }
            else
            {
                //Console.WriteLine(temp[0] + " episode " + temp[1]);
                name[0] = temp[0];
                name[1] = temp[1];
                //name[2] = temp[temp.Length-1].Substring(temp[temp.Length - 1].LastIndexOf('.'));
            }
            return name;
        }
    }
}
