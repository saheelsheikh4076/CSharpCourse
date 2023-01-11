namespace IdentityProject.Models
{
    public class ProfileViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        //public List<AppRoles> Roles { get; set; }
        public List<AppUserRoles> UserRoles { get; set; }
    }
    public class AppRoles
    {
        public string Id { get; set; }
        public string RoleName { get; set;}
    }
    public class AppUserRoles
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsAssigned { get; set; }
    }
}
