namespace tests.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Answers
    {
        [Key]
        public int AnswerId { get; set; }

        public string Content { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
