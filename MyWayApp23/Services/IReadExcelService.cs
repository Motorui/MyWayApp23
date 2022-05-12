using Microsoft.AspNetCore.Components.Forms;

namespace MyWayApp23.Services
{
    public interface IReadExcelService
    {
        Task<DataTable> ReadExcelAsync(IBrowserFile stream);
    }
}