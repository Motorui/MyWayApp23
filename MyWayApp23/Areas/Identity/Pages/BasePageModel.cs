using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWayApp23.Areas.Identity.Pages;

public class BasePageModel : PageModel
{
    [TempData]
    public string ToastType { get; set; } = string.Empty;
    [TempData]
    public string ToastMessage { get; set; } = string.Empty;
}