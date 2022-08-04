using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MC_SDK.Struct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_Guild_Live_Info
    {
        public int count;// 累计观看 整数型
        public int timespand;// 时长 整数型
        public int likes;// 点赞; 整数型
        public int people_num;// 实时人数 整数型
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_Guild_Live_Info_E
    {
        public Struct_Guild_Live_Info struct_Guild_Live_Info;
    }
}
