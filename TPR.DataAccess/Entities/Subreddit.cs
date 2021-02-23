using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TPR.DataAccess.Entities
{
    [Table("tbl.Subreddit")]
    public class Subreddit
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Post> PostsId { get; set; }
    }
}
