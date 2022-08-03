using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_SDK.Mode
{
    public class GuildMsg
    {
        private long qQID;// 长整数型
        private int type;//整数型
        private int subtype;//整数型, , 相当于子类型
        private long fromUin;//长整数型, , 不是真正的QQ
        private long fromGuild;//长整数型, , 频道id
        private long fromChannel;//长整数型, , 频道内的子聊天室id
        private long fromRecvTime;//长整数型, , 接收时间
        private long fromReq;//长整数型
        private string guildName;//文本型, , 频道名
        private string channelName;//文本型, , 聊天室名
        private string groupName;//文本型, , 分组名
        private string fromCard;//文本型, , 对方昵称
        private string message_content;//文本型, , 内容
        
        public long QQID { get => qQID; set => qQID = value; }
        public int Type { get => type; set => type = value; }
        public int Subtype { get => subtype; set => subtype = value; }
        /// <summary>
        /// 不是真正的QQ
        /// </summary>
        public long FromUin { get => fromUin; set => fromUin = value; }
        /// <summary>
        /// 频道id
        /// </summary>
        public long FromGuild { get => fromGuild; set => fromGuild = value; }
        /// <summary>
        /// 频道内的子聊天室id
        /// </summary>
        public long FromChannel { get => fromChannel; set => fromChannel = value; }
        /// <summary>
        /// 接收时间
        /// </summary>
        public long FromRecvTime { get => fromRecvTime; set => fromRecvTime = value; }
        public long FromReq { get => fromReq; set => fromReq = value; }
        /// <summary>
        /// 频道名
        /// </summary>
        public string GuildName { get => guildName; set => guildName = value; }
        /// <summary>
        /// 聊天室名
        /// </summary>
        public string ChannelName { get => channelName; set => channelName = value; }
        /// <summary>
        /// 分组名
        /// </summary>
        public string GroupName { get => groupName; set => groupName = value; }
        /// <summary>
        /// 对方昵称
        /// </summary>
        public string FromCard { get => fromCard; set => fromCard = value; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Msg { get => message_content; set => message_content = value; }
    }
}
