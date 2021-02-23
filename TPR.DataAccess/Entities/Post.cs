using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TPR.DataAccess.Entities
{
    [Table("tbl.Posts")]
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Subreddit")]
        public int SubredditId { get; set; }
        public virtual Subreddit Subreddit { get; set; }
        public virtual List<Comment> CommentsId { get; set; }
    }
}
