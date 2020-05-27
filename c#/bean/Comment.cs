using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.bean
{
   public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
     
        public string Text { get; set; }
        [Required]
     
        public DateTime date { get; set; }
        [Required]
      
        public int UserId { get; set; }
        [Required]
       
        public int SongId { get; set; }

        public Comment(int id, string text, DateTime date, int userId, int songId)
        {
            Id = id;
            Text = text;
            this.date = date;
            UserId = userId;
            SongId = songId;
        }

        public Comment(string text, DateTime date, int userId, int songId)
        {
            Text = text;
            this.date = date;
            UserId = userId;
            SongId = songId;
        }

        public Comment()
        {
        }

        public override string ToString()
        {
            return "Comment{" +
                 "Id=" + Id +
                 ", Text='" + Text + '\'' +
                 ", UserId=" + UserId +
                 ", date=" + date +
                 ", SongId=" + SongId +
                 '}';
        }

        public override bool Equals(object obj)
        {
            var comment = obj as Comment;
            return comment != null &&
                   Id == comment.Id &&
                   Text == comment.Text &&
                   date == comment.date &&
                   UserId == comment.UserId &&
                   SongId == comment.SongId;
        }

        public override int GetHashCode()
        {
            var hashCode = -147973881;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Text);
            hashCode = hashCode * -1521134295 + date.GetHashCode();
            hashCode = hashCode * -1521134295 + UserId.GetHashCode();
            hashCode = hashCode * -1521134295 + SongId.GetHashCode();
            return hashCode;
        }
    }
}
