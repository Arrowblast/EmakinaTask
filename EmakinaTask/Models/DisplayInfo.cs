using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmakinaTask.Models
{
    public class DisplayInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InfoID { get; set; }
        public int GameID { get; set; } 
        public DateTime DateTime { get; set; }
        public string Browser { get; set; }

        [ForeignKey("GameID")]
        public virtual BoardGame boardGame { get; set; }
    }
    
}