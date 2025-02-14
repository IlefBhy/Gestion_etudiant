using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Gestion_etudiant.Models;

public class StudentContext : DbContext
{
    public StudentContext(DbContextOptions<StudentContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<School> Schools { get; set; }
}

