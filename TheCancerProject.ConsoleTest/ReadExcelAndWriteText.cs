using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;       //microsoft Excel 14 object in references-> COM tab

namespace TheCancerProject.ConsoleTest
{
    public class ReadExcelAndWriteText
    {
        private static List<string> elementsToWrite = new List<string>();
        public static void getExcelFile()
        {
            try
            {
                //Create COM Objects. Create a COM object for everything that is referenced
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\App-Sope\Documents\Personal\Breast Cancer Project\BreastCancerReportableList.xlsx");
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                string path = System.Configuration.ConfigurationSettings.AppSettings["writepath"];
                StreamWriter s = new StreamWriter(path);


                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                //iterate over the rows and columns and print to the console as it appears in the file
                //excel is not zero based!!
                for (int i = 1; i <= rowCount; i++)
                {
                    string stringToSave = string.Empty;

                    for (int j = 1; j <= colCount; j++)
                    {
                        if (j == 1)
                        {
                            if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                                //stringToSave += "ICD 10 code:" + " " + xlRange.Cells[i, j].Value2.ToString();
                                stringToSave = "{" + @"""" + xlRange.Cells[i, j].Value2.ToString() + @"""" + ",";
                        }

                        if (j == 2)
                        {
                            if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                                //stringToSave = xlRange.Cells[i, j].Value2.ToString() + "." + " ";
                                stringToSave += @"""" + xlRange.Cells[i, j].Value2.ToString() + @"""" + "}" + ",";
                        }                            
                        //Console.Write("\r\n");                       

                        //write the value to the console
                        //if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        //    Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");

                    }
                    s.WriteLine(stringToSave);
                }

                s.Close();

                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //rule of thumb for releasing com objects:
                //  never use two dots, all COM objects must be referenced and released individually
                //  ex: [somthing].[something].[something] is bad

                //release com objects to fully kill excel process from running in the background
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {
                throw;
            }

            
        }
    }
}
