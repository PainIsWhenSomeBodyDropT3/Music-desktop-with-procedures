using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.bean
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(16)]
        [MinLength(4)]
        public string Login { get; set; }
        [Required]
        [MaxLength(40)]
        [MinLength(4)]
        public string Password { get; set; }
        [Required]
        
        public Role  Role { get; set; }
        public List<PlayList> PlayLists { get; set; }
        public List<Comment> Comments { get; set; }
        public List<UserMessage> UserMessages { get; set; }
      

       // public List<MessageConclusionTime> MessageConclusionTimes { get; set; }
       

        public User(int id, string login, string password, Role role)
        {
            Id = id;
            Login = login;
            Password = password;
            Role = role;
        }

        public User(string login, string password, Role role)
        {
            Login = login;
            Password = password;
            Role = role;
        }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public User()
        {
        }

        public override bool Equals(object obj)
        {
            var user = obj as User;
            return user != null &&
                   Id == user.Id &&
                   Login == user.Login &&
                   Password == user.Password &&
                   Role == user.Role;
        }

        public override int GetHashCode()
        {
            var hashCode = -480597469;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Login);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            hashCode = hashCode * -1521134295 + Role.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "User{" +
                "Id=" + Id +
                ", Login='" + Login + '\'' +
                ", Password='" + Password + '\'' +
                ", Role=" + Role +
                '}';
        }
    }
}
