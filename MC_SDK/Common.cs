﻿using MC_SDK.Croe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Builder;

namespace MC_SDK
{
    public static class Common
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        public static Autofac.IContainer Container { get; set; }
        public static Autofac.ContainerBuilder CBuilder { get; set; }
        public static API MC_API { get => mC_API;  }

        /// <summary>
        /// 萌尘API 
        /// </summary>
        private static API mC_API = new API();

        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="log"></param>
        public static void BugLog(string log)
        {
            string logpath = API.app_PluginDataDirectory + "MC_Logs";
            if (!Directory.Exists(logpath))
            {
                Directory.CreateDirectory(logpath);
            }
            File.AppendAllText(logpath + "\\log.txt", log + "\n");
        }
    }
}
