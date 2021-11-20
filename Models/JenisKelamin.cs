using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_015_A.Models
{
    public partial class JenisKelamin
    {
        public JenisKelamin()
        {
            Gurus = new HashSet<Guru>();
            Siswas = new HashSet<Siswa>();
        }

        public int IdJeniskelamin { get; set; }
        public string NamaJeniskelamin { get; set; }

        public virtual ICollection<Guru> Gurus { get; set; }
        public virtual ICollection<Siswa> Siswas { get; set; }
    }
}
