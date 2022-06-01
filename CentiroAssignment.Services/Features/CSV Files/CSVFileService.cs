using CentiroAssignment.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var test = dataTable;

            return dataTable;
        }

        public async Task<List<Order>> MakeDataTableToOrderRequestList(DataTable dataTable)
        {
            var listOfOrders = dataTable.AsEnumerable().Select(row => new Order
            {
                    OrderNumber = Convert.ToInt32(row["OrderNumber"]),
                    OrderLineNumber = Convert.ToInt32(row["OrderLineNumber"]),
                    ProductNumber = (row["ProductNumber"]).ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    Name = (row["Name"]).ToString(),
                    Description = (row["Description"]).ToString(),
                    Price = Convert.ToDouble(row["Price"]),
                    ProductGroup = (row["ProductGroup"]).ToString(),
                    OrderDate = Convert.ToDateTime(row["OrderDate"]),
                    CustomerName = (row["CustomerName"]).ToString(),
                    CustomerNumber = Convert.ToInt32(row["CustomerNumber"]),

            }).ToList();

            return listOfOrders;
        }
    }
}


//OrderNumber = Convert.ToInt32(row["OrderNumber"]),
//OrderLineNumber = Convert.ToInt32(row["OrderLineNumber"]),
//ProductNumber = (row["ProductNumber"]).ToString(),
//Quantity = Convert.ToInt32(row["Quantity"]),
//Name = (row["Name"]).ToString(),
//Description = (row["Description"]).ToString(),
//Price = Convert.ToDouble(row["Price"]),
//ProductGroup = (row["ProductGroup"]).ToString(),
//OrderDate = Convert.ToDateTime(row["OrderDate"]),
//CustomerName = (row["CustomerName"]).ToString(),
//CustomerNumber = Convert.ToInt32(row["CustomerNumber"]),


//public async Task<List<Order>> MakeDataTableToOrderRequestList(DataTable dataTable)
//{
//    var listOfOrders = await Task.Run(() =>
//    {
//        return dataTable.AsEnumerable().Select(row => new Order
//        {
//            OrderNumber = row.Field<int>("OrderNumber"),
//            OrderLineNumber = row.Field<int>("OrderLineNumber"),
//            ProductNumber = row.Field<string>("ProductNumber"),
//            Quantity = row.Field<int>("Quantity"),
//            Name = row.Field<string>("Name"),
//            Description = row.Field<string>("Description"),
//            Price = row.Field<double>("Price"),
//            ProductGroup = row.Field<string>("ProductGroup"),
//            OrderDate = row.Field<DateTime>("OrderDate"),
//            CustomerName = row.Field<string>("CustomerName"),
//            CustomerNumber = row.Field<int>("CustomerNumber"),

//        }).ToList();
//    });

//    return listOfOrders;
//}

                    //OrderNumber = row.Field<int>("OrderNumber"),
                    //OrderLineNumber = row.Field<int>("OrderLineNumber"),
                    //ProductNumber = row.Field<string>("ProductNumber"),
                    //Quantity = row.Field<int>("Quantity"),
                    //Name = row.Field<string>("Name"),
                    //Description = row.Field<string>("Description"),
                    //Price = row.Field<double>("Price"),
                    //ProductGroup = row.Field<string>("ProductGroup"),
                    //OrderDate = row.Field<DateTime>("OrderDate"),
                    //CustomerName = row.Field<string>("CustomerName"),
                    //CustomerNumber = row.Field<int>("CustomerNumber"),