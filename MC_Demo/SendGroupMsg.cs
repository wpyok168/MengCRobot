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
            if (e.FromQQ == 1000032 || Common.MC_API.GetRobotQQ() == e.FromQQ.ToString()) //不处理匿名信息和自己
            {
                return (int)EventProcessEnum.消息处理_忽略;
            }
            //if (e.FromCard.Contains("匿名信息") || e.FromQQ == 80000000) //80000000
            //{
            //    return (int)EventProcessEnum.消息处理_忽略;
            //}


            if (e.Msg.Contains("pic") && e.Msg.Contains("hash") && e.Msg.Contains("url"))
            {
                string[] pics = e.Msg.Split(',');
                string hash = string.Empty;
                string url = string.Empty;
                foreach (string p in pics)
                {
                    if (p.Contains("hash"))
                    {
                        hash = p.Replace("hash=", "");
                    }
                    if (p.Contains("url"))
                    {
                        url = p.Replace("url=", "");
                    }
                }
                if (!string.IsNullOrEmpty(hash) && !string.IsNullOrEmpty(url))
                {
                    string 图片内容 = Common.MC_API.Extract_Image_text(url, hash);
                    Common.MC_API.SendGroupMsg_(e.FromGroup, "图片内容：" + 图片内容);
                }
            }

            Common.MC_API.GetGroupInfo_JL_(e.FromGroup);
            Common.MC_API.SendGroupMsg_(e.FromGroup, "鹦鹉学舌：" + e.Msg, e.FromQQ);
            string imageurl = Common.MC_API.UploadGroupImage(e.FromGroup, Common.MC_API.Get_PluginDataDirectory()+ "MS.png");
            Common.MC_API.SendGroupMsg_(e.FromGroup, "群图片地址：" + imageurl, e.FromQQ);

            return (int)EventProcessEnum.消息处理_忽略;
        }
    }
}
