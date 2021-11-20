using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_015_A.Models
{
    public partial class MataPelajaran
    {
        public MataPelajaran()
        {
            Gurus = new HashSet<Guru>();
        }

        public int IdMatapelajaran { get; set; }
        public string NamaMatapelajaran { get; set; }

        public virtual ICollection<Guru> Gurus { get; set; }
    }
}
