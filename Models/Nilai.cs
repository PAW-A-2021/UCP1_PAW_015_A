#nullable disable

namespace UCP1_PAW_015_A.Models
{
    public partial class Nilai
    {
        public int IdNilai { get; set; }
        public int? IdSiswa { get; set; }
        public int? JumlahNilai { get; set; }

        public virtual Siswa IdSiswaNavigation { get; set; }
    }
}
