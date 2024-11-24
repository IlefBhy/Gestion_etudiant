using System;
using System.Collections.Generic;
namespace Gestion_etudiant.Models;
public class School {

public int SchoolID { get; set; }
public string SchoolName { get; set; }
public string SchoolAdress { get; set; }
public virtual ICollection<Student> Students { get; set; }= new List<Student>();
}
