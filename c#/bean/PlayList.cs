using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.bean
{
    public class PlayList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
     
        public string Name   { get; set; }
        [Required]
        [MaxLength(1000)]
      
        public string Description { get; set; }
        [Required]
      
        public int UserId { get; set; }
        public List<PlayListSong> PlayListSongs { get; set; }

        public PlayList(int id, string name, string description, int userId)
        {
            Id = id;
            Name = name;
            Description = description;
            UserId = userId;
        }

        public PlayList(string name, string description, int userId)
        {
            Name = name;
            Description = description;
            UserId = userId;
        }

        public PlayList()
        {
        }

        public override bool Equals(object obj)
        {
            var list = obj as PlayList;
            return list != null &&
                   Id == list.Id &&
                   Name == list.Name &&
                   Description == list.Description &&
                   UserId == list.UserId;
        }

        public override int GetHashCode()
        {
            var hashCode = 224666902;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + UserId.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "PlayList{" +
                 "Id=" + Id +
                 ", Name='" + Name + '\'' +
                 ", Description='" + Description + '\'' +
                 ", UserId=" + UserId +
                 '}';
        }
    }
}
