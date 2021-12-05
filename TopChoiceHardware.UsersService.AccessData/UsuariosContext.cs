using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChoiceHardware.UsersService.Domain.Entities;

namespace TopChoiceHardware.UsersService.AccessData
{
    public class UsuariosContext: DbContext
    {
        public UsuariosContext(){}

        public UsuariosContext(DbContextOptions<UsuariosContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.DNI)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("DNI");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    RoleId = 1,
                    Name = "Admin",
                    Description = "Admin Role"
                },
                new Rol
                {
                    RoleId = 2,
                    Name = "User",
                    Description = "User Role"
                }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    UserId = 1,
                    Name = "Matías Salinas",
                    Username = "Coderboy",
                    DNI = "35189786",
                    Email = "msalinas@topchoice.com",
                    Password = "verysafepassword",
                    RoleId = 1
                },
                new Usuario
                {
                    UserId = 2,
                    Name = "Rodrigo Lago",
                    Username = "Rodri CSGO",
                    DNI = "44878545",
                    Email = "rlago@topchoice.com",
                    Password = "rodripassword",
                    RoleId = 1
                },
                new Usuario
                {
                    UserId = 3,
                    Name = "Claudio Damico",
                    Username = "cdamico",
                    DNI = "28956521",
                    Email = "cdamico@topchoice.com",
                    Password = "damico1234",
                    RoleId = 2
                },
                new Usuario
                {
                    UserId = 4,
                    Name = "Jose Luis Fernández",
                    Username = "Josele",
                    DNI = "48555222",
                    Email = "jlfernandez@topchoice.com",
                    Password = "badpassword",
                    RoleId = 2
                }

            );

        }

        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
