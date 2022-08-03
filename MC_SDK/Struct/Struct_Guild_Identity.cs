using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MC_SDK.Struct
{
    /// <summary>
    /// 频道身份
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public struct Struct_Guild_Identity
    {
        public long id; //长整数型, , , 身份id
        [MarshalAs(UnmanagedType.LPStr)]
        public string name; //文本型, , , 身份名
        public long color;// 长整数型, , , 颜色
    }
}
