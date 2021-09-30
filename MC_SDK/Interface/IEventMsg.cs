using MC_SDK.Mode;

namespace MC_SDK.Interface
{
    /// <summary>
    /// 事件消息
    /// </summary>
    public interface IEventMsg
    {
        /// <summary>
        /// 事件消息
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        int EventMsgComply(EventMsg e);
    }
}
