using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public record Comment
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PostId { get; set; }

        [StringLength(120)]
        public string Content { get; set; }
        [StringLength(30)]
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }
    }
}