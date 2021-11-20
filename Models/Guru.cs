#nullable disable

namespace UCP1_PAW_015_A.Models
{
    public partial class Guru
    {
        public int IdGuru { get; set; }
        public string NamaGuru { get; set; }
        public int? IdJeniskelamin { get; set; }
        public int? IdMatapelajaran { get; set; }

        public virtual JenisKelamin IdJeniskelaminNavigation { get; set; }
        public virtual MataPelajaran IdMatapelajaranNavigation { get; set; }
    }
}
