using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MC_SDK.Struct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_guild_channel_info
    {
        public long channel_id;// 长整数型
        [MarshalAs(UnmanagedType.LPStr)]
        public string channel_name;//, 文本型
        public int channel_type;// 整数型, , , 1文字频道，5直播，6应用，7帖子
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_guild_channel_info_E
    {
        public Struct_guild_channel_info info;
    } 
}
