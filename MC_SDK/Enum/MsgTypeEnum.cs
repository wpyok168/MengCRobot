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
        临时消息=141,
        普通私聊消息=166,
        语音消息=208,
    }
}
