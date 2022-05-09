using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyWayApp23.Areas.Identity.Pages.Admin.Roles;

public class EditModel : BasePageModel
{
    private readonly RoleManager<IdentityRole> _roleManager;
    public EditModel(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    [BindProperty]
    public IdentityRole Role { get; set; } = new IdentityRole();

    public async Task<IActionResult> OnGetAsync(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Role = await _roleManager.FindByIdAsync(id);

        if (Role == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string id)
    {
        if (ModelState.IsValid)
        {
            var currentRole = _roleManager.FindByIdAsync(id).Result;

            currentRole.Name = Role.Name;

            if (currentRole != null)
            {
                var updateRoleResult = await _roleManager.UpdateAsync(currentRole);

                if (updateRoleResult.Succeeded)
                {
                    // valores poss�veis: primary, secondary, success, danger, warning, info,
                    // light, dark, body, white, transparent
                    ToastType = "success";
                    ToastMessage = "Fun��o editada com sucesso!";
                    return RedirectToPage("./Index");
                }
            }
        }
        return Page();
    }

}