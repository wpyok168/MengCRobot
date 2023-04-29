using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MC_SDK.Struct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Struct_guild_private_info
    {
        public long guildid;//长整数型
        public long channelid;//长整数型
        public long timestamp;//长整数型
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Struct_guild_private_info_E
    {
        public Struct_guild_private_info sgpi_E;
    }
}
