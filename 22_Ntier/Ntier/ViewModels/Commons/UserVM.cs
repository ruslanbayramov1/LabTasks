using Ntier.ViewModels.Users;

#region Notes
// here we use that view model as general models so we can store other views and simply just using this model in every views
#endregion

namespace Ntier.ViewModels.Commons
{
    public class UserVM
    {
        public ICollection<UserProfileItemVM> Profiles { get; set; }
    }
}
