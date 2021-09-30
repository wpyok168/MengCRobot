using MC_SDK.Enum;

namespace MC_SDK.Mode
{
    /// <summary>
    /// 事件
    /// </summary>
    public class EventMsg
    {
        private long qQID; //长整数型
        private EventTypeEnum type; //整数型; //; //1xx为好友，2xx为群聊
        private int subtype; //整数型; //; //相当于子类型
        private long fromUin; //长整数型
        private string fromUinNick; //文本型
        private int fromReq; //整数型
        private int fromRecvTime; //整数型; //; //接收时间
        private long fromGroup; //长整数型
        private string fromGroupName; //文本型
        private string fromCard; //文本型
        private int fromSendTime; //整数型
        private long fromRandom; //长整数型
        private long fromSeq; //长整数型; //; //处理入群用
        private long fromEventUin; //长整数型
        private string fromEventNick; //文本型
        private string message_content; //文本型

        public long QQID { get => qQID; set => qQID = value; }
        /// <summary>
        /// 事件类型 ：1xx为好友，2xx为群聊
        /// </summary>
        public EventTypeEnum Type { get => type; set => type = value; }
        /// <summary>
        /// 相当于子类型
        /// </summary>
        public int Subtype { get => subtype; set => subtype = value; }
        public long FromUin { get => fromUin; set => fromUin = value; }
        public string FromUinNick { get => fromUinNick; set => fromUinNick = value; }
        /// <summary>
        /// 
        /// </summary>
        public int FromReq { get => fromReq; set => fromReq = value; }
        /// <summary>
        /// 接收时间
        /// </summary>
        public int FromRecvTime { get => fromRecvTime; set => fromRecvTime = value; }
        public long FromGroup { get => fromGroup; set => fromGroup = value; }
        public string FromGroupName { get => fromGroupName; set => fromGroupName = value; }
        public string FromCard { get => fromCard; set => fromCard = value; }
        public int FromSendTime { get => fromSendTime; set => fromSendTime = value; }
        public long FromRandom { get => fromRandom; set => fromRandom = value; }
        /// <summary>
        /// 处理入群用
        /// </summary>
        public long FromSeq { get => fromSeq; set => fromSeq = value; }
        public long FromEventUin { get => fromEventUin; set => fromEventUin = value; }
        public string FromEventNick { get => fromEventNick; set => fromEventNick = value; }
        public string Message_content { get => message_content; set => message_content = value; }
    }
}
