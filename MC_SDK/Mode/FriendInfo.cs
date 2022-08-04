using MC_SDK.Enum;
using MC_SDK.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MC_SDK.Mode
{
    /// <summary>
    /// 好友信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FriendInfo_E
    {
        public string 邮箱; //文本型; //; //; //自定义账号
        public long 账号; //长整数型
        public string 昵称; //文本型
        public string 备注; //文本型
        public string 在线状态; //文本型
        public int 赞数量; //整数型
        public string 签名; //文本型
        public SexEnum 性别; //整数型; //; //; //255隐藏 0男 1女
        public int Q等级; //整数型
        public int 年龄; //整数型
        public string 生日; //文本型
        public string 国家; //文本型
        public string 省份; //文本型
        public string 城市; //文本型
        public IntPtr 服务列表; //struct_service_info; //; //"1"
        public int 连续在线天数; //整数型; //; //; //连续在线天数
        public string QQ达人; //文本型; //; //; //qq达人
        public int 今日已赞; //整数型; //; //; //已赞
        public int 今日可赞数; //整数型; //; //; //可赞数
        public string 添加好友来源; //文本型; //; //; //添加来源
        public string 手机号码; //文本型
        public string 位置信息; //文本型; //; //; //位置信息
        public IntPtr 会话签名; //字节集; //; //; //会话签名
        public bool 查询结果; //逻辑型
        public string 所属; //文本型
    }
    /// <summary>
    /// 好友信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FriendInfo
    {
        public string 邮箱; //文本型; //; //; //自定义账号
        public long 账号; //长整数型
        public string 昵称; //文本型
        public string 备注; //文本型
        public string 在线状态; //文本型
        public int 赞数量; //整数型
        public string 签名; //文本型
        public SexEnum 性别; //整数型; //; //; //255隐藏 0男 1女
        public int Q等级; //整数型
        public int 年龄; //整数型
        public string 生日; //文本型
        public string 国家; //文本型
        public string 省份; //文本型
        public string 城市; //文本型
        public Struct_Service_Info 服务列表; //struct_service_info; //; //"1"
        public int 连续在线天数; //整数型; //; //; //连续在线天数
        public string QQ达人; //文本型; //; //; //qq达人
        public int 今日已赞; //整数型; //; //; //已赞
        public int 今日可赞数; //整数型; //; //; //可赞数
        public string 添加好友来源; //文本型; //; //; //添加来源
        public string 手机号码; //文本型
        public string 位置信息; //文本型; //; //; //位置信息
        public byte[] 会话签名; //字节集; //; //; //会话签名
        public bool 查询结果; //逻辑型
        public string 所属; //文本型
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FriendInfo_PA
    {
        public FriendInfo_E fie;
    }
    
}
