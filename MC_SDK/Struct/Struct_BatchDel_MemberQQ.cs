using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MC_SDK.Struct
{
    /// <summary>
    /// 批量删除群成员列表
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public  struct Struct_BatchDel_MemberQQ
    {
        public long memberQQ;
        public bool isRefuseNext;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_BatchDel_MemberQQ_E
    {
        public Struct_BatchDel_MemberQQ sbdme;
    }
}
