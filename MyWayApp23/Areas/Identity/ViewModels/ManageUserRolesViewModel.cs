﻿namespace MyWayApp23.Areas.Identity.ViewModels;

public class ManageUserRolesViewModel
{
    public string RoleId { get; set; } = string.Empty;
    public string RoleName { get; set; } = string.Empty;
    public bool Selected { get; set; } = false;
}