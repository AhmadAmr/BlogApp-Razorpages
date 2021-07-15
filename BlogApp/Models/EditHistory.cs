using BlogApp.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class EditHistory
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedOn { get; set; }

        public virtual ApplicationUser user { get; set; }
    }
}