using System;
using Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL
{
    public partial class SignContext : DbContext
    {
        public SignContext()
        {
        }

        public SignContext(DbContextOptions<SignContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<FormSigner> FormSigners { get; set; }
        public virtual DbSet<FormTemplate> FormTemplates { get; set; }
        public virtual DbSet<FormToSigner> FormToSigners { get; set; }
        public virtual DbSet<FormUser> FormUsers { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Sign> Signs { get; set; }
        public virtual DbSet<Signer> Signers { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=Sign;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<FormSigner>(entity =>
            {
                entity.ToTable("form_signer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassId)
                    .HasColumnName("class_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.FormTosignerId).HasColumnName("formTosigner_id");

                entity.Property(e => e.Known).HasColumnName("known?");

                entity.Property(e => e.SavedAtFile)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("saved_at_file");

                entity.Property(e => e.SignedFrom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("signed_from");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.FormSigners)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("class_id_fk");

                entity.HasOne(d => d.FormTosigner)
                    .WithMany(p => p.FormSigners)
                    .HasForeignKey(d => d.FormTosignerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fts_fk");
            });

            modelBuilder.Entity<FormTemplate>(entity =>
            {
                entity.ToTable("form_template");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.FormUserId).HasColumnName("form_user_id");
            });

            modelBuilder.Entity<FormToSigner>(entity =>
            {
                entity.ToTable("formToSigner");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Class)
                    .HasColumnName("class")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FormId).HasColumnName("form_id");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.SignerId).HasColumnName("Signer_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FormToSigners)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FTSform");

                entity.HasOne(d => d.Signer)
                    .WithMany(p => p.FormToSigners)
                    .HasForeignKey(d => d.SignerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FTSSIGNER");
            });

            modelBuilder.Entity<FormUser>(entity =>
            {
                entity.ToTable("form_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FormName)
                    .HasMaxLength(50)
                    .HasColumnName("form_name");

                entity.Property(e => e.FormTemplateId).HasColumnName("form_template_id");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("path");

                entity.Property(e => e.Resign).HasColumnName("resign");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.FormTemplate)
                    .WithMany(p => p.FormUsers)
                    .HasForeignKey(d => d.FormTemplateId)
                    .HasConstraintName("ftfu_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FormUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Userfu_fk");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FName)
                    .HasMaxLength(20)
                    .HasColumnName("f_name");

                entity.Property(e => e.IdentityNumber)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("identity_number");

                entity.Property(e => e.LName)
                    .HasMaxLength(20)
                    .HasColumnName("l_name");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("mail");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Sign>(entity =>
            {
                entity.ToTable("Sign");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Class)
                    .HasColumnName("class")
                    .HasDefaultValueSql("(N'A')");

                entity.Property(e => e.FormId).HasColumnName("form_id");

                entity.Property(e => e.PageNum)
                    .HasColumnName("pageNum")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.X1).HasColumnName("x1");

                entity.Property(e => e.X2).HasColumnName("x2");

                entity.Property(e => e.Y1).HasColumnName("y1");

                entity.Property(e => e.Y2).HasColumnName("y2");

                entity.HasOne(d => d.ClassNavigation)
                    .WithMany(p => p.Signs)
                    .HasForeignKey(d => d.Class)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SIGN_class");
            });

            modelBuilder.Entity<Signer>(entity =>
            {
                entity.ToTable("Signer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Signers)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("personSigner_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Signers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usersigner_fk");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.HasIndex(e => e.Status1, "UQ__status__A858923C934CDF7F")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Status1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("person_user_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
