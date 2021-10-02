using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MC_SDK.Struct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_Other_Msg
    {
        public int type; //整数型; //; //; //1为好友，2为群聊
        public int subtype; //整数型; //; //; //相当于子类型
        public long fromUin; //长整数型
        public string fromUinNick; //文本型
        public long myUin; //长整数型
        public long fromReq; //长整数型
        public long fromRecvTime; //长整数型; //; //; //接收时间
        public long fromGroup; //长整数型
        public string groupName; //文本型
        public string fromCard; //文本型
        public long fromSendTime; //长整数型
        public long fromRandom; //长整数型
        public long fromSeq; //长整数型; //; //; //处理入群用
        public long fromEventUin; //长整数型
        public string fromEventNick; //文本型
        public string message_content; //文本型
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_Other_Msg_PA
    {
        public Struct_Other_Msg sogp;
    }
}
