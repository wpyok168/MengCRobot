using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MC_SDK.Struct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_EArray
    {
        public int index;
        public int count;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024*10)]
        public IntPtr[] ptrs;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_EArray_byte
    {
        public int index;
        public int count;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024*10)]
        public byte[] bytes;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_EArray_long
    {
        public int index;//数组索引
        public int count;//数组元素数量
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024*10)]
        public long[] ldata;
    }
}
