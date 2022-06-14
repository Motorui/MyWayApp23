namespace MyWayApp23.Services.Tabelas;

public class StandService : IStandService
{
    private readonly DataContext _context;

    public StandService(DataContext context)
    {
        _context = context;
    }

    public List<string> GetStands(bool manga, string uh)
    {
        string tipo = manga ? "JETBRIDGE" : "REMOTE";

        return _context.Stands!.Where(t => t.Tipo == tipo && t.Aeroporto.Equals(uh))
            .Select(m => m.Numero).ToList();
    }
}
