namespace Ntier.ViewModels.Users;
#region Notes
// viewmodels are for users, some for display and some for taking data. here we only want to show users email and name and we create view model
#endregion
public class UserProfileItemVM
{
    public string Name { get; set; }
    public string Email { get; set; }
}
