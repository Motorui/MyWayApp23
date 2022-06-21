using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyWayApp23.Areas.Identity.ViewModels;

namespace MyWayApp23.Areas.Identity.Pages.Admin.Users;

public class ManageModel : BasePageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ManageModel(UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public IdentityUser CurrentUser { get; set; } = new IdentityUser();
    [BindProperty]
    public IList<ManageUserRolesViewModel> UserRoles { get; set; } = new List<ManageUserRolesViewModel>();

    public async Task OnGetAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return;
        }
        CurrentUser.UserName = user.UserName;

        foreach (var role in _roleManager.Roles.ToList())
        {
            var userRole = new ManageUserRolesViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name!
            };
            if (await _userManager.IsInRoleAsync(user, role.Name!))
            {
                userRole.Selected = true;
            }
            else
            {
                userRole.Selected = false;
            }
            UserRoles.Add(userRole);
        }
    }
    public async Task<IActionResult> OnPostAsync(string id)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return Page();
            }
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "N�o � poss�vel remover os roles existentes");
                return Page();
            }
            result = await _userManager.AddToRolesAsync(user, UserRoles.Where(x => x.Selected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "N�o � poss�vel adicionar os roles selecionados");
                return Page();
            }
        }

        // valores poss�veis: primary, secondary, success, danger, warning, info,
        // light, dark, body, white, transparent
        ToastType = "success";
        ToastMessage = $"Fun��es atribuidas com sucesso";
        return LocalRedirect("~/Identity/Admin/Users/Index");

    }
}