using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.bean
{
    public class PlayListSong
    {
        [Key]
        public int Id { get; set; }
        [Required]
        
        public int SongId { get; set; }
        [Required]
      
        public int PlayListId { get; set; }

        public PlayListSong(int id, int songId, int playListId)
        {
            Id = id;
            SongId = songId;
            PlayListId = playListId;
        }

        public PlayListSong(int songId, int playListId)
        {
            SongId = songId;
            PlayListId = playListId;
        }

        public PlayListSong()
        {
        }

        public override bool Equals(object obj)
        {
            var song = obj as PlayListSong;
            return song != null &&
                   Id == song.Id &&
                   SongId == song.SongId &&
                   PlayListId == song.PlayListId;
        }

        public override int GetHashCode()
        {
            var hashCode = -16023929;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + SongId.GetHashCode();
            hashCode = hashCode * -1521134295 + PlayListId.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "PlayListSong{" +
                "Id=" + Id +
                ", SongId=" + SongId +
                ", PlayListId=" + PlayListId +
                '}';
        }
    }
}
