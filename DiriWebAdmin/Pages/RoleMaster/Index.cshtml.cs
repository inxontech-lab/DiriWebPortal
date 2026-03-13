using DiriWebAdmin.Services;
using Domain.DBModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiriWebAdmin.Pages.RoleMaster
{
    public class IndexModel : PageModel
    {
        private readonly RoleMasterApiClient _roleMasterApiClient;

        public IndexModel(RoleMasterApiClient roleMasterApiClient)
        {
            _roleMasterApiClient = roleMasterApiClient;
        }

        public List<Domain.DBModels.RoleMaster> Roles { get; set; } = new();

        [BindProperty]
        public Domain.DBModels.RoleMaster RoleForm { get; set; } = new()
        {
            IsActive = true
        };

        [BindProperty(SupportsGet = true)]
        public int? EditId { get; set; }

        public string StatusMessage { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            await LoadDataAsync();

            if (EditId.HasValue)
            {
                var selected = Roles.FirstOrDefault(x => x.RoleId == EditId.Value);
                if (selected != null)
                {
                    RoleForm = new Domain.DBModels.RoleMaster
                    {
                        RoleId = selected.RoleId,
                        RoleName = selected.RoleName,
                        RoleCode = selected.RoleCode,
                        Description = selected.Description,
                        IsActive = selected.IsActive,
                        CreatedBy = selected.CreatedBy,
                        ModifiedBy = selected.ModifiedBy
                    };
                }
            }
        }

        public async Task<IActionResult> OnPostSaveAsync()
        {
            if (string.IsNullOrWhiteSpace(RoleForm.RoleName))
            {
                StatusMessage = "Role name is required.";
                await LoadDataAsync();
                return Page();
            }

            if (RoleForm.RoleId > 0)
            {
                RoleForm.ModifiedBy ??= "Admin";
                var result = await _roleMasterApiClient.UpdateAsync(RoleForm);
                StatusMessage = result?.RESPONSE_DESCRPTION ?? "Role updated.";
            }
            else
            {
                RoleForm.CreatedBy ??= "Admin";
                var result = await _roleMasterApiClient.CreateAsync(RoleForm);
                StatusMessage = result?.RESPONSE_DESCRPTION ?? "Role created.";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int roleId)
        {
            await _roleMasterApiClient.DeleteAsync(roleId);
            return RedirectToPage();
        }

        private async Task LoadDataAsync()
        {
            Roles = await _roleMasterApiClient.GetAllAsync();
        }
    }
}
