using System.Data;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Services
{
    public interface IVSCDataService
    {
        Task<DataTable> ReadExcelToDataTable(string fileName);
    }
}
