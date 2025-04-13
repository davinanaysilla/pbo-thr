using System;

namespace SistemKaryawan
{
    class Karyawan 
    {
        private string nama;
        private string id;
        private double gajiPokok;

        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public double GajiPokok
        {
            get { return gajiPokok; }
            set { gajiPokok = value; }
        }

        public virtual double HitungGaji()
        {
            return gajiPokok;
        }
    }

    class KaryawanTetap : Karyawan
    {
        public override double HitungGaji()
        {
            return GajiPokok + 500000;
        }
    }

    class KaryawanKontrak : Karyawan
    {
        public override double HitungGaji()
        {
            return GajiPokok - 200000;
        }
    }

    class KaryawanMagang : Karyawan
    {
        public override double HitungGaji()
        {
            return GajiPokok;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistem Manajemen Karyawan ===");

            string nama = InputNama();
            string id = InputID();
            double gaji = InputGaji("Masukkan Gaji Pokok: ");
            Karyawan karyawan;

            while (true)
            {
                Console.Write("Masukkan Jenis Karyawan (Tetap/Kontrak/Magang): ");
                string jenis = Console.ReadLine().ToLower();

                if (jenis == "tetap")
                {
                    karyawan = new KaryawanTetap();
                    break;
                }
                else if (jenis == "kontrak")
                {
                    karyawan = new KaryawanKontrak();
                    break;
                }
                else if (jenis == "magang")
                {
                    karyawan = new KaryawanMagang();
                    break;
                }
                else
                {
                    Console.WriteLine("Jenis karyawan tidak valid. Silakan masukkan: Tetap / Kontrak / Magang.");
                }
            }

            karyawan.Nama = nama;
            karyawan.ID = id;
            karyawan.GajiPokok = gaji;

            Console.WriteLine("\n--- Data Karyawan ---");
            Console.WriteLine("Nama       : " + karyawan.Nama);
            Console.WriteLine("ID         : " + karyawan.ID);
            Console.WriteLine("Gaji Akhir : Rp " + karyawan.HitungGaji().ToString("N0"));
        }

        static string InputNama()
        {
            while (true)
            {
                Console.Write("Masukkan Nama (huruf saja): ");
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && HanyaHuruf(input))
                {
                    return input;
                }
                Console.WriteLine("Nama hanya boleh berisi huruf dan spasi.");
            }
        }

        static string InputID()
        {
            while (true)
            {
                Console.Write("Masukkan ID (angka saja): ");
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && HanyaAngka(input))
                {
                    return input;
                }
                Console.WriteLine("ID hanya boleh terdiri dari angka.");
            }
        }

        static double InputGaji(string pesan)
        {
            while (true)
            {
                Console.Write(pesan);
                string input = Console.ReadLine();
                double gaji;

                if (double.TryParse(input, out gaji) && gaji >= 0)
                {
                    return gaji;
                }
                Console.WriteLine("Gaji harus berupa angka positif.");
            }
        }

        static bool HanyaHuruf(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLetter(input[i]) && input[i] != ' ')
                    return false;
            }
            return true;
        }

        static bool HanyaAngka(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                    return false;
            }
            return true;
        }
    }
}
