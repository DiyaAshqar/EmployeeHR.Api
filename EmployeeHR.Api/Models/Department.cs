﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeHR.Api.Models
{
    [Table("Departments", Schema = "dbo")]
    public class Department
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Department ID")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Department Name")]
        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Abbreviation")]
        [Column(TypeName = "char(3)")]
        [StringLength(3)]
        public string Abbreviation { get; set; }



    }
}
