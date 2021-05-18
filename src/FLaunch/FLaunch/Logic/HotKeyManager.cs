using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FLaunch.Logic
{
    /// <summary>
    /// Manage Hotkey
    /// </summary>
    internal class HotKeyManager
    {
        /// <summary>
        /// API dll name
        /// </summary>
        private const string DllName = "user32.dll";

        ///// <summary>
        ///// ModKey Alt
        ///// </summary>
        //private const int KeyAlt = 0x0001;
        /// <summary>
        /// ModKey Ctrl
        /// </summary>
        private const int KeyCtrl = 0x0002;
        /// <summary>
        /// ModKey Shift
        /// </summary>
        private const int KeyShift = 0x0004;

        /// <summary>
        /// MsgID
        /// </summary>
        internal const int MsgId = 0x312;

        /// <summary>
        /// HotkeyId
        /// </summary>
        internal const int HotKeyId = 0x02D2;

        /// <summary>
        /// Import RegisterHotKey
        /// </summary>
        /// <param name="hWnd">window handle</param>
        /// <param name="id">hotkey id</param>
        /// <param name="modKey">modkey</param>
        /// <param name="key">keycode</param>
        /// <returns></returns>
        [DllImport(DllName)]
        private static extern int RegisterHotKey(IntPtr hWnd, int id, uint modKey, uint key);
        /// <summary>
        /// Import UnregisterHotKey
        /// </summary>
        /// <param name="hWnd">window handle</param>
        /// <param name="id">hotkey id</param>
        /// <returns>result</returns>
        [DllImport(DllName)]
        private static extern int UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// Enable Hotkey
        /// </summary>
        /// <param name="handle">Handle</param>
        /// <returns>Result</returns>
        internal bool EnableHotkey(IntPtr handle)
        {
            uint key = (uint)Keys.H;
#if DEBUG
            key = (uint)Keys.J;
#endif
            return RegisterHotKey(handle, HotKeyId, KeyCtrl | KeyShift, key) != 0;
        }
        /// <summary>
        /// Disable Hotkey
        /// </summary>
        /// <param name="handle">Handle</param>
        /// <returns>Result</returns>
        internal bool DisableHotkey(IntPtr handle)
        {
            return UnregisterHotKey(handle, HotKeyId) != 0;
        }
    }
}
