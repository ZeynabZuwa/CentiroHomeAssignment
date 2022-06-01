using CentiroAssignment.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CentiroAssignment.Services.Features.CSV_Files
{
    public interface ICSVFileService
    {
        DataTable CSVConvertToDataTable(string strFilePath);
        Task<List<Order>> MakeDataTableToOrderRequestList(DataTable dataTable);
    }
}
