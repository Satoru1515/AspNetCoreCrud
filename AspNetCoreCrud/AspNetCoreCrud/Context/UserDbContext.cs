﻿using AspNetCoreCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCrud.Context
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }

    }
}
