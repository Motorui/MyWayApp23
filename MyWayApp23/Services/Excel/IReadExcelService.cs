using Microsoft.AspNetCore.Components.Forms;

namespace MyWayApp23.Services.Excel
{
    public interface IReadExcelService
    {
        Task<DataTable> ReadExcelAsync(IBrowserFile stream);
    }
}