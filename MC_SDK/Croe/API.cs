using MC_SDK.Enum;
using MC_SDK.Mode;
using MC_SDK.Struct;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MC_SDK.Croe
{
    public class API : TextFormat
    {
        /// <summary>
        /// api函数指针json
        /// </summary>
        public static string apidata = string.Empty;
        /// <summary>
        /// 插件目录
        /// </summary>
        public static string app_PluginDataDirectory = string.Empty;
        /// <summary>
        /// 插件目录，后缀已包含“\”
        /// </summary>
        /// <returns></returns>
        public string Get_PluginDataDirectory()
        {
            return app_PluginDataDirectory;
        }
        #region 委托 QQ API
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr OutputLog([MarshalAs(UnmanagedType.LPStr)] string message);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SendPrivateMsg(long QQ, [MarshalAs(UnmanagedType.LPStr)] string msg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SendGroupMsg(long GroupQQ, [MarshalAs(UnmanagedType.LPStr)] string msg, long otherQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr UploadImage(long QQ, [MarshalAs(UnmanagedType.LPArray)] byte[] pic, int picsize);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate int SendGroupTempMsg(long QQ, long otherQQ, [MarshalAs(UnmanagedType.LPStr)] string msg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SendConsultMsg(long QQ, [MarshalAs(UnmanagedType.LPStr)] string msg, [MarshalAs(UnmanagedType.LPStr)] string chattoken);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr AddGroup([MarshalAs(UnmanagedType.LPStr)] string GroupQQ, [MarshalAs(UnmanagedType.LPStr)] string answer);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GetRobotQQNick();
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void GetPskey(ref Struct_Pskey_PA[] ptr);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate int GetFriendInfo(ref Struct_EArray[] eArray);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate int GetGroupMemberInfo([MarshalAs(UnmanagedType.LPStr)] string QQ, ref Struct_EArray[] eArray);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GetGroupMemberList([MarshalAs(UnmanagedType.LPStr)] string GroupId, [MarshalAs(UnmanagedType.LPStr)] string Uin, [MarshalAs(UnmanagedType.LPStr)] ref string Card, [MarshalAs(UnmanagedType.LPStr)] ref string Nick, ref int Level, [MarshalAs(UnmanagedType.LPStr)] ref string Touxian);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool GetGroupInfo_JL(long QQ, ref Struct_GroupInfo_PA[] eArray);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GetGroupAdmin(long GroupQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool DelGroupMember(long GroupQQ, long memberQQ, bool isRefuse);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool MuteGroupMember(long GroupQQ, long memberQQ, int MuteTime);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool MuteGroup(long GroupQQ, int isMute);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool OutGroup([MarshalAs(UnmanagedType.LPStr)] string GroupQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate long IsMute(long GroupQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void GroupVerificationEvent(long GroupQQ, long triggerQQ, long msgSeq, int OperationType, int eventType, [MarshalAs(UnmanagedType.LPStr)] string reason);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void FriendVerificationEvent(long triggerQQ, long msgSeq, int OperationType);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void QQLike([MarshalAs(UnmanagedType.LPStr)] string otherQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool SlectFriendInfo(long otherQQ, ref FriendInfo_PA[] fda);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr Audio2TXT([MarshalAs(UnmanagedType.LPStr)] string audiohash, string token, int waittime);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void SetOlineStatus(int type, int subtype, int power);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void PushGroupMsg(Struct_Group_Msg_PA[] msg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void PushFriendMsg(Struct_Friend_Msg_PA[] msg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void PushOtherMsg(Struct_Other_Msg_PA[] msg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool IsOpenQQConsult([MarshalAs(UnmanagedType.LPStr)] string hisUin);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr WithdrawGroupMsg(long QQ, long fromReq, long fromRandom);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr WithdrawFriendMsg(long QQ, long fromReq, long fromRandom, long fromTime);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr ShareMusic(int type, long obj, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string author, [MarshalAs(UnmanagedType.LPStr)] string jmpurl, [MarshalAs(UnmanagedType.LPStr)] string pic, [MarshalAs(UnmanagedType.LPStr)] string audiourl, [MarshalAs(UnmanagedType.LPStr)] string appname);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void CallFriendTelPhone(long QQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void RejectTelPhone(long QQ, long longtoken);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void AcceptTelPhone([MarshalAs(UnmanagedType.LPStr)] string ip, int port, long longtoken, [MarshalAs(UnmanagedType.LPStr)] string token);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate int SetGroupMemberName(long QQ, long otherQQ, [MarshalAs(UnmanagedType.LPStr)] string name);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate int UploadAvatar([MarshalAs(UnmanagedType.LPArray)] byte[] pic, int picsize);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool ModifyInfo([MarshalAs(UnmanagedType.LPStr)] string name, int sex, int year, int month, int day, int job, [MarshalAs(UnmanagedType.LPStr)] string company, [MarshalAs(UnmanagedType.LPStr)] string school, [MarshalAs(UnmanagedType.LPStr)] string province1, [MarshalAs(UnmanagedType.LPStr)] string cityindex1, [MarshalAs(UnmanagedType.LPStr)] string province2, [MarshalAs(UnmanagedType.LPStr)] string cityindex2, [MarshalAs(UnmanagedType.LPStr)] string mail, [MarshalAs(UnmanagedType.LPStr)] string desc);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool Poke(long otherQQ, long GroupQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr ForwardMsg(IntPtr ptr);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool UploadGraffiti(IntPtr list, float penSize, int picWidth, int picHeight, [MarshalAs(UnmanagedType.LPStr)] ref string retHash, [MarshalAs(UnmanagedType.LPStr)] ref string returl);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void TXT2Audio(string txt, ref IntPtr ptr);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void TXT2Audio1(string txt, ref Struct_EArray_byte[] ptr);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool BatchDelMemberQQ(long GroupQQ, IntPtr ptr);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void GroupSignin([MarshalAs(UnmanagedType.LPStr)] string template_id, [MarshalAs(UnmanagedType.LPStr)] string lot, [MarshalAs(UnmanagedType.LPStr)] string lat, [MarshalAs(UnmanagedType.LPStr)] string poi, [MarshalAs(UnmanagedType.LPArray)] byte[] pic, int length, int pic_id, [MarshalAs(UnmanagedType.LPStr)] string text);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool UploadGroupFile(long GroupQQ, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string fileid, [MarshalAs(UnmanagedType.LPArray)] byte[] filedata, int length);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool UploadFirendFile(long otherQQ, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPArray)] byte[] filedata, int length);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GetGroupFileAddr(long GroupQQ, [MarshalAs(UnmanagedType.LPStr)] string fileid, [MarshalAs(UnmanagedType.LPStr)] string filename);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GetGroupVideoAddr(long GroupQQ, long QQ, [MarshalAs(UnmanagedType.LPStr)] string param, [MarshalAs(UnmanagedType.LPStr)] string hash1);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate int GetLaveAtCount(long GroupQQ);
        #endregion

        #region 频道API
        ///频道
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr UploadChannelImage(long channelID, long chatroomID, byte[] pic, int length);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool GetChannelGroup(long channelID, ref Struct_EArray[] eArray);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate int SetChannelIdentity(long channelID, long otherID, long identityID);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate int GetChannelMemberQQinfo(long channelID, ref Struct_Guild_Member_E[] gme);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate int GetChannelID();
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool GetOtherChannelInfo(long tiny_id, ref Struct_Guild_Tinyid_Info_E[] data);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool GetSonChannelInfo(long channelID, ref Struct_EArray[] eArray);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool GetChannelLiveRoomInfo(long roomId, ref Struct_Guild_Room_Info_EPD[] ptrs);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool GetChannelLiveRoomInfo1(long channelID, long roomId, ref Struct_Guild_Room_Info_EPD[] ptrs);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SendChannelMsg(long channelID, long chatroomID, [MarshalAs(UnmanagedType.LPStr)] string msg, long otherQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void CullGuildMember(long channelID, long memberID, bool isblack);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool GetGuild_Live_Info(long roomId, [MarshalAs(UnmanagedType.LPStr)] string unkown1,ref Struct_Guild_Live_Info_E[] data);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool GetGuidlist(ref Struct_EArray[] eArray);
        #endregion

        /// <summary>
        /// 输出日志
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string OutLog(string message)

        {
            string ret = string.Empty;
            int privateMsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("输出日志").ToString());
            IntPtr intPtr = new IntPtr(privateMsgAddress);
            OutputLog outputLog = (OutputLog)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(OutputLog));
            ret = Marshal.PtrToStringAnsi(outputLog(message));
            outputLog = null;
            return ret;
        }

        /// <summary>
        /// 发送好友消息
        /// </summary>
        /// <param name="QQ"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public string SendPrivateMsg_(long QQ, string msg)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("发送好友消息").ToString());
            SendPrivateMsg sendmsg = (SendPrivateMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendPrivateMsg));
            string ret = Marshal.PtrToStringAnsi(sendmsg(QQ, msg));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="GroupQQ"></param>
        /// <param name="msg"></param>
        /// <param name="otherQQ"></param>
        /// <returns></returns>
        public string SendGroupMsg_(long GroupQQ, string msg, long otherQQ = 0L)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("发送群消息").ToString());
            SendGroupMsg sendmsg = (SendGroupMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendGroupMsg));
            string ret = Marshal.PtrToStringAnsi(sendmsg(GroupQQ, msg, otherQQ));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 发送好友消息_纯文本
        /// </summary>
        /// <param name="QQ"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public string SendPrivateMsg_C(long QQ, string msg)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("发送好友消息_纯文本").ToString());
            SendPrivateMsg sendmsg = (SendPrivateMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendPrivateMsg));
            string ret = Marshal.PtrToStringAnsi(sendmsg(QQ, msg));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 发送群消息_纯文本
        /// </summary>
        /// <param name="GroupQQ"></param>
        /// <param name="msg"></param>
        /// <param name="otherQQ"></param>
        /// <returns></returns>
        public string SendGroupMsg_C(long GroupQQ, string msg, long otherQQ)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("发送群消息_纯文本").ToString());
            SendGroupMsg sendmsg = (SendGroupMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendGroupMsg));
            string ret = Marshal.PtrToStringAnsi(sendmsg(GroupQQ, msg, otherQQ));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 发送群临时消息
        /// </summary>
        /// <param name="QQ"></param>
        /// <param name="msg"></param>
        /// <param name="otherQQ"></param>
        /// <returns></returns>
        public int SendGroupTempMsg_(long QQ, long otherQQ, string msg)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("发送群临时消息").ToString());
            SendGroupTempMsg sendmsg = (SendGroupTempMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendGroupTempMsg));
            int ret = sendmsg(QQ, otherQQ, msg);
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 发送咨询消息
        /// </summary>
        /// <param name="QQ"></param>
        /// <param name="msg"></param>
        /// <param name="chattoken">可以通过chattoken回复别人的咨询消息,就是对方可以不用开通咨询</param>
        /// <returns></returns>
        public string SendConsultMsg_(long QQ, string msg, string chattoken = "")

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("发送咨询消息").ToString());
            SendConsultMsg sendmsg = (SendConsultMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendConsultMsg));
            string ret = Marshal.PtrToStringAnsi(sendmsg(QQ, msg, chattoken));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 添加好友
        /// </summary>
        /// <param name="QQ"></param>
        /// <param name="answer">问题答案</param>
        /// <returns></returns>
        public string AddFriend_(long QQ, string answer = "")

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("添加好友").ToString());
            SendPrivateMsg sendmsg = (SendPrivateMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendPrivateMsg));
            string ret = Marshal.PtrToStringAnsi(sendmsg(QQ, answer));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 添加群
        /// </summary>
        /// <param name="GroupQQ"></param>
        /// <param name="answer">验证消息</param>
        /// <returns></returns>
        public string AddGroup_(long GroupQQ, string answer = "")

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("添加群").ToString());
            AddGroup sendmsg = (AddGroup)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(AddGroup));
            string ret = Marshal.PtrToStringAnsi(sendmsg(GroupQQ.ToString(), answer));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 删除好友
        /// </summary>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public string OutLog(long QQ)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("删除好友").ToString());
            OutputLog sendmsg = (OutputLog)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(OutputLog));
            string ret = Marshal.PtrToStringAnsi(sendmsg(QQ.ToString()));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 发送好友json消息
        /// </summary>
        /// <param name="GroupQQ"></param>
        /// <param name="jsonstr"></param>
        /// <returns>成功返回的time用于撤回消息</returns>
        public string SendJson_(long GroupQQ, string jsonstr)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("发送好友json消息").ToString());
            SendPrivateMsg sendmsg = (SendPrivateMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendPrivateMsg));
            string ret = Marshal.PtrToStringAnsi(sendmsg(GroupQQ, jsonstr));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 取昵称
        /// </summary>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public string GetQQNick(long QQ)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("取昵称").ToString());
            OutputLog sendmsg = (OutputLog)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(OutputLog));
            string ret = Marshal.PtrToStringAnsi(sendmsg(QQ.ToString()));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 取账号昵称称
        /// </summary>
        /// <returns></returns>
        public string GetRobotQQNick_()

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("取账号昵称").ToString());
            GetRobotQQNick sendmsg = (GetRobotQQNick)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetRobotQQNick));
            string ret = Marshal.PtrToStringAnsi(sendmsg());
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 取群名称<para>如果是框架QQ没加的群，请使用[查询群信息]，查询后也会记录缓存</para>
        /// </summary>
        /// <param name="QQ"></param>
        /// <returns>成功返回群名称</returns>
        public string GetGroupQQName(long QQ)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("取群名称").ToString());
            OutputLog sendmsg = (OutputLog)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(OutputLog));
            string ret = Marshal.PtrToStringAnsi(sendmsg(QQ.ToString()));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 获取skey
        /// </summary>
        /// <returns></returns>
        public string GetSkey_()

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("获取skey").ToString());
            GetRobotQQNick sendmsg = (GetRobotQQNick)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetRobotQQNick));
            string ret = Marshal.PtrToStringAnsi(sendmsg());
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 获取pskey<para>tenpay.com;openmobile.qq.com;docs.qq.com;connect.qq.com;qzone.qq.com;vip.qq.com;gamecenter.qq.com;qun.qq.com;game.qq.com;qqweb.qq.com;ti.qq.com;office.qq.com;mail.qq.com;mma.qq.com</para>
        /// </summary>
        /// <returns></returns>
        public Struct_Pskey GetPskey_()

        {
            Struct_Pskey_PA[] ptrs = new Struct_Pskey_PA[1];
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("获取pskey").ToString());
            GetPskey sendmsg = (GetPskey)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetPskey));
            sendmsg(ref ptrs);
            sendmsg = null;
            return ptrs[0].sp;
        }

        /// <summary>
        /// 获取clientkey
        /// </summary>
        /// <returns></returns>
        public string GetClientkey_()

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("获取clientkey").ToString());
            GetRobotQQNick sendmsg = (GetRobotQQNick)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetRobotQQNick));
            string ret = Marshal.PtrToStringAnsi(sendmsg());
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 取框架QQ
        /// </summary>
        /// <returns></returns>
        public string GetRobotQQ()

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("取框架QQ").ToString());
            GetRobotQQNick sendmsg = (GetRobotQQNick)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetRobotQQNick));
            string ret = Marshal.PtrToStringAnsi(sendmsg());
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 取好友列表
        /// </summary>
        /// <returns></returns>
        public List<FriendInfo> GetFriendInfo_()

        {
            Struct_EArray[] eArray = new Struct_EArray[1];
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("取好友列表").ToString());
            GetFriendInfo sendmsg = (GetFriendInfo)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetFriendInfo));
            int ret = sendmsg(ref eArray);
            Array.Resize(ref eArray[0].ptrs, eArray[0].count);
            List<FriendInfo> fis = new List<FriendInfo>();

            foreach (IntPtr item in eArray[0].ptrs)
            {
                FriendInfo_E fie = Marshal.PtrToStructure<FriendInfo_E>(item);
                FriendInfo fi = new FriendInfo()
                {
                    QQ达人 = fie.QQ达人,
                    所属 = fie.所属,
                    昵称 = fie.昵称,
                    生日= fie.生日,
                    年龄 = fie.年龄,
                    备注 = fie.备注,
                    城市 = fie.城市,
                    性别 = fie.性别,
                    Q等级 = fie.Q等级,
                    今日可赞数 = fie.今日可赞数,
                    今日已赞 = fie.今日已赞,
                    位置信息 = fie.位置信息,
                    国家 = fie.国家,
                    在线状态 = fie.在线状态,
                    手机号码 = fie.手机号码,
                    查询结果 = fie.查询结果,
                    添加好友来源 = fie.添加好友来源,
                    省份 = fie.省份,
                    签名 = fie.签名,
                    账号 = fie.账号,
                    赞数量 = fie.赞数量,
                    连续在线天数 = fie.连续在线天数,
                    邮箱 = fie.邮箱
                };
                if (fie.服务列表 != IntPtr.Zero)
                {
                    Struct_EArray se = Marshal.PtrToStructure<Struct_EArray>(fie.服务列表);
                    Array.Resize(ref se.ptrs, se.count);
                    Struct_Service_Info sce = Marshal.PtrToStructure<Struct_Service_Info>(se.ptrs[0]);
                    fi.服务列表 = sce;
                }
                if (fie.会话签名 != IntPtr.Zero)
                {
                    Struct_EArray_byte se = Marshal.PtrToStructure<Struct_EArray_byte>(fie.会话签名);
                    Array.Resize(ref se.bytes, se.count);
                    fi.会话签名 = se.bytes;
                }
                fis.Add(fi);
            }
            sendmsg = null;
            return fis;
        }

        /// <summary>
        /// 取群列表
        /// </summary>
        /// <returns></returns>
        public List<Struct_GroupInfo> GetGroupInfo_()

        {
            Struct_EArray[] eArray = new Struct_EArray[1];
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("取群列表").ToString());
            GetFriendInfo sendmsg = (GetFriendInfo)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetFriendInfo));
            int ret = sendmsg(ref eArray);
            Array.Resize(ref eArray[0].ptrs, eArray[0].count);
            List<Struct_GroupInfo> fis = new List<Struct_GroupInfo>();
            foreach (IntPtr item in eArray[0].ptrs)
            {
                Struct_GroupInfo fie = Marshal.PtrToStructure<Struct_GroupInfo>(item);
                fis.Add(fie);
            }
            sendmsg = null;
            return fis;
        }

        /// <summary>
        /// 取群成员列表
        /// </summary>
        /// <returns></returns>
        public List<Struct_GroupMemberInfo> GetGroupMemberInfo_(long GroupQQ)

        {
            Struct_EArray[] eArray = new Struct_EArray[1];
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("取群成员列表").ToString());
            GetGroupMemberInfo sendmsg = (GetGroupMemberInfo)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetGroupMemberInfo));
            int ret = sendmsg(GroupQQ.ToString(), ref eArray);
            Array.Resize(ref eArray[0].ptrs, eArray[0].count);
            List<Struct_GroupMemberInfo> fis = new List<Struct_GroupMemberInfo>();
            foreach (IntPtr item in eArray[0].ptrs)
            {
                Struct_GroupMemberInfo fie = Marshal.PtrToStructure<Struct_GroupMemberInfo>(item);
                fis.Add(fie);
            }
            sendmsg = null;
            return fis;
        }

        /// <summary>
        /// 取群成员名片
        /// </summary>
        /// <param name="GroupId">群号</param>
        /// <param name="Uin">QQ</param>
        /// <param name="Card">群昵称</param>
        /// <param name="Nick">昵称</param>
        /// <param name="Level">等级</param>
        /// <param name="Touxian">头衔</param>
        /// <returns>取群成员的昵称、昵称、等级、头衔，返回json信息</returns>
        public string GetGroupMemberList_(long GroupId, long Uin, ref string Card, ref string Nick, ref int Level, ref string Touxian)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("取群成员名片").ToString());
            GetGroupMemberList sendmsg = (GetGroupMemberList)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetGroupMemberList));
            string ret = Marshal.PtrToStringAnsi(sendmsg(GroupId.ToString(), Uin.ToString(), ref Card, ref Nick, ref Level, ref Touxian));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 取群简略信息
        /// </summary>
        /// <param name="GroupQQ"></param>
        /// <returns></returns>
        public Struct_GroupInfo GetGroupInfo_JL_(long GroupQQ)

        {
            Struct_GroupInfo_PA[] eA = new Struct_GroupInfo_PA[1];
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("取群简略信息").ToString());
            GetGroupInfo_JL sendmsg = (GetGroupInfo_JL)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetGroupInfo_JL));
            bool ret = sendmsg(GroupQQ, ref eA);
            sendmsg = null;
            return eA[0].sg;
        }

        /// <summary>
        /// 取管理层列表
        /// </summary>
        /// <param name="GroupQQ"></param>
        /// <returns>第一行是群主，剩下的是管理员</returns>
        public string GetGroupAdmin_(long GroupQQ)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("取管理层列表").ToString());
            GetGroupAdmin sendmsg = (GetGroupAdmin)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetGroupAdmin));
            string ret = Marshal.PtrToStringAnsi(sendmsg(GroupQQ));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 删除群成员
        /// </summary>
        /// <param name="GroupQQ"></param>
        /// <param name="memberQQ">群成员QQ</param>
        /// <param name="isRefuse">拒绝加群申请</param>
        /// <returns></returns>
        public bool DelGroupMember_(long GroupQQ, long memberQQ, bool isRefuse)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("删除群成员").ToString());
            DelGroupMember sendmsg = (DelGroupMember)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(DelGroupMember));
            bool ret = sendmsg(GroupQQ, memberQQ, isRefuse);
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 禁言群成员
        /// </summary>
        /// <param name="GroupQQ"></param>
        /// <param name="memberQQ">群成员QQ</param>
        /// <param name="MuteTime">单位：秒，为0时解除禁言</param>
        /// <returns></returns>
        public bool MuteGroupMember_(long GroupQQ, long memberQQ, int MuteTime)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("禁言群成员").ToString());
            MuteGroupMember sendmsg = (MuteGroupMember)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(MuteGroupMember));
            bool ret = sendmsg(GroupQQ, memberQQ, MuteTime);
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 全群禁言
        /// </summary>
        /// <param name="GroupQQ"></param>
        /// <param name="isMute">真为禁，假为解禁</param>
        /// <returns></returns>
        public bool MuteGroup_(long GroupQQ, int isMute)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("全群禁言").ToString());
            MuteGroup sendmsg = (MuteGroup)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(MuteGroup));
            bool ret = sendmsg(GroupQQ, isMute);
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 退群
        /// </summary>
        /// <param name="GroupQQ"></param>
        /// <returns></returns>
        public bool OutGroup_(long GroupQQ)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("退群").ToString());
            OutGroup sendmsg = (OutGroup)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(OutGroup));
            bool ret = sendmsg(GroupQQ.ToString());
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 是否被禁言
        /// </summary>
        /// <param name="GroupQQ"></param>
        /// <returns></returns>
        public long IsMute_(long GroupQQ)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("是否被禁言").ToString());
            IsMute sendmsg = (IsMute)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(IsMute));
            long ret = sendmsg(GroupQQ);
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 处理群验证事件
        /// </summary>
        /// <param name="GroupQQ"></param>
        /// <param name="triggerQQ">触发QQ</param>
        /// <param name="msgSeq">消息Seq</param>
        /// <param name="OperationType">操作类型</param>
        /// <param name="eventType">事件类型</param>
        /// <param name="reason">拒绝理由<para>当为拒绝时，可在此设置拒绝理由</para></param>
        public void GroupVerificationEvent_(long GroupQQ, long triggerQQ, long msgSeq, GOperationTypeEnum OperationType, EventTypeEnum eventType, string reason = "")

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("处理群验证事件").ToString());
            GroupVerificationEvent sendmsg = (GroupVerificationEvent)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupVerificationEvent));
            sendmsg(GroupQQ, triggerQQ, msgSeq, (int)OperationType, (int)eventType, reason);
            sendmsg = null;
        }

        /// <summary>
        /// 处理好友验证事件
        /// </summary>
        /// <param name="triggerQQ"></param>
        /// <param name="msgSeq"></param>
        /// <param name="OperationType"></param>
        public void FriendVerificationEvent_(long triggerQQ, long msgSeq, FOperationTypeEnum OperationType)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("处理好友验证事件").ToString());
            FriendVerificationEvent sendmsg = (FriendVerificationEvent)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupVerificationEvent));
            sendmsg(triggerQQ, msgSeq, (int)OperationType);
            sendmsg = null;
        }

        /// <summary>
        /// QQ点赞
        /// </summary>
        /// <param name="otherQQ"></param>
        public void QQLike_(long otherQQ)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("QQ点赞").ToString());
            QQLike sendmsg = (QQLike)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(QQLike));
            sendmsg(otherQQ.ToString());
            sendmsg = null;
        }

        /// <summary>
        /// 查询好友信息<para>支持陌生人查询</para>
        /// </summary>
        /// <param name="otherQQ"></param>
        /// <returns></returns>
        public FriendInfo SlectFriendInfo_(long otherQQ)

        {
            IntPtr ptr = Marshal.AllocHGlobal(4);
            Struct_Service_Info ssi = new Struct_Service_Info();
            Marshal.StructureToPtr(ssi, ptr, false);
            FriendInfo_E fe = new FriendInfo_E() { 服务列表 = ptr };
            FriendInfo_PA[] fpa = new FriendInfo_PA[1];
            fpa[0].fie = fe;
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("查询好友信息").ToString());
            SlectFriendInfo sendmsg = (SlectFriendInfo)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SlectFriendInfo));
            bool ret = sendmsg(otherQQ, ref fpa);

            FriendInfo_E fie = fpa[0].fie;
            FriendInfo fi = new FriendInfo()
            {
                QQ达人 = fie.QQ达人,
                所属 = fie.所属,
                昵称 = fie.昵称,
                年龄 = fie.年龄,
                备注 = fie.备注,
                城市 = fie.城市,
                性别 = fie.性别,
                Q等级 = fie.Q等级,
                今日可赞数 = fie.今日可赞数,
                今日已赞 = fie.今日已赞,
                位置信息 = fie.位置信息,
                国家 = fie.国家,
                在线状态 = fie.在线状态,
                手机号码 = fie.手机号码,
                查询结果 = fie.查询结果,
                添加好友来源 = fie.添加好友来源,
                省份 = fie.省份,
                签名 = fie.签名,
                账号 = fie.账号,
                赞数量 = fie.赞数量,
                连续在线天数 = fie.连续在线天数,
                邮箱 = fie.邮箱
            };
            if (fie.服务列表 != IntPtr.Zero)
            {
                Struct_EArray se = Marshal.PtrToStructure<Struct_EArray>(fie.服务列表);
                Array.Resize(ref se.ptrs, se.count);
                Struct_Service_Info sce = Marshal.PtrToStructure<Struct_Service_Info>(se.ptrs[0]);
                fi.服务列表 = sce;
            }
            if (fie.会话签名 != IntPtr.Zero)
            {
                Struct_EArray_byte se = Marshal.PtrToStructure<Struct_EArray_byte>(fie.会话签名);
                Array.Resize(ref se.bytes, se.count);
                fi.会话签名 = se.bytes;
            }
            sendmsg = null;
            return fi;
        }

        /// <summary>
        /// 发送好友xml消息
        /// </summary>
        /// <param name="QQ"></param>
        /// <param name="xmlcode"></param>
        /// <returns>成功返回的time用于撤回消息</returns>
        public string SendFriendXmlMsg_(long QQ, string xmlcode)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("发送好友xml消息").ToString());
            SendPrivateMsg sendmsg = (SendPrivateMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendPrivateMsg));
            string ret = Marshal.PtrToStringAnsi(sendmsg(QQ, xmlcode));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 发送群xml消息
        /// </summary>
        /// <param name="QQ"></param>
        /// <param name="xmlcode"></param>
        /// <returns>成功返回的time用于撤回消息</returns>
        public string SendGroupXmlMsg_(long QQ, string xmlcode)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("发送群xml消息").ToString());
            SendPrivateMsg sendmsg = (SendPrivateMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendPrivateMsg));
            string ret = Marshal.PtrToStringAnsi(sendmsg(QQ, xmlcode));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 语音转文本
        /// </summary>
        /// <param name="audiohash"></param>
        /// <param name="token"></param>
        /// <param name="waittime">单位为毫秒，默认为5000毫秒</param>
        /// <returns>失败或超时返回空,tx自带的朗读功能</returns>
        public string Audio2TXT_(string audiohash, string token, int waittime = 5000)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("语音转文本").ToString());
            Audio2TXT sendmsg = (Audio2TXT)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(Audio2TXT));
            string ret = Marshal.PtrToStringAnsi(sendmsg(audiohash, token, waittime));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 文本转语音
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public byte[] TXT2Audio_(string txt)

        {
            IntPtr ptr = Marshal.AllocHGlobal(4);
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("文本转语音").ToString());
            TXT2Audio sendmsg = (TXT2Audio)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(TXT2Audio));
            sendmsg(txt, ref ptr);
            Struct_EArray_byte ret = (Struct_EArray_byte)Marshal.PtrToStructure(ptr, typeof(Struct_EArray_byte));
            Array.Resize(ref ret.bytes, ret.count);
            sendmsg = null;
            return ret.bytes;
        }

        /// <summary>
        /// 文本转语音（研究用）
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        [Obsolete("研究用")]
        private byte[] TXT2Audio1_(string txt)

        {
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Struct_EArray_byte)));
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("文本转语音").ToString());
            TXT2Audio sendmsg = (TXT2Audio)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(TXT2Audio));
            sendmsg(txt, ref ptr);
            Struct_EArray_byte ret = (Struct_EArray_byte)Marshal.PtrToStructure(ptr, typeof(Struct_EArray_byte));
            Array.Resize(ref ret.bytes, ret.count);
            sendmsg = null;
            return ret.bytes;
        }

        /// <summary>
        /// 文本转语音（研究用）
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        [Obsolete("研究用")]
        private byte[] TXT2Audio2_(string txt)

        {
            Struct_EArray_byte[] ptr = new Struct_EArray_byte[1];
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("文本转语音").ToString());
            TXT2Audio1 sendmsg = (TXT2Audio1)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(TXT2Audio1));
            sendmsg(txt, ref ptr);
            Array.Resize(ref ptr[0].bytes, ptr[0].count);
            sendmsg = null;
            return ptr[0].bytes;
        }

        /// <summary>
        /// 设置在线状态
        /// </summary>
        /// <param name="type"></param>
        /// <param name="subtype">当type设置为11时有效</param>
        /// <param name="power">充电电量，当subtype设置为1000时有效</param>
        public void SetOlineStatus_(OlineStatusTypeEnum type, OlineStatusSubtypeEnum subtype, int power)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("设置在线状态").ToString());
            SetOlineStatus sendmsg = (SetOlineStatus)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SetOlineStatus));
            sendmsg((int)type, (int)subtype, power);
            sendmsg = null;
        }

        /// <summary>
        /// 推送群消息
        /// </summary>
        /// <param name="msg"></param>
        public void PushGroupMsg_(Struct_Group_Msg msg)

        {
            Struct_Group_Msg_PA[] sgmp = new Struct_Group_Msg_PA[1];
            sgmp[0].sgmsg = msg;
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("推送群消息").ToString());
            PushGroupMsg sendmsg = (PushGroupMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(PushGroupMsg));
            sendmsg(sgmp);
            sendmsg = null;
        }

        /// <summary>
        /// 推送私聊消息
        /// </summary>
        /// <param name="msg"></param>
        public void PushFriendMsg_(Struct_Friend_Msg msg)

        {
            Struct_Friend_Msg_PA[] sgmp = new Struct_Friend_Msg_PA[1];
            sgmp[0].sfgp = msg;
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("推送私聊消息").ToString());
            PushFriendMsg sendmsg = (PushFriendMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(PushFriendMsg));
            sendmsg(sgmp);
            sendmsg = null;
        }

        /// <summary>
        /// 推送事件消息
        /// </summary>
        /// <param name="msg"></param>
        public void PushOtherMsg_(Struct_Other_Msg msg)

        {
            Struct_Other_Msg_PA[] sgmp = new Struct_Other_Msg_PA[1];
            sgmp[0].sogp = msg;
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("推送事件消息").ToString());
            PushOtherMsg sendmsg = (PushOtherMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(PushOtherMsg));
            sendmsg(sgmp);
            sendmsg = null;
        }

        /// <summary>
        /// 是否开通QQ咨
        /// </summary>
        /// <param name="hisUin"></param>
        /// <returns></returns>
        public bool IsOpenQQConsult_(string hisUin)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("是否开通QQ咨").ToString());
            IsOpenQQConsult sendmsg = (IsOpenQQConsult)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(IsOpenQQConsult));
            bool ret = sendmsg(hisUin);
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 撤回群聊消息
        /// </summary>
        /// <param name="QQ"></param>
        /// <param name="fromReq"></param>
        /// <param name="fromRandom"></param>
        /// <returns>成功返回code为0，失败返回错误code和msg</returns>
        public string WithdrawGroupMsg_(long QQ, long fromReq, long fromRandom)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("撤回群聊消息").ToString());
            WithdrawGroupMsg sendmsg = (WithdrawGroupMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(WithdrawGroupMsg));
            string ret = Marshal.PtrToStringAnsi(sendmsg(QQ, fromReq, fromRandom));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 撤回私聊消息
        /// </summary>
        /// <param name="QQ"></param>
        /// <param name="fromReq"></param>
        /// <param name="fromRandom"></param>
        /// <returns>成功返回的code为3，参数从发送api返回的json里取</returns>
        public string WithdrawFriendMsg_(long QQ, long fromReq, long fromRandom)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("撤回私聊消息").ToString());
            WithdrawFriendMsg sendmsg = (WithdrawFriendMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(WithdrawFriendMsg));
            string ret = Marshal.PtrToStringAnsi(sendmsg(QQ, fromReq, fromRandom, fromRandom));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 分享音乐
        /// </summary>
        /// <param name="type">分享类型</param>
        /// <param name="obj">分享对象</param>
        /// <param name="name">歌曲名</param>
        /// <param name="author">歌曲作者</param>
        /// <param name="jmpurl">歌曲跳转地址：点开json卡片后打开的网页</param>
        /// <param name="pic">歌曲图片：json卡片的那个圆圆的图</param>
        /// <param name="audiourl">歌曲音频地址：播放的(mp3)音频网络地址</param>
        /// <param name="appname">分享app包名：默认网易云com.netease.cloudmusic</param>
        /// <returns></returns>
        public string ShareMusic_(MusicShareTypeEnum type, long obj, string name, string author, string jmpurl, string pic, string audiourl, string appname = "")

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("分享音乐").ToString());
            ShareMusic sendmsg = (ShareMusic)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(ShareMusic));
            string ret = Marshal.PtrToStringAnsi(sendmsg((int)type, obj, name, author, jmpurl, pic, audiourl, appname));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 打好友电话<para>发起语音通话，仅支持QQ列表内的好友。与小栗子的QQ电话不同的是，对方可以正常接通</para>
        /// </summary>
        /// <param name="QQ"></param>
        public void CallFriendTelPhone_(long QQ)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("打好友电话").ToString());
            CallFriendTelPhone sendmsg = (CallFriendTelPhone)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(CallFriendTelPhone));
            sendmsg(QQ);
            sendmsg = null;
        }

        /// <summary>
        /// 拒绝好友电话
        /// </summary>
        /// <param name="QQ"></param>
        /// <param name="longtoken">,longtoken=(.+?)]</param>
        public void RejectTelPhone_(long QQ, long longtoken)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("拒绝好友电话").ToString());
            RejectTelPhone sendmsg = (RejectTelPhone)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(RejectTelPhone));
            sendmsg(QQ, longtoken);
            sendmsg = null;
        }

        /// <summary>
        /// 接受好友电话
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="longtoken"></param>
        /// <param name="token"></param>
        public void AcceptTelPhone_(string ip, int port, long longtoken, string token)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("接受好友电话").ToString());
            AcceptTelPhone sendmsg = (AcceptTelPhone)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(AcceptTelPhone));
            sendmsg(ip, port, longtoken, token);
            sendmsg = null;
        }

        /// <summary>
        /// 置群成员专属头衔
        /// </summary>
        /// <param name="GroupQQ">群号</param>
        /// <param name="otherQQ">目标QQ</param>
        /// <param name="name">头衔 //如果要删除，这里填空</param>
        /// <returns></returns>
        public int SetGroupMemberName_(long GroupQQ, long otherQQ, string name)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("置群成员专属头衔").ToString());
            SetGroupMemberName sendmsg = (SetGroupMemberName)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SetGroupMemberName));
            int ret = sendmsg(GroupQQ, otherQQ, name);
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 置签名<para>设置自己的个性签名</para>
        /// </summary>
        /// <param name="sign">签名</param>
        /// <returns></returns>
        public bool SignName_(string sign)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("置签名").ToString());
            IsOpenQQConsult sendmsg = (IsOpenQQConsult)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(IsOpenQQConsult));
            bool ret = sendmsg(sign);
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 修改资料<para>修改个人资料,不修改的项请勿传任何参数</para>
        /// </summary>
        /// <param name="name">昵称</param>
        /// <param name="sex">性别</param>
        /// <param name="year">生日年</param>
        /// <param name="month">生日月</param>
        /// <param name="day">生日日</param>
        /// <param name="job">职业<para>职业列表里第几行</para></param>
        /// <param name="company">公司</param>
        /// <param name="school">学校</param>
        /// <param name="province1">所在地省份<para>北京为1</para></param>
        /// <param name="cityindex1">所在地城市索引<para>所在地城市索引</para></param>
        /// <param name="province2">家乡省份</param>
        /// <param name="cityindex2">家乡城市索引</param>
        /// <param name="mail">邮箱</param>
        /// <param name="desc">个人说明</param>
        /// <returns></returns>
        public bool ModifyInfo_(string name = "", int sex = -1, int year = -1, int month = -1, int day = -1, int job = -1, string company = "", string school = "", string province1 = "", string cityindex1 = "", string province2 = "", string cityindex2 = "", string mail = "", string desc = "")

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("修改资料").ToString());
            ModifyInfo sendmsg = (ModifyInfo)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(ModifyInfo));
            bool ret = sendmsg(name, sex, year, month, day, job, company, school, province1, cityindex1, province2, cityindex2, mail, desc);
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 戳一戳
        /// </summary>
        /// <param name="otherQQ"></param>
        /// <param name="GroupQQ">群号：不传递此参数时，为私聊戳一戳</param>
        /// <returns></returns>
        public bool Poke_(long otherQQ, long GroupQQ = 0)

        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("戳一戳").ToString());
            Poke sendmsg = (Poke)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(Poke));
            bool ret = sendmsg(otherQQ, GroupQQ);
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 设置群昵称
        /// </summary>
        /// <param name="GroupQQ">群号</param>
        /// <param name="otherQQ">对方QQ</param>
        /// <param name="name">新昵称</param>
        /// <returns></returns>
        public int SetGroupName_(long GroupQQ, long otherQQ, string name)
        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("设置群昵称").ToString());
            SetGroupMemberName sendmsg = (SetGroupMemberName)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SetGroupMemberName));
            int ret = sendmsg(GroupQQ, otherQQ, name);
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 合并转发消息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string ForwardMsg_(List<Struct_Group_Msg> list)

        {
            GetPtr<Struct_Group_Msg> getPtr = new GetPtr<Struct_Group_Msg>();
            IntPtr[] ptrs = getPtr.GetIntPtrs(list);
            Struct_EArray eArray = new Struct_EArray() { index = 1, count = list.Count, ptrs = ptrs };
            Array.Resize(ref eArray.ptrs, 1024 * 10);
            IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(eArray));
            Marshal.StructureToPtr(eArray, intPtr, false);
            IntPtr intPtr1 = Marshal.AllocHGlobal(4);
            Marshal.StructureToPtr(intPtr, intPtr1, false);
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("合并转发消息").ToString());
            ForwardMsg sendmsg = (ForwardMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(ForwardMsg));
            string ret = Marshal.PtrToStringAnsi(sendmsg(intPtr1));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 上传涂鸦
        /// </summary>
        /// <param name="list"></param>
        /// <param name="penSize"></param>
        /// <param name="picWidth"></param>
        /// <param name="picHeight"></param>
        /// <param name="retHash"></param>
        /// <param name="returl"></param>
        /// <returns></returns>
        public bool UploadGraffiti_(List<Struct_Draw> list, float penSize, int picWidth, int picHeight, ref string retHash, ref string returl)
        {
            List<Struct_Draw_E> listE = new List<Struct_Draw_E>();
            foreach (var item in list)
            {
                IntPtr iptr = Marshal.AllocHGlobal(4);
                Marshal.StructureToPtr(item.struct_sraw_info, iptr, false);
                Struct_Draw_E sde = new Struct_Draw_E() { colorHex = item.colorHex, colorType = item.colorType, struct_sraw_info = iptr };
                listE.Add(sde);
            }
            GetPtr<Struct_Draw_E> getPtr = new GetPtr<Struct_Draw_E>();
            IntPtr[] ptrs = getPtr.GetIntPtrs(listE);
            Struct_EArray eArray = new Struct_EArray() { index = 1, count = list.Count, ptrs = ptrs };
            Array.Resize(ref eArray.ptrs, 1024 * 10);
            IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(eArray));
            Marshal.StructureToPtr(eArray, intPtr, false);
            IntPtr intPtr1 = Marshal.AllocHGlobal(4);
            Marshal.StructureToPtr(intPtr, intPtr1, false);
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("上传涂鸦").ToString());
            UploadGraffiti sendmsg = (UploadGraffiti)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadGraffiti));
            bool ret = sendmsg(intPtr1, penSize, picWidth, picHeight, ref retHash, ref returl);
            sendmsg = null;
            return ret;
        }

        #region 图片类处理函数
        /// <summary>
        /// 上传群图片
        /// </summary>
        /// <param name="groupQQ"></param>
        /// <param name="picpath"></param>
        /// <returns>成功返回图片代码</returns>
        public string UploadGroupImage(long groupQQ, string picpath)
        {
            Bitmap bitmap = new Bitmap(picpath);
            byte[] picture = GetByteArrayByImage(bitmap);
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("上传群图片").ToString());
            UploadImage sendmsg = (UploadImage)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadImage));
            string ret = Marshal.PtrToStringAnsi(sendmsg(groupQQ, picture, picture.Length));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 上传好友图片
        /// </summary>
        /// <param name="friendQQ"></param>
        /// <param name="picpath"></param>
        /// <returns>成功返回图片代码</returns>
        public string UploadFriendImage(long friendQQ, string picpath)
        {
            Bitmap bitmap = new Bitmap(picpath);
            byte[] picture = GetByteArrayByImage(bitmap);
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("上传好友图片").ToString());
            UploadImage sendmsg = (UploadImage)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadImage));
            string ret = Marshal.PtrToStringAnsi(sendmsg(friendQQ, picture, picture.Length));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="picpath"></param>
        /// <returns>返回值 1:图片有误 2:上传失败 0:上传成功 3:链接服务器失败 4:请求失败</returns>
        public int UploadAvatar_(string picpath)
        {
            Bitmap bitmap = new Bitmap(picpath);
            byte[] picture = GetByteArrayByImage(bitmap);
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("上传头像").ToString());
            UploadAvatar sendmsg = (UploadAvatar)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadAvatar));
            int ret = sendmsg(picture, picture.Length);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 上传群语音
        /// </summary>
        /// <param name="groupQQ"></param>
        /// <param name="audio"></param>
        /// <returns>成功返回语音代码</returns>
        public string UploadGroupAudio(long groupQQ, byte[] audio)
        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("上传群语音").ToString());
            UploadImage sendmsg = (UploadImage)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadImage));
            string ret = Marshal.PtrToStringAnsi(sendmsg(groupQQ, audio, audio.Length));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 上传好友语音
        /// </summary>
        /// <param name="friendQQ"></param>
        /// <param name="audio"></param>
        /// <returns>成功返回语音代码</returns>
        public string UploadFriendAudio(long friendQQ, byte[] audio)
        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("上传好友语音").ToString());
            UploadImage sendmsg = (UploadImage)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadImage));
            string ret = Marshal.PtrToStringAnsi(sendmsg(friendQQ, audio, audio.Length));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 图片转为二进制
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        private byte[] GetByteArrayByImage(Bitmap bitmap)
        {
            byte[] result;
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                bitmap.Save(memoryStream, ImageFormat.Jpeg);
                byte[] array = new byte[memoryStream.Length];
                memoryStream.Position = 0L;
                memoryStream.Read(array, 0, (int)memoryStream.Length);
                memoryStream.Close();
                result = array;
            }
            catch
            {
                result = null;
            }
            return result;
        }
        #endregion

        /// <summary>
        /// 设置管理
        /// </summary>
        /// <param name="GroupQQ"></param>
        /// <param name="otherQQ"></param>
        /// <param name="isadmin">真上管理 假下管理。</param>
        /// <returns></returns>
        public bool SetAdmin(long GroupQQ, long otherQQ, bool isadmin)
        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("设置管理").ToString());
            DelGroupMember sendmsg = (DelGroupMember)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(DelGroupMember));
            bool ret = sendmsg(GroupQQ, otherQQ, isadmin);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 批量踢人
        /// </summary>
        /// <param name="GroupQQ"></param>
        /// <param name="list">删除成员列表</param>
        /// <returns></returns>
        public bool BatchDelMemberQQ_(long GroupQQ, List<Struct_BatchDel_MemberQQ> list)
        {
            GetPtr<Struct_BatchDel_MemberQQ> getPtr = new GetPtr<Struct_BatchDel_MemberQQ>();
            IntPtr[] ptrs = getPtr.GetIntPtrs(list);
            Struct_EArray eArray = new Struct_EArray() { index = 1, count = list.Count, ptrs = ptrs };
            Array.Resize(ref eArray.ptrs, 1024 * 10);
            IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(eArray));
            Marshal.StructureToPtr(eArray, intPtr, false);
            IntPtr intPtr1 = Marshal.AllocHGlobal(4);
            Marshal.StructureToPtr(intPtr, intPtr1, false);
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("批量踢人").ToString());
            BatchDelMemberQQ sendmsg = (BatchDelMemberQQ)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(BatchDelMemberQQ));
            bool ret = sendmsg(GroupQQ, intPtr1);
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 群签到
        /// </summary>
        /// <param name="template_id">1-10，1天气、5心情、6自定义图片、8运势、%5Bobject%20Object%5D默认</param>
        /// <param name="lot">经度，如113.111111</param>
        /// <param name="lat">纬度，如22.222222</param>
        /// <param name="poi">签到位置</param>
        /// <param name="pic">签到图片，与下面的二选一。当填写此参数时，template_id请写6</param>
        /// <param name="pic_id">1-200，178带口罩、124学习、120上班、180自习开始、181自习结束、127还有谁比我早、125运动、126早睡、</param>
        /// <param name="text">签到内容</param>
        public void GroupSignin_(string template_id, string lot, string lat, string poi, byte[] pic, int pic_id, string text)
        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("群签到").ToString());
            GroupSignin sendmsg = (GroupSignin)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupSignin));
            sendmsg(template_id, lot, lat, poi, pic, pic.Length, pic_id, text);
            sendmsg = null;
        }

        /// <summary>
        /// 上传群文件
        /// </summary>
        /// <param name="GroupQQ"></param>
        /// <param name="filename">文件名</param>
        /// <param name="fileid">群文件夹ID：根目录为‘/’,其他为文件夹id</param>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        public bool UploadGroupFile_(long GroupQQ, string filename, string fileid, string filepath)
        {
            byte[] filedata = File2Byte(filepath);
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("上传群文件").ToString());
            UploadGroupFile sendmsg = (UploadGroupFile)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadGroupFile));
            bool ret = sendmsg(GroupQQ, filename, fileid, filedata, filedata.Length);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 上传好友文件
        /// </summary>
        /// <param name="otherQQ"></param>
        /// <param name="filename"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public bool UploadFirendFile_(long otherQQ, string filename, string filepath)
        {
            byte[] filedata = File2Byte(filepath);
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("上传好友文件").ToString());
            UploadFirendFile sendmsg = (UploadFirendFile)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadFirendFile));
            bool ret = sendmsg(otherQQ, filename, filedata, filedata.Length);
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 文件转字节集
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        private byte[] File2Byte(string filepath)
        {
            if (File.Exists(filepath))
            {
                using (FileStream fs = File.OpenRead(filepath))
                {
                    byte[] data = new byte[fs.Length];
                    fs.Read(data, 0, data.Length);
                    fs.Close();
                    return data;
                }
            }
            return null;
        }

        /// <summary>
        /// 取群文件下载地址
        /// </summary>
        /// <param name="GroupQQ"></param>
        /// <param name="fileid"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string GetGroupFileAddr_(long GroupQQ, string fileid, string filename)
        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("取群文件下载地址").ToString());
            GetGroupFileAddr sendmsg = (GetGroupFileAddr)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadFirendFile));
            string ret = Marshal.PtrToStringAnsi(sendmsg(GroupQQ, fileid, filename));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取好友文件下载地址
        /// </summary>
        /// <param name="QQ"></param>
        /// <param name="fileid"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string GetFriendFileAddr_(long QQ, string fileid, string filename)
        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("取好友文件下载地址").ToString());
            GetGroupFileAddr sendmsg = (GetGroupFileAddr)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadFirendFile));
            string ret = Marshal.PtrToStringAnsi(sendmsg(QQ, fileid, filename));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 取群视频下载地址
        /// </summary>
        /// <param name="GroupQQ"></param>
        /// <param name="QQ">发送QQ</param>
        /// <param name="param"></param>
        /// <param name="hash1"></param>
        /// <returns></returns>
        public string GetGroupVideoAddr_(long GroupQQ, long QQ, string param, string hash1)
        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("取群视频下载地址").ToString());
            GetGroupVideoAddr sendmsg = (GetGroupVideoAddr)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetGroupVideoAddr));
            string ret = Marshal.PtrToStringAnsi(sendmsg(GroupQQ, QQ, param, hash1));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 取好友视频下载地址
        /// </summary>
        /// <param name="QQ"></param>
        /// <param name="param"></param>
        /// <param name="hash1"></param>
        /// <returns></returns>
        public string GetFriendVideoAddr_(long QQ, string param, string hash1)
        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("取好友视频下载地址").ToString());
            GetGroupFileAddr sendmsg = (GetGroupFileAddr)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadFirendFile));
            string ret = Marshal.PtrToStringAnsi(sendmsg(QQ, param, hash1));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 取群剩余艾特全体次数
        /// </summary>
        /// <param name="GroupQQ"></param>
        /// <returns></returns>
        public int GetLaveAtCount_(long GroupQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("取群剩余艾特全体次数").ToString());
            GetLaveAtCount sendmsg = (GetLaveAtCount)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetLaveAtCount));
            int ret = sendmsg(GroupQQ);
            sendmsg = null;
            return ret;
        }

        #region 频道
        /// <summary>
        /// 发送频道消息
        /// </summary>
        /// <param name="channelID">频道ID</param>
        /// <param name="chatroomID">聊天室ID</param>
        /// <param name="msg">消息内容</param>
        /// <param name="otherQQ">对方QQ, 可为空</param>
        /// <returns></returns>
        public string SendChannelMsg_(long channelID, long chatroomID, string msg, long otherQQ = 0L)
        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("发送频道消息").ToString());
            SendChannelMsg sendmsg = (SendChannelMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendChannelMsg));
            string ret = Marshal.PtrToStringAnsi(sendmsg(channelID, chatroomID, msg, otherQQ));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 上传频道图片
        /// </summary>
        /// <param name="channelID"></param>
        /// <param name="chatroomID"></param>
        /// <param name="picpath"></param>
        /// <returns></returns>
        public string UploadChannelImage_(long channelID, long chatroomID, string picpath)
        {
            Bitmap bitmap = new Bitmap(picpath);
            byte[] picture = GetByteArrayByImage(bitmap);
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("上传频道图片").ToString());
            UploadChannelImage sendmsg = (UploadChannelImage)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadChannelImage));
            string ret = Marshal.PtrToStringAnsi(sendmsg(channelID, chatroomID, picture, picture.Length));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取频道身份组
        /// </summary>
        /// <param name="channelID"></param>
        /// <param name="sgis"></param>
        /// <returns></returns>
        public List<Struct_Guild_Identity> GetChannelGroup_(long channelID)
        {
            Struct_EArray[] eArray = new Struct_EArray[1];
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("取频道身份组").ToString());
            GetChannelGroup sendmsg = (GetChannelGroup)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetChannelGroup));
            bool ret = sendmsg(channelID, ref eArray);
            Array.Resize(ref eArray[0].ptrs, eArray[0].count);
            List<Struct_Guild_Identity> sgis = new List<Struct_Guild_Identity>();
            foreach (IntPtr item in eArray[0].ptrs)
            {
                Struct_Guild_Identity fie = Marshal.PtrToStructure<Struct_Guild_Identity>(item);
                sgis.Add(fie);
            }
            sendmsg = null;
            return sgis;
        }

        /// <summary>
        /// 设置频道身份
        /// </summary>
        /// <param name="channelID">频道ID</param>
        /// <param name="otherID">对方ID</param>
        /// <param name="identityID">身份ID</param>
        /// <returns></returns>
        public int SetChannelIdentity_(long channelID, long otherID, long identityID)
        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("设置频道身份").ToString());
            SetChannelIdentity sendmsg = (SetChannelIdentity)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SetChannelIdentity));
            int ret = sendmsg(channelID, otherID, identityID);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取消频道身份
        /// </summary>
        /// <param name="channelID">频道ID</param>
        /// <param name="otherID">对方ID</param>
        /// <param name="identityID">身份ID</param>
        /// <returns></returns>
        public int CancelChannelIdentity_(long channelID, long otherID, long identityID)
        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("取消频道身份").ToString());
            SetChannelIdentity sendmsg = (SetChannelIdentity)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SetChannelIdentity));
            int ret = sendmsg(channelID, otherID, identityID);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 获取频道成员信息
        /// </summary>
        /// <param name="channelID"></param>
        /// <returns></returns>
        public List<Struct_guild_member_identity_C> GetChannelMemberQQinfo_(long channelID)
        {

            Struct_EArray eArray1 = new Struct_EArray();
            IntPtr intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(eArray1));
            Marshal.StructureToPtr(eArray1, intPtr2, false);

            Struct_Guild_Member_E[] gme = new Struct_Guild_Member_E[1];
            gme[0].struct_Guild_Member.identityArr = intPtr2;

            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("获取频道成员信息").ToString());
            GetChannelMemberQQinfo sendmsg = (GetChannelMemberQQinfo)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetChannelMemberQQinfo));
            int ret = sendmsg(channelID, ref gme);

            eArray1 = Marshal.PtrToStructure<Struct_EArray>(gme[0].struct_Guild_Member.identityArr);
            Array.Resize(ref eArray1.ptrs, eArray1.count);

            Struct_Guild_Member_C retc2 = new Struct_Guild_Member_C() { guild_id = gme[0].struct_Guild_Member.guild_id, maxnum = gme[0].struct_Guild_Member.maxnum, num = gme[0].struct_Guild_Member.num };

            List<Struct_guild_member_identity_C> list = new List<Struct_guild_member_identity_C>();
            foreach (var item in eArray1.ptrs)
            {
                Struct_guild_member_identity retgmi = Marshal.PtrToStructure<Struct_guild_member_identity>(item);
                Struct_guild_member_identity_C cc = new Struct_guild_member_identity_C() { color = retgmi.color, id = retgmi.id, identity_name = retgmi.identity_name };
                Struct_EArray gmi = Marshal.PtrToStructure<Struct_EArray>(retgmi.memberArr);
                Array.Resize(ref gmi.ptrs, gmi.count);
                List<Struct_guild_member_info> list2 = new List<Struct_guild_member_info>();
                foreach (var item1 in gmi.ptrs)
                {
                    Struct_guild_member_info dd = Marshal.PtrToStructure<Struct_guild_member_info>(item1);
                    list2.Add(dd);
                }
                cc.memberArr = list2;
                list.Add(cc);
            }

            Marshal.FreeHGlobal(intPtr2);
            sendmsg = null;
            return list;
        }

        /// <summary>
        /// 取自身频道id
        /// </summary>
        /// <returns></returns>
        public int GetChannelID_()
        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("取自身频道id").ToString());
            GetChannelID sendmsg = (GetChannelID)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetChannelID));
            int ret = sendmsg();
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 获取对方频道信息
        /// </summary>
        /// <param name="tiny_id"></param>
        /// <returns></returns>
        public Struct_Guild_Tinyid_Info GetOtherChannelInfo_(long tiny_id)
        {
            Struct_Guild_Tinyid_Info_E[] info = new Struct_Guild_Tinyid_Info_E[1];
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("获取对方频道信息").ToString());
            GetOtherChannelInfo sendmsg = (GetOtherChannelInfo)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetOtherChannelInfo));
            bool ret = sendmsg(tiny_id, ref info);
            Struct_Guild_Tinyid_Info gti = info[0].struct_Guild_Tinyid_Info;
            sendmsg = null;
            return gti;
        }

        /// <summary>
        /// 踢出频道成员
        /// </summary>
        /// <param name="channelID">频道ID</param>
        /// <param name="memberID">成员ID</param>
        /// <param name="isblack">是否拉黑</param>
        public void CullGuildMember_(long channelID,long memberID, bool isblack = false)
        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("踢出频道成员").ToString());
            CullGuildMember sendmsg = (CullGuildMember)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(CullGuildMember));
            sendmsg(channelID, memberID, isblack);
            sendmsg = null;
        }

        /// <summary>
        /// 获取频道直播间信息
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public Struct_Guild_Room_Info GetChannelLiveRoomInfo_(long roomId)
        {
            Struct_Guild_Room_Info_EPD[] epds = new Struct_Guild_Room_Info_EPD[1];
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("获取频道直播间信息").ToString());
            GetChannelLiveRoomInfo sendmsg = (GetChannelLiveRoomInfo)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetChannelLiveRoomInfo));
            bool ret =sendmsg(roomId, ref epds);
            Struct_EArray_long sel = Marshal.PtrToStructure<Struct_EArray_long>(epds[0].struct_Guild_Room_Info_E.qq_list);
            Array.Resize(ref sel.ldata, sel.count);
            Struct_Guild_Room_Info gmi = new Struct_Guild_Room_Info() { fromCard = epds[0].struct_Guild_Room_Info_E.fromCard, name = epds[0].struct_Guild_Room_Info_E.name, roomid= epds[0].struct_Guild_Room_Info_E.roomid, rtmp= epds[0].struct_Guild_Room_Info_E.rtmp, tinyid= epds[0].struct_Guild_Room_Info_E.tinyid, unkown1= epds[0].struct_Guild_Room_Info_E.unkown1, qq_list= sel.ldata };
            sendmsg = null;
            return gmi;
        }

        /// <summary>
        /// 获取频道直播间信息2
        /// </summary>
        /// <param name="channelID">频道ID</param>
        /// <param name="roomId">子频道ID</param>
        /// <returns></returns>
        public Struct_Guild_Room_Info GetChannelLiveRoomInfo_2(long channelID, long roomId)
        {
            Struct_Guild_Room_Info_EPD[] epds = new Struct_Guild_Room_Info_EPD[1];
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("获取频道直播间信息2").ToString());
            GetChannelLiveRoomInfo1 sendmsg = (GetChannelLiveRoomInfo1)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetChannelLiveRoomInfo1));
            bool ret = sendmsg(channelID, roomId, ref epds);
            Struct_EArray_long sel = Marshal.PtrToStructure<Struct_EArray_long>(epds[0].struct_Guild_Room_Info_E.qq_list);
            Array.Resize(ref sel.ldata, sel.count);
            Struct_Guild_Room_Info gmi = new Struct_Guild_Room_Info() { fromCard = epds[0].struct_Guild_Room_Info_E.fromCard, name = epds[0].struct_Guild_Room_Info_E.name, roomid = epds[0].struct_Guild_Room_Info_E.roomid, rtmp = epds[0].struct_Guild_Room_Info_E.rtmp, tinyid = epds[0].struct_Guild_Room_Info_E.tinyid, unkown1 = epds[0].struct_Guild_Room_Info_E.unkown1, qq_list = sel.ldata };
            sendmsg = null;
            return gmi;
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool GetGuild_Live_Info1(long roomId, [MarshalAs(UnmanagedType.LPStr)] string unkown1, ref IntPtr[] data);

        /// <summary>
        /// 获取频道直播信息
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="unkown1"></param>
        /// <returns></returns>
        public Struct_Guild_Live_Info GetGuild_Live_Info_(long roomId, string unkown1)
        {
            Struct_Guild_Live_Info_E[] gli = new Struct_Guild_Live_Info_E[1];
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("获取频道直播信息").ToString());
            GetGuild_Live_Info sendmsg = (GetGuild_Live_Info)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetGuild_Live_Info));
            bool ret =sendmsg(roomId,unkown1,ref gli);
            Struct_Guild_Live_Info sgli = gli[0].struct_Guild_Live_Info;
            sendmsg = null;
            return sgli;
        }

        /// <summary>
        /// 获取子频道列表
        /// </summary>
        /// <param name="tiny_id"></param>
        /// <returns></returns>
        public List<Struct_guild_channel_info> GetSonChannelInfo_(long channelID)
        {
            Struct_EArray[] eArray = new Struct_EArray[1];
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("获取所有子频道").ToString());
            GetSonChannelInfo sendmsg = (GetSonChannelInfo)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetSonChannelInfo));
            bool ret = sendmsg(channelID, ref eArray);
            Array.Resize(ref eArray[0].ptrs, eArray[0].count);
            List<Struct_guild_channel_info> list = new List<Struct_guild_channel_info>();
            foreach (var item in eArray[0].ptrs)
            {
                Struct_guild_channel_info sgci = Marshal.PtrToStructure<Struct_guild_channel_info>(item);
                list.Add(sgci);
            }
            sendmsg = null;
            return list;
        }

        /// <summary>
        /// 取频道列表
        /// </summary>
        /// <returns></returns>
        public List<Struct_Guild_info> GetGuidlist_()
        {
            Struct_EArray[] eArray = new Struct_EArray[1];
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("取频道列表").ToString());
            GetGuidlist sendmsg = (GetGuidlist)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetGuidlist));
            bool ret = sendmsg(ref eArray);
            Array.Resize(ref eArray[0].ptrs, eArray[0].count);
            List<Struct_Guild_info> list = new List<Struct_Guild_info>();
            foreach (var item in eArray[0].ptrs)
            {
                Struct_Guild_info_E gie = Marshal.PtrToStructure<Struct_Guild_info_E>(item);
                Struct_Guild_info temp = new Struct_Guild_info() {
                    guildId=gie.guildId, 
                    createTime=gie.createTime, 
                    description=gie.description, 
                    guildName=gie.guildName, 
                    joinTime=gie.joinTime, 
                    num=gie.num, 
                    url=gie.url
                };
                Struct_EArray eArray1 = Marshal.PtrToStructure<Struct_EArray>(gie.channelList);
                Array.Resize(ref eArray1.ptrs, eArray1.count);
                List<Struct_guild_channel_info> list1 = new List<Struct_guild_channel_info>();
                foreach (var item2 in eArray1.ptrs)
                {
                    Struct_guild_channel_info sgci = Marshal.PtrToStructure<Struct_guild_channel_info>(item2);
                    list1.Add(sgci);
                }
                temp.channelList = list1;
                list.Add(temp);
            }
            sendmsg = null;
            return list;
        }
        #endregion
    }
}