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
    public class SendGroupMsg : IGroupMsg
    {
        public int GroupMsgComply(GroupMsg e)
        {
            Common.MC_API.SendGroupMsg_(e.FromGroup, "鹦鹉学舌：" + e.Msg, e.FromQQ);
            string imageurl = Common.MC_API.UploadGroupImage(e.FromGroup, Common.MC_API.Get_PluginDataDirectory()+ "MS.png");
            Common.MC_API.SendGroupMsg_(e.FromGroup, "群图片地址：" + imageurl, e.FromQQ);
            return (int)EventProcessEnum.消息处理_忽略;
        }
    }
}
