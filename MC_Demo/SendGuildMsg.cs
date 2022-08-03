using MC_SDK.Enum;
using MC_SDK.Interface;
using MC_SDK.Mode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_Demo
{
    public class SendGuildMsg : IGuildMsg
    {
        public int GuildMsgComply(GuildMsg e)
        {
            
            //框架没提供频道发言者QQ号，需要注意屏蔽机器人自我发言。
            //MC_SDK.Common.MC_API.SendChannelMsg_(e.FromGuild, e.FromChannel, "频道消息");
            return (int)EventProcessEnum.消息处理_忽略;
        }
    }
}
