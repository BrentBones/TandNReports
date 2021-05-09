using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TandNTestMachine.Data.Constants
{
    public class AppDataKeys
    {
        public const string RoutePath = "RoutePath";
        public const string PLCType = "PLCType";
        public const string HelpWebAddress = "HelpWebAddress";

        public enum TagAddressType
        {
            Operation = 1,
            DataLogs = 2,
            ExecutingTest = 3
        }

        // Copy Protection
        public static string LicenseKey
        {
            get { return string.Format("LicenseKey-{0}", Environment.MachineName); }
        }
        public static string HardwareID
        {
            get { return string.Format("HardwareID-{0}", Environment.MachineName); }
        }
        public static string ActivationKey
        {
            get { return string.Format("ActivationKey-{0}", Environment.MachineName); }
        }
    }
}
