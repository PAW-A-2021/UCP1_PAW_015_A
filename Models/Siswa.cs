using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_015_A.Models
{
    public partial class Siswa
    {
        public Siswa()
        {
            Nilais = new HashSet<Nilai>();
        }

        public int IdSiswa { get; set; }
        public string NamaSiswa { get; set; }
        public int? IdJeniskelamin { get; set; }
        public int? IdKelas { get; set; }

        public virtual JenisKelamin IdJeniskelaminNavigation { get; set; }
        public virtual Kelas IdKelasNavigation { get; set; }
        public virtual ICollection<Nilai> Nilais { get; set; }
    }
}
