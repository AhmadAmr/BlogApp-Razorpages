using BlogApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public virtual ApplicationUser Author { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        public bool Published { get; set; }

        public bool Draft { get; set; }

        public string Image { get; set; }

        public BlogStatus Status { get; set; }

        public virtual ApplicationUser Approver { get; set; }

        public virtual IEnumerable<EditHistory> EditHistories { get; set; }
    }

    public enum BlogStatus
    {
        Submitted,
        Approved,
        Rejected
    }

}

