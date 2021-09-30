using MC_SDK.Enum;

namespace MC_SDK.Mode
{
    /// <summary>
    /// 好友消息
    /// </summary>
    public class PrivateMsg
    {
        private long qQID;
        private long fromQQ;
        private long fromGroup;
        private long fromRecvTime;
        private long fromSeq;
        private MsgTypeEnum msgtype;
        private int subMsgType;
        private SubTempMsgTypeEnum subTempMsgType;
        private int fromReq;
        private string fromCard;
        private string chattoken;
        private string msg;

        /// <summary>
        /// 机器人QQ
        /// </summary>
        public long QQID { get => qQID; set => qQID = value; }
        /// <summary>
        /// 来源QQ
        /// </summary>
        public long FromQQ { get => fromQQ; set => fromQQ = value; }
        /// <summary>
        /// 为群临时消息的时候，会有值
        /// </summary>
        public long FromGroup { get => fromGroup; set => fromGroup = value; }
        /// <summary>
        /// 接收时间，一般用于回复消息
        /// </summary>
        public long FromRecvTime { get => fromRecvTime; set => fromRecvTime = value; }
        /// <summary>
        /// 接收seq，一般用于回复消息
        /// </summary>
        public long FromSeq { get => fromSeq; set => fromSeq = value; }
        /// <summary>
        /// 141 为临时消息 166为普通私聊消息 208语音消息(手表协议)
        /// </summary>
        public MsgTypeEnum Msgtype { get => msgtype; set => msgtype = value; }
        /// <summary>
        /// 忘了是啥了
        /// </summary>
        public int SubMsgType { get => subMsgType; set => subMsgType = value; }
        /// <summary>
        /// 0 群 1 讨论组 129 腾讯公众号 201 QQ咨询
        /// </summary>
        public SubTempMsgTypeEnum SubTempMsgType { get => subTempMsgType; set => subTempMsgType = value; }
        /// <summary>
        /// 消息的唯一表示，一般用来回复消息
        /// </summary>
        public int FromReq { get => fromReq; set => fromReq = value; }
        /// <summary>
        /// 发送QQ的昵称
        /// </summary>
        public string FromCard { get => fromCard; set => fromCard = value; }
        /// <summary>
        /// 一般用不到
        /// </summary>
        public string Chattoken { get => chattoken; set => chattoken = value; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Msg { get => msg; set => msg = value; }
    }
}
