﻿using MC_SDK.Enum;
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
    public class API
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
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr OutputLog([MarshalAs(UnmanagedType.LPStr)] string message);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SendPrivateMsg(long QQ, [MarshalAs(UnmanagedType.LPStr)] string msg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SendGroupMsg(long GroupQQ, [MarshalAs(UnmanagedType.LPStr)] string msg,long otherQQ);
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
        /// <param name="QQ"></param>
        /// <param name="msg"></param>
        /// <param name="otherQQ"></param>
        /// <returns></returns>
        public string SendGroupMsg_(long QQ, string msg,long otherQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("发送群消息").ToString());
            SendGroupMsg sendmsg = (SendGroupMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendGroupMsg));
            string ret = Marshal.PtrToStringAnsi(sendmsg(QQ, msg, otherQQ));
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
        /// <param name="QQ"></param>
        /// <param name="msg"></param>
        /// <param name="otherQQ"></param>
        /// <returns></returns>
        public string SendGroupMsg_C(long QQ, string msg, long otherQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("发送群消息_纯文本").ToString());
            SendGroupMsg sendmsg = (SendGroupMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendGroupMsg));
            string ret = Marshal.PtrToStringAnsi(sendmsg(QQ, msg, otherQQ));
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
        public bool DelGroupMember_(long GroupQQ,long memberQQ, bool isRefuse)
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
        public void GroupVerificationEvent_(long GroupQQ,long triggerQQ, long msgSeq, GOperationTypeEnum OperationType, EventTypeEnum eventType, string reason="")
        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("处理群验证事件").ToString());
            GroupVerificationEvent sendmsg = (GroupVerificationEvent)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupVerificationEvent));
            sendmsg(GroupQQ, triggerQQ, msgSeq,(int)OperationType, (int)eventType, reason);
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
            FriendInfo_E fe = new FriendInfo_E() { 服务列表=ptr};
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
        public string SendFriendXmlMsg_(long QQ,string xmlcode)
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
        public string Audio2TXT_(string audiohash, string token,int waittime=5000)
        {
            int MsgAddress = int.Parse(JObject.Parse(apidata).SelectToken("语音转文本").ToString());
            Audio2TXT sendmsg = (Audio2TXT)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(Audio2TXT));
            string ret = Marshal.PtrToStringAnsi(sendmsg(audiohash, token, waittime));
            sendmsg = null;
            return ret;
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
    }
}
