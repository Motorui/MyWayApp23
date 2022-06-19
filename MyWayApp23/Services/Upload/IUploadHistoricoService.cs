using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Components.Forms;

namespace MyWayApp23.Services.Upload;

public interface IUploadHistoricoService
{
    IList<HistoricoAssistencia> HistoricoAssistencias { get; set; }
    Task<StatsInfo> UploadFile(IBrowserFile arquivoEntrada);
}