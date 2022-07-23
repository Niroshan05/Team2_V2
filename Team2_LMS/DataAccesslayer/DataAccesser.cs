﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team2_LMS.Models;

namespace Team2_LMS.DataAccesslayer
{
    public class DataAccesser:DbContext
    {
        public DataAccesser(DbContextOptions<DataAccesser>options):base(options)
        {

        }
        public DbSet<EmployeeDB> employeeDBs { get; set; }
        public DbSet<ManagerDb> managerDbs { get; set; }
        //public DbSet<ManagerDb> ManagerDbs { get; set; }
        //public DbSet<CeoDB> ceoDBs { get; set; }
        public DbSet<LeaveManagementDB> leavemanagementDbs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
    {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
