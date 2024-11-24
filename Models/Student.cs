using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace Gestion_etudiant.Models;
public class Student{

public int StudentId { get; set; }
[Required]
public string? StudentName { get; set; }
[Range(1,100)]
public int Age { get; set; }
[DataType(DataType.Date)]
public DateTime BirthDate { get; set; }
public int SchoolID { get; set; }
public virtual School? School { get; set; }

}
