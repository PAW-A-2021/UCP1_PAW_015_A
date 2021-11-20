using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UCP1_PAW_015_A.Models
{
    public partial class DB_RaportkuContext : DbContext
    {
        public DB_RaportkuContext()
        {
        }

        public DB_RaportkuContext(DbContextOptions<DB_RaportkuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Guru> Guru { get; set; }
        public virtual DbSet<JenisKelamin> JenisKelamin { get; set; }
        public virtual DbSet<Kelas> Kelas { get; set; }
        public virtual DbSet<MataPelajaran> MataPelajaran { get; set; }
        public virtual DbSet<Nilai> Nilai { get; set; }
        public virtual DbSet<Siswa> Siswa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Guru>(entity =>
            {
                entity.HasKey(e => e.IdGuru);

                entity.ToTable("Guru");

                entity.Property(e => e.IdGuru)
                    .ValueGeneratedNever()
                    .HasColumnName("id_guru");

                entity.Property(e => e.IdJeniskelamin).HasColumnName("id_jeniskelamin");

                entity.Property(e => e.IdMatapelajaran).HasColumnName("id_matapelajaran");

                entity.Property(e => e.NamaGuru)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama_guru");

                entity.HasOne(d => d.IdJeniskelaminNavigation)
                    .WithMany(p => p.Gurus)
                    .HasForeignKey(d => d.IdJeniskelamin)
                    .HasConstraintName("FK_Guru_Jenis_Kelamin");

                entity.HasOne(d => d.IdMatapelajaranNavigation)
                    .WithMany(p => p.Gurus)
                    .HasForeignKey(d => d.IdMatapelajaran)
                    .HasConstraintName("FK_Guru_Mata_Pelajaran");
            });

            modelBuilder.Entity<JenisKelamin>(entity =>
            {
                entity.HasKey(e => e.IdJeniskelamin);

                entity.ToTable("Jenis_Kelamin");

                entity.Property(e => e.IdJeniskelamin)
                    .ValueGeneratedNever()
                    .HasColumnName("id_jeniskelamin");

                entity.Property(e => e.NamaJeniskelamin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("nama_jeniskelamin");
            });

            modelBuilder.Entity<Kelas>(entity =>
            {
                entity.HasKey(e => e.IdKelas);

                entity.Property(e => e.IdKelas)
                    .ValueGeneratedNever()
                    .HasColumnName("id_kelas");

                entity.Property(e => e.NamaKelas)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("nama_kelas");
            });

            modelBuilder.Entity<MataPelajaran>(entity =>
            {
                entity.HasKey(e => e.IdMatapelajaran);

                entity.ToTable("Mata_Pelajaran");

                entity.Property(e => e.IdMatapelajaran)
                    .ValueGeneratedNever()
                    .HasColumnName("id_matapelajaran");

                entity.Property(e => e.NamaMatapelajaran)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama_matapelajaran");
            });

            modelBuilder.Entity<Nilai>(entity =>
            {
                entity.HasKey(e => e.IdNilai);

                entity.ToTable("Nilai");

                entity.Property(e => e.IdNilai)
                    .ValueGeneratedNever()
                    .HasColumnName("id_nilai");

                entity.Property(e => e.IdSiswa).HasColumnName("id_siswa");

                entity.Property(e => e.JumlahNilai).HasColumnName("jumlah_nilai");

                entity.HasOne(d => d.IdSiswaNavigation)
                    .WithMany(p => p.Nilais)
                    .HasForeignKey(d => d.IdSiswa)
                    .HasConstraintName("FK_Nilai_Siswa");
            });

            modelBuilder.Entity<Siswa>(entity =>
            {
                entity.HasKey(e => e.IdSiswa);

                entity.ToTable("Siswa");

                entity.Property(e => e.IdSiswa)
                    .ValueGeneratedNever()
                    .HasColumnName("id_siswa");

                entity.Property(e => e.IdJeniskelamin).HasColumnName("id_jeniskelamin");

                entity.Property(e => e.IdKelas).HasColumnName("id_kelas");

                entity.Property(e => e.NamaSiswa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama_siswa");

                entity.HasOne(d => d.IdJeniskelaminNavigation)
                    .WithMany(p => p.Siswas)
                    .HasForeignKey(d => d.IdJeniskelamin)
                    .HasConstraintName("FK_Siswa_Jenis_Kelamin");

                entity.HasOne(d => d.IdKelasNavigation)
                    .WithMany(p => p.Siswas)
                    .HasForeignKey(d => d.IdKelas)
                    .HasConstraintName("FK_Siswa_Kelas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
