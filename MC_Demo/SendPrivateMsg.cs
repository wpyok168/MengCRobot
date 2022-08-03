using MC_SDK;
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
    public class SendPrivateMsg : IPrivateMsg
    {
        public int PrivateMsgComply(PrivateMsg e)
        {
            //Common.MC_API.GetChannelMemberQQinfo_(6664221659415426);
            //Common.MC_API.GetPskey_();
            Common.MC_API.TXT2Audio_("你好");
            Common.MC_API.SendPrivateMsg_(e.FromQQ, "鹦鹉学舌：" + e.Msg);
            return (int)EventProcessEnum.消息处理_忽略;
        }
    }
}
