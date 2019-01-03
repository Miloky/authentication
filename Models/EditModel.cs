using System.Collections.Generic;

namespace authentication.Models
{
    public class EditModel
    {
        public EditModel(string roleName)
        {
            RoleName = roleName;
            Users = new List<EditRoleUser>();
        }
        public string RoleName { get; set; }
        public List<EditRoleUser> Users { get; set; }
    }
}
