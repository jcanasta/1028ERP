using ERP.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Mobile
{
    internal class Config
    {
        #region Singleton

        private static readonly Config _instance = new Config();

        private Config()
        {

        }

        public static Config Instance => _instance;

        #endregion

        //public string APIUrl { get; set; } = "http://10.0.3.2:9008/api";
        public string APIUrl { get; set; } = "http://192.168.254.104:9008/api";

        public Auth Auth { get; set; }
    }
}
