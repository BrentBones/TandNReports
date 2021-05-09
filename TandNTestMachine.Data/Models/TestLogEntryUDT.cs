using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SIS7 = AutomatedSolutions.ASCommStd.SI.S7;


namespace TandNTestMachine.Data.Models
{
    [StructLayout(LayoutKind.Sequential)]
    public class TestLogEntryUDT : SIS7.Data.UDT
    {
        /// -------------------------------------------------------------------------------------
        /// Fields: Required
        /// Public fields define the structure that corresponds to a Step7 UDT
        /// -------------------------------------------------------------------------------------

        #region Fields

        /// <summary>
        /// 
        /// </summary>
        public Int32 elapsedTime;
        /// <summary>
        /// 
        /// </summary>
        public Single plateForce;
        /// <summary>
        /// 
        /// </summary>
        public Single plateHeight;
        /// <summary>
        /// 
        /// </summary>
        public Single vacuumPressure;
        /// <summary>
        /// 
        /// </summary>
        public Single vacuumFlow;

        #endregion Fields

        /// -------------------------------------------------------------------------------------
        /// Properties: Optional
        /// Properties have been added for ease of UI construction using .NET PropertyGrid 
        /// control in example application.
        /// It is not necessary to define Properties when accessing this class through code.
        /// -------------------------------------------------------------------------------------

        #region Properties

        /// <summary>
        /// Optional property, for UI convenience only
        /// </summary>
        public Int32 ElapsedTime
        {
            get { return elapsedTime; }
            set { elapsedTime = value; }
        }
        /// <summary>
        /// Optional property, for UI convenience only
        /// </summary>
        public Single PlateForce
        {
            get { return plateForce; }
            set { plateForce = value; }
        }
        /// <summary>
        /// Optional property, for UI convenience only
        /// </summary>
        public Single PlateHeight
        {
            get { return plateHeight; }
            set { plateHeight = value; }
        }
        /// <summary>
        /// Optional property, for UI convenience only
        /// </summary>
        public Single VacuumPressure
        {
            get { return vacuumPressure; }
            set { vacuumPressure = value; }
        }
        /// <summary>
        /// Optional property, for UI convenience only
        /// </summary>
        public Single VacuumFlow
        {
            get { return vacuumFlow; }
            set { vacuumFlow = value; }
        }

        #endregion Properties

    }
}
