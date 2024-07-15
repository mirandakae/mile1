using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Milestone.Models
{
    public class UserModel
    {
        
        public required string UserName { get; set; }
        
        public required string Password { get; set; }
        public UserModel()
        {
        }
    }
}
