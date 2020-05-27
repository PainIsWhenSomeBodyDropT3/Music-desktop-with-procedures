using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.bean
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
       
        public string Text { get; set; }
        [Required]
      
        public int UserId { get; set; }
        [Required]
       
        public DateTime Date { get; set; }

        public List<UserMessage> UserMessages { get; set; }

        public Message(int id, string text, int senderId, DateTime date)
        {
            Id = id;
            Text = text;
            UserId = senderId;
            Date = date;
        }

        public Message(string text, int senderId, DateTime date)
        {
            Text = text;
            UserId = senderId;
            Date = date;
        }

        public Message()
        {
        }

        
        public override string ToString()
        {
            return "Message{" +
                "Id=" + Id +
                ", Text='" + Text + '\'' +
                ", SenderId=" + UserId +
                ", Date=" + Date +
                '}';
        }

        public override bool Equals(object obj)
        {
            var message = obj as Message;
            return message != null &&
                   Text == message.Text &&
                   UserId == message.UserId &&
                   Date == message.Date;
        }

        public override int GetHashCode()
        {
            var hashCode = -187055288;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Text);
            hashCode = hashCode * -1521134295 + UserId.GetHashCode();
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            return hashCode;
        }
    }
}
