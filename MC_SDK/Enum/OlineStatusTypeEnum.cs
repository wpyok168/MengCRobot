using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_SDK.Enum
{
    /// <summary>
    /// 在线状态
    /// </summary>
    public enum OlineStatusTypeEnum
    {
        //11普通在线，50忙碌，31离开，60Q我叭，41隐身，70请勿打扰
        普通在线=11,
        忙碌=50, 
        离开 =31,
        Q我叭 =60, 
        隐身 =41, 
        请勿打扰 =70
    }
    /// <summary>
    /// 当type设置为11时有效
    /// </summary>
    public enum OlineStatusSubtypeEnum
    {
        //0普通在线，1000正在充电，1016睡觉中，1017游戏中，1018学习中，等等
        普通在线 = 0,
        正在充电=1000,
        睡觉中= 1016,
        游戏中= 1017,
        学习中= 1018
    }
}
