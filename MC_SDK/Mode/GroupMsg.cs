using MC_SDK.Enum;

namespace MC_SDK.Mode
{
    /// <summary>
    /// 群消息
    /// </summary>
    public class GroupMsg
    {
        private long qQID; //长整数型; //; //
        private long fromGroup; //长整数型; //; //来源群号
        private long fromQQ; //长整数型; //; //发送者QQ
        private long fromRandom; //长整数型; //; //用来回复和撤回消息
        private long fromRecvtime; //长整数型; //; //消息接收时间
        private int fromReq; //整数型; //; //requestid，一般用来回复消息或撤回消息
        private AuthorityEnum authority; //整数型; //; //发送者的群地位，0普通群员，8群主，16管理员
        private string fromCard; //文本型; //; //发送者昵称
        private string fromTitle; //文本型; //; //发送者头衔
        private string fromGroupName; //文本型; //; //群名
        private string msg; //文本型; //; //消息内容

        /// <summary>
        /// 机器人QQ
        /// </summary>
        public long QQID { get => qQID; set => qQID = value; }
        /// <summary>
        /// 来源群号
        /// </summary>
        public long FromGroup { get => fromGroup; set => fromGroup = value; }
        /// <summary>
        /// 发送者QQ
        /// </summary>
        public long FromQQ { get => fromQQ; set => fromQQ = value; }
        /// <summary>
        /// 用来回复和撤回消息
        /// </summary>
        public long FromRandom { get => fromRandom; set => fromRandom = value; }
        /// <summary>
        /// 消息接收时间
        /// </summary>
        public long FromRecvtime { get => fromRecvtime; set => fromRecvtime = value; }
        /// <summary>
        /// requestid，一般用来回复消息或撤回消息
        /// </summary>
        public int FromReq { get => fromReq; set => fromReq = value; }
        /// <summary>
        /// 发送者的群地位，0普通群员，8群主，16管理员
        /// </summary>
        public AuthorityEnum Authority { get => authority; set => authority = value; }
        /// <summary>
        /// 发送者昵称
        /// </summary>
        public string FromCard { get => fromCard; set => fromCard = value; }
        /// <summary>
        /// 发送者头衔
        /// </summary>
        public string FromTitle { get => fromTitle; set => fromTitle = value; }
        /// <summary>
        /// 群名
        /// </summary>
        public string FromGroupName { get => fromGroupName; set => fromGroupName = value; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Msg { get => msg; set => msg = value; }
    }
}
