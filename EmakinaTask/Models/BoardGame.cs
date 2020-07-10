using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmakinaTask.Models
{
    public class BoardGame
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string GameName { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int MinAge { get; set; }
        
        public virtual ICollection<DisplayInfo> Infos { get; set; }
    }
    public class BoardgameDbContext: DbContext {
        public BoardgameDbContext()
        {

        }
        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<DisplayInfo> DisplayInfoes { get; set; }
    }
}   