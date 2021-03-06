// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TopChoiceHardware.UsersService.AccessData;

namespace TopChoiceHardware.UsersService.AccessData.Migrations
{
    [DbContext(typeof(UsuariosContext))]
    [Migration("20211205183109_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TopChoiceHardware.UsersService.Domain.Entities.Rol", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Description = "Admin Role",
                            Name = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            Description = "User Role",
                            Name = "User"
                        });
                });

            modelBuilder.Entity("TopChoiceHardware.UsersService.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasMaxLength(9)
                        .IsUnicode(false)
                        .HasColumnType("varchar(9)")
                        .HasColumnName("DNI");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            DNI = "35189786",
                            Email = "msalinas@topchoice.com",
                            Name = "Matías Salinas",
                            Password = "verysafepassword",
                            RoleId = 1,
                            Username = "Coderboy"
                        },
                        new
                        {
                            UserId = 2,
                            DNI = "44878545",
                            Email = "rlago@topchoice.com",
                            Name = "Rodrigo Lago",
                            Password = "rodripassword",
                            RoleId = 1,
                            Username = "Rodri CSGO"
                        },
                        new
                        {
                            UserId = 3,
                            DNI = "28956521",
                            Email = "cdamico@topchoice.com",
                            Name = "Claudio Damico",
                            Password = "damico1234",
                            RoleId = 2,
                            Username = "cdamico"
                        },
                        new
                        {
                            UserId = 4,
                            DNI = "48555222",
                            Email = "jlfernandez@topchoice.com",
                            Name = "Jose Luis Fernández",
                            Password = "badpassword",
                            RoleId = 2,
                            Username = "Josele"
                        });
                });

            modelBuilder.Entity("TopChoiceHardware.UsersService.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("TopChoiceHardware.UsersService.Domain.Entities.Rol", "Role")
                        .WithMany("Usuarios")
                        .HasForeignKey("RoleId")
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TopChoiceHardware.UsersService.Domain.Entities.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
