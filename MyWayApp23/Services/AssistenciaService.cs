namespace MyWayApp23.Services;

public class AssistenciaService
{
    private readonly DataContext _context;
    public List<Assistencia> Assistencias { get; set; } = new();
    public string Message { get; set; } = string.Empty;

    public AssistenciaService(DataContext context)
    {
        _context = context;
    }

    public List<Assistencia> GetAll()
    {
        try
        {
            Assistencias = _context.Assistencias!.ToList();
        }
        catch (Exception ex)
        {
            Message = ex.Message;
        }

        return Assistencias;
    }

    public async Task<string> Insert(Assistencia assistencia)
    {
        try
        {
            _ = _context.AddAsync(assistencia);
        }
        catch (Exception ex)
        {
            Message = ex.Message;
            throw;
        }

        return Message;
    }

}
