//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TermProjectBookkeeping
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bookkeepingEntities2 : DbContext
    {
        public bookkeepingEntities2()
            : base("name=bookkeepingEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<employeesalary> employeesalary { get; set; }
        public virtual DbSet<purchaselist> purchaselist { get; set; }
        public virtual DbSet<salaryfund> salaryfund { get; set; }
        public virtual DbSet<scholarshipfund> scholarshipfund { get; set; }
        public virtual DbSet<studentscholarship> studentscholarship { get; set; }
        public virtual DbSet<userrole> userrole { get; set; }
        public virtual DbSet<userinfo> userinfo { get; set; }
    }
}
