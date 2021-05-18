using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static FLaunch.Logic.CommonConst;

namespace FLaunch.Logic
{
    /// <summary>
    /// Setting ReadWrite
    /// </summary>
    internal class SettingManager
    {
        /// <summary>
        /// Load
        /// </summary>
        /// <returns>LoadedSetting</returns>
        internal AppSettings Load()
        {
            if (!File.Exists(SettingFileFullPath)) return null;
            using (var fs = new FileStream(SettingFileFullPath, FileMode.Open, FileAccess.Read))
            {
                var file = new BinaryFormatter().Deserialize(fs);
                var stg = file as AppSettings;
                return stg;
            }
        }

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="setting">value</param>
        /// <returns>result</returns>
        internal bool Save(AppSettings setting)
        {
            var ret = false;
            using (var fs = new FileStream(SettingFileFullPath, FileMode.Create, FileAccess.Write))
            {
                new BinaryFormatter().Serialize(fs, setting);
                ret = true;
            }
            return ret;
        }
    }
}
