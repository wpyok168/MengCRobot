using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MC_SDK.Struct
{
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public struct Struct_Pskey
    {
        public string tenpay;
        public string openmobile_qq;
        public string qun_qq;
        public string game_qq;
        public string mail_qq;
        public string qzone;
        public string qzone_qq;
        public string connect_qq;
        public string imgcache_qq;
        public string hall_qq;
        public string ivac_qq;
        public string vip_qq;
        public string gamecenter_qq;
        public string haoma_qq;
        public string yundong_qq;
        public string graph_qq;
        public string qianbao_qq;
        public string docs_qq;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_Pskey_PA
    {
        public Struct_Pskey sp;
    }
}
