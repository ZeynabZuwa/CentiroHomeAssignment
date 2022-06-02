using CentiroAssignment.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CentiroAssignment.Services.Features.CSV_Files
{
    public class CSVFileService : ICSVFileService
    {
        public DataTable CSVConvertToDataTable(string strFilePath)
        {
            DataTable dataTable = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split('|');
                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split('|');
                    DataRow dr = dataTable.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dataTable.Rows.Add(dr);
                }

            }

            return dataTable;
        }

        public async Task<List<Order>> MakeDataTableToOrderRequestList(DataTable dataTable)
        {
            var listOfOrders  = await Task.Run(() =>
                   {
                return dataTable.AsEnumerable().Select(row => new Order
            {
                OrderNumber = Convert.ToInt32(row["OrderNumber"]),
                OrderLineNumber = Convert.ToInt32(row["OrderLineNumber"]),
                ProductNumber = (row["ProductNumber"]).ToString(),
                Quantity = Convert.ToInt32(row["Quantity"]),
                Name = (row["Name"]).ToString(),
                Description = (row["Description"]).ToString(),
                Price = XmlConvert.ToDouble(row["Price"].ToString()),
                ProductGroup = (row["ProductGroup"]).ToString(),
                OrderDate = Convert.ToDateTime(row["OrderDate"]),
                CustomerName = (row["CustomerName"]).ToString(),
                CustomerNumber = Convert.ToInt32(row["CustomerNumber"]),

            }).ToList();
           });

            return listOfOrders;
        }
    }
}


