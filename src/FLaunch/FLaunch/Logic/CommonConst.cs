using System.Reflection;
using System.Windows.Forms;
using static System.IO.Path;

namespace FLaunch.Logic
{
    /// <summary>
    /// Consts
    /// </summary>
    internal static class CommonConst
    {
        /// <summary>
        /// Application name
        /// </summary>
        internal static readonly string AppName = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>
        /// Shortcut directory name
        /// </summary>
        private const string ShortcutDirName = "shortcut";

        /// <summary>
        /// Setting filename
        /// </summary>
        private const string SettingFileName = "setting";

        /// <summary>
        /// StartUpDir
        /// </summary>
        private static readonly string StartDir = Application.StartupPath + DirectorySeparatorChar;

        /// <summary>
        /// Shortcut directory fullpath
        /// </summary>
        internal static readonly string ShortcutDirFullPath = StartDir + ShortcutDirName;

        /// <summary>
        /// Setting file fullpath
        /// </summary>
        internal static readonly string SettingFileFullPath = StartDir + SettingFileName;
    }
}
