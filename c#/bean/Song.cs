using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.bean
{
  public  class Song
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
    
        public string LocalUrl { get; set; }
        [Required]
        [MaxLength(50)]
       
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]

        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
      
        public string Type { get; set; }
        [Required]
        [MaxLength(50)]
        
        public string AuthorName { get; set; }
        [Required]
       
        public DateTime ReleaseDate { get; set; }
        [Required]
        [MaxLength(50)]
      
        public string Album { get; set; }
        [Required]
       
        public int Duraction { get; set; }
        [Required]
        
        public int NumberOfPlays { get; set; }

        public List<PlayListSong> PlayListSongs { get; set; }
        public List<Comment> Comments { get; set; }

        public Song(string localUrl, string name, string description, string type, string authorName, DateTime releaseDate, string album, int duraction, int numberOfPlays)
        {
            LocalUrl = localUrl;
            Name = name;
            Description = description;
            Type = type;
            AuthorName = authorName;
            ReleaseDate = releaseDate;
            Album = album;
            Duraction = duraction;
            NumberOfPlays = numberOfPlays;
        }

        public Song(int id, string localUrl, string name, string description, string type, string authorName, DateTime releaseDate, string album, int duraction, int numberOfPlays)
        {
            Id = id;
            LocalUrl = localUrl;
            Name = name;
            Description = description;
            Type = type;
            AuthorName = authorName;
            ReleaseDate = releaseDate;
            Album = album;
            Duraction = duraction;
            NumberOfPlays = numberOfPlays;
        }

        public Song()
        {
        }

        public override bool Equals(object obj)
        {
            var song = obj as Song;
            return song != null &&
                   Id == song.Id &&
                   LocalUrl == song.LocalUrl &&
                   Name == song.Name &&
                   Description == song.Description &&
                   Type == song.Type &&
                   AuthorName == song.AuthorName &&
                   ReleaseDate == song.ReleaseDate &&
                   Album == song.Album &&
                   Duraction == song.Duraction &&
                   NumberOfPlays == song.NumberOfPlays;
        }

        public override int GetHashCode()
        {
            var hashCode = 1013002190;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LocalUrl);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AuthorName);
            hashCode = hashCode * -1521134295 + ReleaseDate.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Album);
            hashCode = hashCode * -1521134295 + Duraction.GetHashCode();
            hashCode = hashCode * -1521134295 + NumberOfPlays.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Song{" +
                "Id=" + Id +
                ", LocalUrl='" + LocalUrl + '\'' +
                ", Name='" + Name + '\'' +
                ", Description='" + Description + '\'' +
                ", Type='" + Type + '\'' +
                ", AuthorName='" + AuthorName + '\'' +
                ", ReleaseDate='" + ReleaseDate +
                ", Album='" + Album + '\'' +
                ", Duraction=" + Duraction +
                ", NumberOfPlays=" + NumberOfPlays +
                '}';
        }
    }
}
