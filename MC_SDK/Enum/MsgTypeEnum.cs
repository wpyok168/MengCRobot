using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_SDK.Enum
{
    public enum MsgTypeEnum
    {
        //141 为临时消息 166为普通私聊消息 208语音消息
        语音消息=208,
        临时会话_公众号 = 129,
        临时会话_验证消息 = 134,
        临时会话_群临时 = 141,
        临时会话_网页QQ咨询 = 201,
        好友通常消息 = 166,
    }
}
