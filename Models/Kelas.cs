using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_015_A.Models
{
    public partial class Kelas
    {
        public Kelas()
        {
            Siswas = new HashSet<Siswa>();
        }

        public int IdKelas { get; set; }
        public string NamaKelas { get; set; }

        public virtual ICollection<Siswa> Siswas { get; set; }
    }
}
