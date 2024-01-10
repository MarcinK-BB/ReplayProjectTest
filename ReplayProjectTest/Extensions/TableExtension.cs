using ReplayProjectTest.Drivers;
using ReplayProjectTest.Setup;

namespace ReplayProjectTest.Extensions
{
    public static class TableExtension
    {
        //method creating list of rows with web elements
        //int rowLimit - indicate numbers of row
        //params string[] colWebElement - indicates which html tag should be taken in particular column
        public static List<RowData> CreateTableRowWithWebElements(IWebElement table, int rowLimit, params string[] colWebElement)
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
                                Element = GetWebElementFromTable(colValue, colWebElement[colIndex])
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

        private static IWebElement GetWebElementFromTable(IWebElement element, string webElement)
        {
            return webElement switch
            {
                "input" => element.FindElement(By.TagName("input")),
                "a" => element.FindElement(By.TagName("a")),
                "button" => element.FindElement(By.TagName("button")),
                _ => null
            };

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
        public IWebElement? Element { get; set; }

    }

}
