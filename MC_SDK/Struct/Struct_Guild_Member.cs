using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MC_SDK.Struct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_Guild_Member
    {
        public long guild_id;//长整数型
        public int num;//整数型
        public int maxnum; //整数型
        public IntPtr identityArr; //struct_guild_member_identity, , "1"
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_Guild_Member_E
    {
        public Struct_Guild_Member struct_Guild_Member;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_guild_member_identity
    {
        public long id; //长整数型, , , 身份id
        [MarshalAs(UnmanagedType.LPStr)]
        public string identity_name; //文本型, , , 身份名
        public long color; //长整数型
        public IntPtr memberArr;// struct_guild_member_info, , "1"
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_guild_member_info
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string name; //文本型, , , , 昵称
        [MarshalAs(UnmanagedType.LPStr)]
        public string guildname; //文本型...频道里的昵称
        public long tinyid; //长整数型
        /// <summary>
        /// 1管理，2创建者，0普通
        /// </summary>
        public long auth; //长整数型, , , 是否为创建者/管理，1管理，2创建者，0普通
        public long join_timestamp; //长整数型//////进入本频道的时间
        public long identity_timestamp;  //长整数型//////被设置身份的时间
    }

    //
    public struct Struct_Guild_Member_C
    {
        public long guild_id;//长整数型
        public int num;//整数型
        public int maxnum; //整数型
        public List<Struct_guild_member_identity_C> identityArr; //struct_guild_member_identity, , "1"
    }
    public struct Struct_guild_member_identity_C
    {
        public long id; //长整数型, , , 身份id
        [MarshalAs(UnmanagedType.LPStr)]
        public string identity_name; //文本型, , , 身份名
        public long color; //长整数型
        public List<Struct_guild_member_info> memberArr;// struct_guild_member_info, , "1"
    }
}
