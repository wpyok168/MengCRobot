using MC_Demo;
using MC_SDK.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace MengCRobot
{
    public static class RegisterCore
    {
        public static void Register(IUnityContainer unityContainer)
        {
            //unityContainer.RegisterType<IEnable, AppEnable>();
            unityContainer.RegisterType<IPrivateMsg, SendPrivateMsg>();
            unityContainer.RegisterType<IGroupMsg, SendGroupMsg>();
            //unityContainer.RegisterType<ISetting, OpenRobotMenu>();
            //unityContainer.RegisterType<IEventMsg, RobotEventcallBack>();
            //unityContainer.RegisterType<IDisable, RobotDisable>();
            //unityContainer.RegisterType<IUninit, RobotUninit>();
        }
    }
}
