using MC_SDK.Mode;

namespace MC_SDK.Interface
{
    /// <summary>
    /// 频道信息
    /// </summary>
    public interface IGuildMsg
    {
        /// <summary>
        /// 频道信息
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        int GuildMsgComply(GuildMsg e);
    }
}
