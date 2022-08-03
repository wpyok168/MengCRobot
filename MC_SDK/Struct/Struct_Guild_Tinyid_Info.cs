using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MC_SDK.Struct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_Guild_Tinyid_Info
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;//文本型
        [MarshalAs(UnmanagedType.LPStr)]
        public string url;//文本型, , , 头像网址
        [MarshalAs(UnmanagedType.LPStr)]
        public string birthday;//, 文本型, , , xxxx/xx/x
        public int sex;//, 整数型, , , 1男2女
        public int age;//, 整数型, , , 年龄
        public long jointimestamp;//, 长整数型, , , 加入频道的时间戳
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_Guild_Tinyid_Info_E
    {
        public Struct_Guild_Tinyid_Info struct_Guild_Tinyid_Info;
    }
}
