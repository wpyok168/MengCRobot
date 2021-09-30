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

        /// <summary>
        /// 输出日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="text_color"></param>
        /// <param name="background_color"></param>
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
        /// 上传群图片
        /// </summary>
        /// <param name="groupQQ"></param>
        /// <param name="picpath"></param>
        /// <returns></returns>
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
        /// <returns></returns>
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
