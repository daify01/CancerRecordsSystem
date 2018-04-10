using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCancerProject.Core;

namespace TheCancerProject.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Patient thePat = new Patient();
                populatePatientObjectValues(thePat, thePat.TheBiodata);
                string key = "aa";
                string val = "Sope";
                string s = @"""";
                Dictionary<string, string> theDict = new Dictionary<string, string>() { {key, val} };

                string keyretrieved = theDict.Keys.First();
                Console.WriteLine(s);
                Console.WriteLine("Starting...");
                ReadExcelAndWriteText.getExcelFile();
                Console.WriteLine("Success");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public static void populatePatientObjectValues(Patient thePatient, object currentObjectToUpdate)
        {
            foreach (var entity in thePatient.GetType().GetProperties())
            {
                //if (entity.)
                //PropertyType.UnderlyingSystemType.Name.Equals("DateTime");
                //PropertyType.UnderlyingSystemType.Name.Equals("Int64") && !entity.Name.Equals("Id");
            }
        }


    }
}
