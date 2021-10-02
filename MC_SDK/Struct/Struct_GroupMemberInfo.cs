using MC_SDK.Enum;
using System.Runtime.InteropServices;

namespace MC_SDK.Struct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_GroupMemberInfo
    {
        public string 账号; //文本型
        public int 年龄; //整数型
        public SexEnum 性别; //整数型; //; //; //255隐藏 0男 1女
        public string 昵称; //文本型
        public string 邮箱; //文本型
        public string 名片; //文本型; //; //; //无名片则为空
        public string 备注; //文本型
        public string 头衔; //文本型; //; //; //无专属头衔则为空
        public string 手机号; //文本型
        public long 头衔到期时间; //长整数型
        public long 解禁时间戳; //长整数型; //; //; //被禁言者何时会解除禁言
        public long 加群时间; //长整数型
        public long 发言时间; //长整数型
        public long 群等级; //长整数型
    }
}
