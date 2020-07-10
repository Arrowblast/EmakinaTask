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
        [Display(Name = "Name of the game")]
        [StringLength(100,MinimumLength=3)]
        public string GameName { get; set; }
        [Display(Name = "Minimal amount of players")]
        [Range(1, 100)]
        public int MinPlayers { get; set; }
        [Display(Name = "Maximal amount of players")]
        [Range(1, 100)]
        public int MaxPlayers { get; set; }
        [Display(Name = "Minimal age of players")]
        [Range(1,100)]
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