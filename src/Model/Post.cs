using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public record Post
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(30)]
        public string Title { get; set; }
        [StringLength(120)]
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
}