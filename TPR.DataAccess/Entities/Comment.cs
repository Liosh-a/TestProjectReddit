using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TPR.DataAccess.Entities
{
    [Table("tbl.Comments")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Posts")]
        public int PostsId { get; set; }
        public virtual Post Posts { get; set; }
    }
}
