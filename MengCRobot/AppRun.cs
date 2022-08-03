using MC_SDK;
using MC_SDK.Croe;
using MC_SDK.Enum;
using MC_SDK.Interface;
using MC_SDK.Mode;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Unity;

namespace MengCRobot
{

    public static class AppRun
    {
        /// <summary>
        /// 导入插件
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pDesc"></param>
        /// <param name="apidata"></param>
        [DllExport(CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static void Init(int pName, int pDesc, [MarshalAs(UnmanagedType.LPStr)]string apidata)
        {
            Common.unityContainer = new UnityContainer();
            RegisterCore.Register(Common.unityContainer);
            string path = System.Environment.CurrentDirectory + "\\插件数据\\" + AppInfo.app_name;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            API.app_PluginDataDirectory = path + "\\";
            byte[] bn = Encoding.GetEncoding("gb2312").GetBytes(AppInfo.app_name);
            byte[] bd = Encoding.GetEncoding("gb2312").GetBytes(AppInfo.app_desc);
            Marshal.Copy(bn, 0, new IntPtr(pName), bn.Length);
            Marshal.Copy(bd, 0, new IntPtr(pDesc), bd.Length);
            string a = Marshal.PtrToStringAnsi(new IntPtr(pName));
            API.apidata = apidata;
        }
        /// <summary>
        /// 卸载\退出框架
        /// </summary>
        [DllExport(CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static void Uninit()
        {
            try
            {
                if (Common.unityContainer.IsRegistered<IUninit>())
                {
                    Common.unityContainer.Resolve<IUninit>().UninitComply();
                }
            }
            catch (Exception ex)
            {
                Common.BugLog(ex.Message);
            }
        }
        /// <summary>
        /// 右键单击设置
        /// </summary>
        [DllExport(CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static void Setting()
        {
            try
            {
                if (Common.unityContainer.IsRegistered<ISetting>())
                {
                    Common.unityContainer.Resolve<ISetting>().SettingComply();
                }
            }
            catch (Exception ex)
            {
                Common.BugLog(ex.Message);
            }
        }
        /// <summary>
        /// 启用插件
        /// </summary>
        [DllExport(CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static void Enable()
        {
            try
            {
                if (Common.unityContainer.IsRegistered<IEnable>())
                {
                    Common.unityContainer.Resolve<IEnable>().EnableComply();
                }
            }
            catch (Exception ex)
            {
                Common.BugLog(ex.Message);
            }
        }
        /// <summary>
        /// 禁用插件
        /// </summary>
        [DllExport(CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static void Disable()
        {
            try
            {
                if (Common.unityContainer.IsRegistered<IDisable>())
                {
                    Common.unityContainer.Resolve<IDisable>().DisableComply();
                }
            }
            catch (Exception ex)
            {
                Common.BugLog(ex.Message);
            }
        }
        /// <summary>
        /// 好友私聊消息
        /// </summary>
        /// <param name="QQID">机器人QQ</param>
        /// <param name="fromQQ">来源QQ</param>
        /// <param name="fromGroup">为群临时消息的时候，会有值</param>
        /// <param name="fromRecvTime">接收时间，一般用于回复消息</param>
        /// <param name="fromSeq">接收seq，一般用于回复消息</param>
        /// <param name="msgtype">141 为临时消息 166为普通私聊消息 208语音消息(手表协议)</param>
        /// <param name="subMsgType">忘了是啥了</param>
        /// <param name="subTempMsgType">0 群 1 讨论组 129 腾讯公众号 201 QQ咨询</param>
        /// <param name="fromReq">消息的唯一表示，一般用来回复消息</param>
        /// <param name="fromCard">发送QQ的昵称</param>
        /// <param name="chattoken">一般用不到</param>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        [DllExport(CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static int onFriendMsg(long QQID, long fromQQ, long fromGroup, long fromRecvTime, long fromSeq, MsgTypeEnum msgtype, int subMsgType, SubTempMsgTypeEnum subTempMsgType, int fromReq, [MarshalAs(UnmanagedType.LPStr)] string fromCard, [MarshalAs(UnmanagedType.LPStr)] string chattoken, [MarshalAs(UnmanagedType.LPStr)] string msg)
        {
            try
            {
                if (Common.unityContainer.IsRegistered<IPrivateMsg>())
                {
                    PrivateMsg e = new PrivateMsg()
                    {
                        QQID = QQID,
                        FromQQ = fromQQ,
                        FromGroup = fromGroup,
                        FromRecvTime = fromRecvTime,
                        FromSeq = fromSeq,
                        Msgtype = msgtype,
                        SubMsgType = subMsgType,
                        SubTempMsgType = subTempMsgType,
                        FromReq = fromReq,
                        FromCard = fromCard,
                        Chattoken = chattoken,
                        Msg = msg
                    };
                    return Common.unityContainer.Resolve<IPrivateMsg>().PrivateMsgComply(e);
                }
            }
            catch (Exception ex)
            {
                Common.BugLog(ex.Message);
            }
            return (int)EventProcessEnum.消息处理_忽略;
        }
        /// <summary>
        /// 群聊消息
        /// </summary>
        /// <param name="QQID">机器人QQ</param>
        /// <param name="fromGroup">来源群号</param>
        /// <param name="fromQQ">发送者QQ</param>
        /// <param name="fromRandom">用来回复和撤回消息</param>
        /// <param name="fromRecvtime">消息接收时间</param>
        /// <param name="fromReq">requestid，一般用来回复消息或撤回消息</param>
        /// <param name="authority">发送者的群地位，0普通群员，8群主，16管理员</param>
        /// <param name="fromCard">发送者昵称</param>
        /// <param name="fromTitle">发送者头衔</param>
        /// <param name="fromGroupName">群名</param>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        [DllExport(CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static int onGroupMsg(long QQID, long fromGroup, long fromQQ, long fromRandom, long fromRecvtime, int fromReq, AuthorityEnum authority, [MarshalAs(UnmanagedType.LPStr)] string fromCard, [MarshalAs(UnmanagedType.LPStr)] string fromTitle, [MarshalAs(UnmanagedType.LPStr)] string fromGroupName, [MarshalAs(UnmanagedType.LPStr)] string msg)
        {
            try
            {
                if (Common.unityContainer.IsRegistered<IGroupMsg>())
                {
                    GroupMsg e = new GroupMsg()
                    {
                        QQID = QQID,
                        FromGroup = fromGroup,
                        FromQQ = fromQQ,
                        FromRandom = fromRandom,
                        FromRecvtime = fromRecvtime,
                        FromReq = fromReq,
                        Authority = authority,
                        FromCard = fromCard,
                        FromTitle = fromTitle,
                        FromGroupName = fromGroupName,
                        Msg = msg
                    };
                    return Common.unityContainer.Resolve<IGroupMsg>().GroupMsgComply(e);
                }
            }
            catch (Exception ex)
            {
                Common.BugLog(ex.Message);
            }

            return (int)EventProcessEnum.消息处理_忽略;
        }
        /// <summary>
        /// 各种事件消息
        /// </summary>
        /// <param name="QQID"></param>
        /// <param name="type">1xx为好友，2xx为群聊</param>
        /// <param name="subtype">相当于子类型</param>
        /// <param name="fromUin"></param>
        /// <param name="fromUinNick"></param>
        /// <param name="fromReq"></param>
        /// <param name="fromRecvTime">接收时间</param>
        /// <param name="fromGroup"></param>
        /// <param name="fromGroupName"></param>
        /// <param name="fromCard"></param>
        /// <param name="fromSendTime"></param>
        /// <param name="fromRandom"></param>
        /// <param name="fromSeq">处理入群用</param>
        /// <param name="fromEventUin"></param>
        /// <param name="fromEventNick"></param>
        /// <param name="message_content"></param>
        /// <returns></returns>
        [DllExport(CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static int onEventMsg(long QQID, EventTypeEnum type, int subtype, long fromUin, [MarshalAs(UnmanagedType.LPStr)] string fromUinNick, int fromReq, int fromRecvTime, long fromGroup, [MarshalAs(UnmanagedType.LPStr)] string fromGroupName, [MarshalAs(UnmanagedType.LPStr)] string fromCard, int fromSendTime, long fromRandom, long fromSeq, long fromEventUin, [MarshalAs(UnmanagedType.LPStr)] string fromEventNick, [MarshalAs(UnmanagedType.LPStr)] string message_content)
        {
            try
            {
                if (Common.unityContainer.IsRegistered<IEventMsg>())
                {
                    EventMsg e = new EventMsg()
                    {
                        QQID = QQID,
                        Type = type,
                        Subtype = subtype,
                        FromUin = fromUin,
                        FromUinNick = fromUinNick,
                        FromReq = fromReq,
                        FromRecvTime = fromRecvTime,
                        FromGroup = fromGroup,
                        FromGroupName = fromGroupName,
                        FromCard = fromCard,
                        FromSendTime = fromSendTime,
                        FromRandom = fromRandom,
                        FromSeq = fromSeq,
                        FromEventUin = fromEventUin,
                        FromEventNick = fromEventNick,
                        Message_content = message_content
                    };
                    return Common.unityContainer.Resolve<IEventMsg>().EventMsgComply(e);
                }
            }
            catch (Exception ex)
            {
                Common.BugLog(ex.Message);
            }
            return (int)EventProcessEnum.消息处理_忽略;
        }
        [DllExport(CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static int onGuildMsg(long QQID, int type, int subtype, long fromUin, long fromGuild, long fromChannel, long fromRecvTime, long fromReq, [MarshalAs(UnmanagedType.LPStr)] string guildName, [MarshalAs(UnmanagedType.LPStr)] string channelName, [MarshalAs(UnmanagedType.LPStr)] string groupName, [MarshalAs(UnmanagedType.LPStr)] string fromCard, [MarshalAs(UnmanagedType.LPStr)] string message_conten)
        {
            try
            {
                if (Common.unityContainer.IsRegistered<IGuildMsg>())
                {
                    GuildMsg e = new GuildMsg()
                    {
                        QQID = QQID, 
                        Type= type,
                        Subtype = subtype,
                        FromUin = fromUin,
                        FromGuild = fromGuild,
                        FromChannel = fromChannel,
                        FromRecvTime = fromRecvTime,
                        FromReq = fromReq,
                        GuildName = guildName,
                        ChannelName = channelName, 
                        GroupName = groupName,
                        FromCard = fromCard,
                        Msg= message_conten
                    };
                    return Common.unityContainer.Resolve<IGuildMsg>().GuildMsgComply(e);
                }
            }
            catch (Exception ex)
            {
                Common.BugLog(ex.Message);
            }
            return (int)EventProcessEnum.消息处理_忽略;
        }
    }
}
