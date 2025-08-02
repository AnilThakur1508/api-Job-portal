﻿
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeQualification> EmployeeQualifications { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<JobSkill> JobSkills { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<JobCourse> JobCourses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<ExperienceLevel> ExperienceLevels { get; set; }
    }
}

