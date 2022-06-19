using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Components.Forms;
using MyWayApp23.Services.Excel;
using System.Diagnostics;

namespace MyWayApp23.Services.Upload;

public class UploadHistoricoService : IUploadHistoricoService
{
    private readonly DataContext db;
    private readonly IWebHostEnvironment env;
    private readonly IReadExcelService readExcel;
    private readonly IDataTableConverter converter;

    public UploadHistoricoService(DataContext context, IWebHostEnvironment environment,
        IReadExcelService readExcelService, IDataTableConverter dataConverter)
    {
        db = context;
        env = environment;
        readExcel = readExcelService;
        converter = dataConverter;
    }

    public IList<HistoricoAssistencia> HistoricoAssistencias { get; set; } = new List<HistoricoAssistencia>();

    public async Task<StatsInfo> UploadFile(IBrowserFile arquivoEntrada)
    {
        Stopwatch stopwatch = new();
        stopwatch.Start();

        FileStream stream;
        var path = Path.Combine(env.ContentRootPath, "Uploads",
        arquivoEntrada.Name);

        DirectoryInfo di = new("Uploads");
        foreach (FileInfo file in di.GetFiles())
        {
            file.Delete();
        }

        var ms = new MemoryStream();
        await arquivoEntrada.OpenReadStream(30000000).CopyToAsync(ms);

        using (FileStream arquivo = new(path, FileMode.Create,
                FileAccess.Write))
        {
            ms.WriteTo(arquivo);
        }

        stream = File.Open(path, FileMode.Open, FileAccess.Read);

        DataTable dt = readExcel.ReadLocalExcelAsync(stream);
        List<HistoricoAssistencia> historico = converter.ConvertDtToHistorico(dt);
        //var detalhe = ConvertToDetalhe(historico);

        StatsInfo stats = new();
        using (var transaction = db.Database.BeginTransaction())
        {
            db.Database.SetCommandTimeout(600);
            var bulkConfig = new BulkConfig
            {
                SetOutputIdentity = true,
                CalculateStats = true,
                BatchSize = 100,
                BulkCopyTimeout = 600,
                //UpdateByProperties = new List<string>
                //{ "Aeroporto", "Data", "Inicio", "Mov", "Pax" }
            };

            await db.BulkInsertOrUpdateAsync(historico, bulkConfig);

            transaction.Commit();

            stats = bulkConfig.StatsInfo!;
        }
        
        stopwatch.Stop();

        TimeSpan ts = stopwatch.Elapsed;

        Console.WriteLine("Elapsed Time is {0:00}:{1:00}:{2:00}.{3}",
                        ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
        return stats;
    }

    //public List<HistoricoDetalhe> ConvertToDetalhe(List<HistoricoAssistencia> historico)
    //{
    //    List<HistoricoDetalhe> result = historico.AsEnumerable()
    //        .GroupBy(g => new { UH = g.Aeroporto, Dia = g.Data.Date })
    //        .Select(x => new HistoricoDetalhe
    //        {
    //            Id = string.Concat(x.Key.UH, "-", x.Key.Dia.ToShortDateString()).ToUpper(),
    //            Uh = x.Key.UH,
    //            Data = x.Key.Dia,
    //            DiaDaSemana = x.Key.Dia.DayOfWeek,
    //            TotalDia = x.Count(),
    //            Dep = x.Count(d => d.Mov.Equals("D")),
    //            DepPercentage = PercentageHelper.PercentageToDouble(
    //                x.Count(d => d.Mov.Equals("D")), x.Count()),
    //            Arr = x.Count(d => d.Mov.Equals("A")),
    //            ArrPercentage = PercentageHelper.PercentageToDouble(
    //                x.Count(d => d.Mov.Equals("D")), x.Count()),
    //            JetBridge = x.Count(d => GetStandList(true, d.Aeroporto)
    //            .Contains(d.Stand!)),
    //            JetBridgePercentage = PercentageHelper.PercentageToDouble(
    //                x.Count(d => GetStandList(true, d.Aeroporto)
    //                .Contains(d.Stand!)), x.Count()),
    //            Remote = x.Count(d => GetStandList(false, d.Aeroporto)
    //                .Contains(d.Stand!)),
    //            RemotePercentage = PercentageHelper.PercentageToDouble(
    //                x.Count(d => GetStandList(false, d.Aeroporto)
    //                .Contains(d.Stand!)), x.Count()),
    //            Mais36 = x.Count(d => d.Notif >= 36),
    //            PercentageMais36 = PercentageHelper.PercentageToDouble(
    //                x.Count(d => d.Notif >= 36), x.Count()),
    //            Menos36 = x.Count(d => d.Notif >= 36),
    //            PercentageMenos36 = PercentageHelper.PercentageToDouble(
    //                x.Count(d => d.Notif < 36), x.Count()),
    //            Wchr = x.Count(w => w.SSR.ToUpper().Contains("WCHR")),
    //            Wchs = x.Count(w => w.SSR.ToUpper().Contains("WCHS")),
    //            Wchc = x.Count(w => w.SSR.ToUpper().Contains("WCHC")),
    //            Maas = x.Count(w => w.SSR.ToUpper().Contains("MAAS")),
    //            Blnd = x.Count(w => w.SSR.ToUpper().Contains("BLND")),
    //            Deaf = x.Count(w => w.SSR.ToUpper().Contains("DEAF")),
    //            Dpna = x.Count(w => w.SSR.ToUpper().Contains("DPNA")),
    //            Stcr = x.Count(w => w.SSR.ToUpper().Contains("STCR")),
    //            Meda = x.Count(w => w.SSR.ToUpper().Contains("MEDA")),
    //            Wcmp = x.Count(w => w.SSR.ToUpper().Contains("WCMP")),
    //            Wcbd = x.Count(w => w.SSR.ToUpper().Contains("WCBD")),
    //            Wcbw = x.Count(w => w.SSR.ToUpper().Contains("WCBW")),
    //            Media = x.Average(m => m.Duracao)
    //        }
    //        ).ToList();

    //    return result;
    //}


    public List<string> GetStandList(bool manga, string uh)
    {
        string tipo = manga ? "JETBRIDGE" : "REMOTE";

        return db.Stands!.Where(t => t.Tipo == tipo && t.Aeroporto.Equals(uh))
            .Select(m => m.Numero).ToList();
    }
}
