namespace Lab05.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("StudentMajor")]
    public partial class StudentMajor
    {
        [Key]
        public int ID { get; set; }

        [StringLength(20)]
        public string StudentID { get; set; }

        public int? MajorID { get; set; }

        public DateTime? RegistrationDate { get; set; }

        [StringLength(500)]
        public string Note { get; set; }

        public virtual Student Student { get; set; }

        public virtual Major Major { get; set; }
    }
}
