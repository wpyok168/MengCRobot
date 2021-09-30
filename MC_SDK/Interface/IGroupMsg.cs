using MC_SDK.Mode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_SDK.Interface
{
    /// <summary>
    /// 群消息
    /// </summary>
    public interface IGroupMsg
    {
        /// <summary>
        /// 群消息
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        int GroupMsgComply(GroupMsg e);
    }
}
