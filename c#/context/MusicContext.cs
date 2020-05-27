namespace Music
{
    using Music.bean;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MusicContext : DbContext
    {
      
        public MusicContext()
            : base("name=MusicContext")
        {
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }
        public DbSet<PlayListSong> PlayListSongs { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<MessageConclusionTime> MessageConclusionTimes { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }
       
    }

  
}