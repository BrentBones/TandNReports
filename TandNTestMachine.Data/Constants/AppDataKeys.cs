using System;

namespace TandNTestMachine.Data.Constants
{
    public class AppDataKeys
    {
        public enum TagAddressType
        {
            Operation = 1,
            DataLogs = 2,
            ExecutingTest = 3
        }

        public const string RoutePath = "RoutePath";
        public const string PLCType = "PLCType";
        public const string HelpWebAddress = "HelpWebAddress";


        // IFD reports
        public const string CurrentCycleId = "CurrentCycleId";
        public const string IfdRecipeName = "IfdRecipeName";
        public const string IfdOperationName = "IfdOperationName";
        public const string DepressionOperationName = "DepressionOperationName";
        public const string ReadForceOperationName = "ReadForceOperationName";

        // Copy Protection
        public static string LicenseKey => $"LicenseKey-{Environment.MachineName}";

        public static string HardwareID => $"HardwareID-{Environment.MachineName}";

        public static string ActivationKey => $"ActivationKey-{Environment.MachineName}";
    }
}