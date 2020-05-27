using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.bean
{
    public class MessageConclusionTime
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public int FirstUserId {get; set;}
        [Required]
        public int SecondUserId {get; set;}
        [Required]
        public DateTime FirstUserDate {get; set;}
        [Required]
        public DateTime SecondUserDate { get; set;}

        public MessageConclusionTime(int id, int firstUserId, int secondUserId, DateTime firstUserDate, DateTime secondUserDate)
        {
            Id = id;
            FirstUserId = firstUserId;
            SecondUserId = secondUserId;
            FirstUserDate = firstUserDate;
            SecondUserDate = secondUserDate;
        }

        public MessageConclusionTime(int firstUserId, int secondUserId, DateTime firstUserDate, DateTime secondUserDate)
        {
            FirstUserId = firstUserId;
            SecondUserId = secondUserId;
            FirstUserDate = firstUserDate;
            SecondUserDate = secondUserDate;
        }

        public MessageConclusionTime()
        {
        }

        public override bool Equals(object obj)
        {
            var time = obj as MessageConclusionTime;
            return time != null &&
                   Id == time.Id &&
                   FirstUserId == time.FirstUserId &&
                   SecondUserId == time.SecondUserId &&
                   FirstUserDate == time.FirstUserDate &&
                   SecondUserDate == time.SecondUserDate;
        }

        public override int GetHashCode()
        {
            var hashCode = 211627914;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + FirstUserId.GetHashCode();
            hashCode = hashCode * -1521134295 + SecondUserId.GetHashCode();
            hashCode = hashCode * -1521134295 + FirstUserDate.GetHashCode();
            hashCode = hashCode * -1521134295 + SecondUserDate.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "MessageConclusionTime{" +
               "Id=" + Id +
               ", FirstUserId=" + FirstUserId +
               ", SecondUserId=" + SecondUserId +
               ", FirstUserDate=" + FirstUserDate +
               ", SecondUserDate=" + SecondUserDate +
               '}';
        }
    }
}
