using System.Runtime.InteropServices;

namespace MC_SDK.Struct
{
    /// <summary>
    /// 推送群消息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_Group_Msg
    {
        public long fromUin; //长整数型
        public long myUin; //长整数型
        public long fromReq; //长整数型
        public long fromRecvTime; //长整数型; //; //; //接收时间
        public long fromGroup; //长整数型
        public string groupName; //文本型
        public string fromCard; //文本型
        public long fromSendTime; //长整数型
        public long fromRandom; //长整数型
        public int pieceIndex; //整数型
        public int pieceCount; //整数型
        public long pieceFlag; //长整数型
        public int subType; //整数型
        public int authority; //整数型
        public string title; //文本型
        public string message_content; //文本型
        public string reply_info; //文本型; //; //; //如果是回复消息,这个变量保存回复的消息的信息
        public int buddleId; //整数型
        public int lon; //整数型
        public int lat; //整数型
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_Group_Msg_PA
    {
        public Struct_Group_Msg sgmsg;
    }
}
