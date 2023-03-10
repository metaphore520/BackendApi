using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.DbModels;

[Table("Mark")]
public partial class Mark
{
    [Key]
    [StringLength(50)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string StudentId { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string CourseId { get; set; } = null!;

    [Column("Mark")]
    public int Mark1 { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Marks")]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("Marks")]
    public virtual Student Student { get; set; } = null!;
}
