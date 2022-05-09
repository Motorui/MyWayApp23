using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyWayApp23.Areas.Identity.Pages.Admin.Roles;

public class CreateModel : BasePageModel
{
    private readonly RoleManager<IdentityRole> _roleManager;
    public CreateModel(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public InputModel Input { get; set; } = new InputModel();

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            var role = new IdentityRole(Input.Role);
            var addRoleResult = await _roleManager.CreateAsync(role);

            if (addRoleResult.Succeeded)
            {
                // valores poss�veis: primary, secondary, success, danger, warning, info,
                // light, dark, body, white, transparent
                ToastType = "success";
                ToastMessage = "Fun��o criada com sucesso!";
                return RedirectToPage("./Index");
            }
        }
        return Page();
    }

    public class InputModel
    {
        public string Role { get; set; } = string.Empty;
    }
}