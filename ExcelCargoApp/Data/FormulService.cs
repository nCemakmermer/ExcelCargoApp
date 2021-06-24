using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelCargoApp.Data
{
    public class FormulService
    {
        public List<Formul> GetFormuls()
        {

            List<Formul> formuls = new List<Formul>();
            string filePath = @"C:\Users\Nuh Cem Akmermer\Desktop\TEST-01\FORMUL-GIRDI.xlsx";
            FileInfo fileInfo = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.FirstOrDefault();
                int Colums = excelWorksheet.Dimension.End.Column;
                int Rows = excelWorksheet.Dimension.End.Row;
                for (int row = 2; row <= Rows; row++)
                {
                    Formul formul = new Formul();
                    for (int colum = 1; colum <= Colums; colum++)
                    {
                        if (colum == 1) formul.DESI = Convert.ToString(excelWorksheet.Cells[row, colum].Value.ToString());
                        if (colum == 2) formul.KISA = Convert.ToString(excelWorksheet.Cells[row, colum].Value.ToString());
                        if (colum == 3) formul.UZAK = Convert.ToString(excelWorksheet.Cells[row, colum].Value.ToString());

                    }

                    formuls.Add(formul);
                }
                return formuls;
            }
        }
    }
}