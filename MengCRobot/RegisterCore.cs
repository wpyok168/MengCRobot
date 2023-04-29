using MC_Demo;
using MC_SDK.Interface;
using Autofac;

namespace MengCRobot
{
    public static class RegisterCore
    {
        public static void Register(ContainerBuilder containerBuilder)
        {
            //containerBuilder.RegisterType<AppEnable>().As<IEnable>();
            containerBuilder.RegisterType<SendPrivateMsg>().As< IPrivateMsg>();
            containerBuilder.RegisterType<SendGroupMsg>().As<IGroupMsg>();
            //containerBuilder.RegisterType<OpenRobotMenu>().As<ISetting>();
            //containerBuilder.RegisterType<RobotEventcallBack>().As<IEventMsg>();
            //containerBuilder.RegisterType<RobotDisable>().As<IDisable>();
            //containerBuilder.RegisterType<RobotUninit>().As<IUninit>();
            containerBuilder.RegisterType<SendGuildMsg>().As<IGuildMsg>();
        }
    }
}
