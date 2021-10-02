using System;
using System.Runtime.InteropServices;

namespace MC_SDK.Struct
{
    /// <summary>
    /// 推送私聊消息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_Friend_Msg
    {
        public int outtype; //整数型; //; //; //输出到日志列表的类型
        public long fromUin; //长整数型
        public string fromUinName; //文本型
        public long myUin; //长整数型
        public long fromReq; //长整数型
        public long fromSeq; //长整数型
        public long fromRecvTime; //长整数型; //; //; //接收时间
        public long fromGroup; //长整数型
        public long fromSendTime; //长整数型
        public long fromRandom; //长整数型
        public int pieceIndex; //整数型
        public int pieceCount; //整数型
        public long pieceFlag; //长整数型
        public string message_content; //文本型
        public int buddleId; //整数型
        public int msgType; //整数型
        public int subMsgType; //整数型
        public int subTempMsgType; //整数型; //; //; //0 群 1 讨论组 129 腾讯公众号 201 QQ咨询
        public int red_packet_type; //整数型; //; //; //红包类型:  2已转入余额 4点击收款 10红包
        public IntPtr chatToken; //字节集; //; //; //会话Token
        public long fromEventUin; //长整数型
        public string fromEventNick; //文本型
        public string fileId; //文本型
        public IntPtr fileMd5; //字节集
        public string fileName; //文本型
        public long fileSize; //长整数型
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_Friend_Msg_PA
    {
        public Struct_Friend_Msg sfgp;
    }
}
