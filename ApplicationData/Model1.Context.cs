﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_PR17_restaurant__Kile.ApplicationData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ZebraEntities : DbContext
    {
        private static ZebraEntities _context;
        public ZebraEntities()
            : base("name=ZebraEntities")
        {
        }
        public static ZebraEntities GetContext()
        {
            if (_context == null)
                _context = new ZebraEntities();
            return _context;
        }
        
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TableName> TableName { get; set; }
        public virtual DbSet<TableStatus> TableStatus { get; set; }
        public virtual DbSet<TableStol> TableStol { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Zakaz> Zakaz { get; set; }
    }
}
