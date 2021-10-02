using System.Runtime.InteropServices;

namespace MC_SDK.Struct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_GroupInfo
    {
        public long GroupUin; //长整数型
        public long GroupCode; //长整数型
        public long cFlag; //长整数型
        public long dwGroupInfoSeq; //长整数型
        public long dwGroupFlagExt; //长整数型
        public long dwGroupRankSeq; //长整数型
        public long dwCertificationType; //长整数型
        public long dwShutupTimestamp; //长整数型
        public long dwMyShutupTimestamp; //长整数型
        public long dwCmdUinUinFlag; //长整数型
        public long dwAdditionalFlag; //长整数型
        public long dwGroupTypeFlag; //长整数型
        public long dwGroupSecType; //长整数型
        public long dwGroupSecTypeInfo; //长整数型
        public long dwGroupClassExt; //长整数型
        public long dwAppPrivilegeFlag; //长整数型
        public long dwSubscriptionUin; //长整数型
        public long dwMemberNum; //长整数型
        public long dwMemberNumSeq; //长整数型
        public long dwMemberCardSeq; //长整数型
        public long dwGroupFlagExt3; //长整数型
        public long dwGroupOwnerUin; //长整数型
        public long cIsConfGroup; //长整数型
        public long cIsModifyConfGroupFace; //长整数型
        public long cIsModifyConfGroupName; //长整数型
        public long dwCmduinJoinTime; //长整数型
        public string strGroupName; //文本型; //; //; //群名
        public string strGroupMemo; //文本型
        public string strLable; //文本型; //; //; //群标签
        public string strDescribtion; //文本型; //; //; //资料介绍
        public long numpeople; //长整数型; //; //; //人数
        public long ummax; //长整数型; //; //; //最大人数
        public long createTimestamp; //长整数型; //; //; //创建时间
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct_GroupInfo_PA
    {
        public Struct_GroupInfo sg;
    }
}
