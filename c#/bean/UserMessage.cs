using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.bean
{
   public class UserMessage
    {
        [Key]
        public int Id { get; set; }
        [Required]
      
        public int MessageId { get; set; }
        [Required]
       
        public int UserId { get; set; }

        public UserMessage(int id, int messageId, int userId)
        {
            Id = id;
            MessageId = messageId;
            UserId = userId;
        }

        public UserMessage(int messageId, int userId)
        {
            MessageId = messageId;
            UserId = userId;
        }

        public UserMessage()
        {
        }

        public override bool Equals(object obj)
        {
            var message = obj as UserMessage;
            return message != null &&
                   Id == message.Id &&
                   MessageId == message.MessageId &&
                   UserId == message.UserId;
        }

        public override int GetHashCode()
        {
            var hashCode = 861166800;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + MessageId.GetHashCode();
            hashCode = hashCode * -1521134295 + UserId.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "UserMessage{" +
                "Id=" + Id +
                ", MessageId=" + MessageId +
                ", UserId=" + UserId +
                '}';
        }
    }
}
