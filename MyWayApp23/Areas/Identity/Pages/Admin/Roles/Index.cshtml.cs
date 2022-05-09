using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyWayApp23.Data;

namespace MyWayApp23.Areas.Identity.Pages.Admin.Roles;

public class IndexModel : BasePageModel
{
    private readonly DataContext _context;

    public IndexModel(DataContext context)
    {
        _context = context;
    }

    public IList<IdentityRole> IdentityRoles { get; set; } = new List<IdentityRole>();

    public async Task OnGetAsync()
    {
        IdentityRoles = await _context.Roles.OrderBy(n => n.Name).ToListAsync();
    }
}