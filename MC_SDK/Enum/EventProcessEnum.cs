using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_SDK.Enum
{
    public enum EventProcessEnum
    {
        /// <summary>
        /// 阻止其他插件继续处理此事件(消息处理_拦截)
        /// </summary>
        消息处理_拦截 = 1,
        /// <summary>
        /// 允许其他插件继续处理此事件(消息处理_忽略)
        /// </summary>
        消息处理_忽略 = 0
    }
}
