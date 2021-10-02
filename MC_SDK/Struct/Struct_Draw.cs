using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MC_SDK.Struct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_Draw
    {
        public int colorType; //整数型, , , 0为自定义颜色，801、802为彩虹和星空
        public string colorHex; //文本型
        public Struct_Sraw_Info struct_sraw_info;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_Sraw_Info
    {
        public float width; //小数型
        public float height; //小数型
        public int time; //整数型, , , 毫秒
    }
    public struct Struct_Draw_E
    {
        public int colorType; //整数型, , , 0为自定义颜色，801、802为彩虹和星空
        public string colorHex; //文本型
        public IntPtr struct_sraw_info;
    }
}
