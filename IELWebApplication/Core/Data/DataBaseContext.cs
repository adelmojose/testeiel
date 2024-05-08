using IELCadastroEstudante.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace IELCadastroEstudante.Core.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
        public DbSet<Estudante> Estudante { get; set; }
        public DbSet<InstituicaoEnsino> InstituicaoEnsino { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Estado> Estado { get; set; }
    }
}

