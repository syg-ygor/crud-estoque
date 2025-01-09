﻿using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; } = default!;
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProductsOrders { get; set; }
    }
}
