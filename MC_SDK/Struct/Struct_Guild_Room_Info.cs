using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MC_SDK.Struct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_Guild_Room_Info_E
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string fromCard;// 文本型
        public long tinyid;// 长整数型
        public long roomid;// 长整数型
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;// 文本型
        public IntPtr qq_list;// 长整数型, 数组  "1"
        [MarshalAs(UnmanagedType.LPStr)]
        public string rtmp;// 文本型
        [MarshalAs(UnmanagedType.LPStr)]
        public string unkown1;// 文本型
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_Guild_Room_Info
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string fromCard;// 文本型
        public long tinyid;// 长整数型
        public long roomid;// 长整数型
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;// 文本型
        public long[] qq_list;// 长整数型, 数组  "1"
        [MarshalAs(UnmanagedType.LPStr)]
        public string rtmp;// 文本型
        [MarshalAs(UnmanagedType.LPStr)]
        public string unkown1;// 文本型
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_Guild_Room_Info_EPD
    {
        public Struct_Guild_Room_Info_E struct_Guild_Room_Info_E;
    }
}
