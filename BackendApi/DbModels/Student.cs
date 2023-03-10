using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.DbModels;

[Table("Student")]
public partial class Student
{
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Key]
    [StringLength(50)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [InverseProperty("Student")]
    public virtual ICollection<Mark> Marks { get; } = new List<Mark>();
}
