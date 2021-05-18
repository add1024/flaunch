using System;
using System.Drawing;

namespace FLaunch.Logic
{
    /// <summary>
    /// SettingEntity
    /// </summary>
    [Serializable]
    internal class AppSettings
    {
        /// <summary>
        /// Location
        /// </summary>
        internal Point WindowLocation { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        internal Size WindowSize { get; set; }
    }
}
