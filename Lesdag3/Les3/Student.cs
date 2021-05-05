namespace Les3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //dit is gemapped met de tabel Student
    [Table("Student")]
    public partial class Student
    {
        //Dit wordt automatisch aangemaakt door de database
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        //de kolom Naam mag niet null zijn en max 50 karaketers
        [Required]
        [StringLength(50)]
        public string Naam { get; set; }

        //de kolom Naam mag niet null zijn en max 10 karaketers
        [Required]
        [StringLength(10)]
        public string Score { get; set; }
    }
}
