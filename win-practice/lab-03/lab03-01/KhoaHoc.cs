using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03_01
{
    public class KhoaHoc
    {
        public string MaKhoaHoc { get; set; }

        public string TenKhoaHoc { get; set; }

        public int SoTinChi { get; set; }

        public override string ToString()
        {
            return $"{MaKhoaHoc} - {TenKhoaHoc} - {SoTinChi} tín chỉ";
        }
    }
}
