using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelCargoApp.Data
{
    public class RaporService
    {
        public List<Rapor> GetRapors()
        {

            List<Rapor> rapors = new List<Rapor>();
            string filePath = @"C:\Users\Nuh Cem Akmermer\Desktop\TEST-01\RAPOR.xlsx";
            FileInfo fileInfo = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage =new ExcelPackage(fileInfo)) {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.FirstOrDefault();
                int Colums = excelWorksheet.Dimension.End.Column;
                int Rows = excelWorksheet.Dimension.End.Row;
                for (int row = 2; row <= Rows; row++)
                {
                    Rapor rapor = new Rapor();
                    for (int colum = 1; colum <= Colums; colum++)
                    {
                        if (colum == 1) rapor.SIRA_NO =Convert.ToInt32( excelWorksheet.Cells[row, colum].Value.ToString());
                        if (colum == 2) rapor.ADET = Convert.ToInt32(excelWorksheet.Cells[row, colum].Value.ToString());
                        if (colum == 3) rapor.KG_DESİ = Convert.ToInt32(excelWorksheet.Cells[row, colum].Value.ToString());
                        if (colum == 4) rapor.MESAFE = excelWorksheet.Cells[row, colum].Value.ToString();
                        if (colum == 5) rapor.UCRET = Convert.ToInt32(excelWorksheet.Cells[row, colum].Value.ToString());
                    }
                
                    rapors.Add(rapor);
                }
                return rapors;
            }
        }
    }
}
