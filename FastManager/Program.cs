using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FastManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          Application.Run(new Form1());

            //string mine = "mynameisgersy";
            //if(mine.EndsWith("rsy"))
            //    MessageBox.Show("");
            ////string []dat = System.IO.File.ReadAllLines(@"E:\a.txt");
            ////string result="";
            //for(int i=0;i<dat.Length;i++)
            //    result += ("\"" +dat[i].ToLower() +"\",");
            //System.IO.File.WriteAllText(@"E:\a.txt", result);

           
            

        }
        public static bool Ends_with(this string fp, string deli,bool ignorecaseSensitive=true)
        {   try
            {
                string org = fp;
                string delimeter = deli;

                if(ignorecaseSensitive)
                {
                    org = fp.ToLower();
                    delimeter = deli.ToLower();
                }
                for (int i = 0; i < delimeter.Length; i++)
                    if (delimeter[i] != org[org.Length - delimeter.Length + i])
                        return false;
                return true;
            }
            catch { return false; }
        }
        public static bool Ends_with(this string fp, List<string>DeliList, bool ignorecaseSensitive = true)
        {

            foreach (string d in DeliList)
                if (fp.EndsWith(d))
                    return true;

            return false;
        }

    }
}
