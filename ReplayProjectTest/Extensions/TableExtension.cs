using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayProjectTest.Extensions
{
    public static class TableExtension
    {
        public static List<RowData> CreateTableRowWithWebElements(IWebElement table, int rowLimit)
        {
            rowLimit++;
            List<RowData> tableData = new List<RowData>();
            
            //Get columns

            var columns = table.FindElements(By.TagName("th"));

            //Get all  rows
            var rows = table.FindElements(By.TagName("tr"));

            int rowIndex = 0;
            foreach (var row in rows)
            {
                int colIndex = 0;

                if (rowIndex != 0)
                {
                    var colDatas = row.FindElements(By.TagName("td"));
                    RowData rowData = new RowData
                    {
                        RowIndex = rowIndex,
                        tdDataColection = new List<TdData>()

                    };
                    if (colDatas.Count != 0)
                    {
                        foreach (var colValue in colDatas)
                        {
                            rowData.tdDataColection.Add(new TdData
                            {
                                ColumnIndex = colIndex,
                                Element = GetWebElementFromTable(colValue, colIndex)
                            });

                            colIndex++;
                        }

                        tableData.Add(rowData);
                    }
                }

                rowIndex++;
                if(rowIndex== rowLimit)
                    break;
            }

            return tableData;
        }

        private static IWebElement GetWebElementFromTable(IWebElement element, int colIndex=0)
        {
            //supports only html tag a, button, input
            //In case of mor flexibility needs to be extended

            IWebElement elementToReturn = null;
            if (colIndex==0) // looking for  input in the first  colomn 
                elementToReturn = element.FindElement(By.TagName("input"));
            if (colIndex == 1) // looking for  a in the second  colomn
                elementToReturn = element.FindElement(By.TagName("a"));
            if (colIndex == 2) // looking for  a in the third  colomn
                elementToReturn = element.FindElement(By.TagName("button"));

            return elementToReturn;

        }
    }
    public class RowData
    {
        public  int RowIndex { get; set; }
        public List<TdData>? tdDataColection { get; set; }
    }

    public class TdData
    {
        public int ColumnIndex { get; set; }
        public IWebElement Element { get; set; }

    }

}
