using System;
using System.Windows.Forms;

namespace FLaunch.Logic
{
    /// <summary>
    /// Util
    /// </summary>
    internal static class CommonUtil
    {
        /// <summary>
        /// Out ExMessage
        /// </summary>
        /// <param name="ex">Exception</param>
        internal static void ShowMessage(Exception ex)
        {
            ShowMessage(ex.Message);
        }

        /// <summary>
        /// Wrap MessageBox
        /// </summary>
        /// <param name="msg">Message value</param>
        /// <param name="buttons">Buttons</param>
        /// <param name="icon">Icon</param>
        /// <param name="defaultButton">Default button</param>
        /// <returns>DialogResult</returns>
        internal static DialogResult ShowMessage(string msg,
                                                 MessageBoxButtons buttons = MessageBoxButtons.OK,
                                                 MessageBoxIcon icon = MessageBoxIcon.Information,
                                                 MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button2)
        {
            return MessageBox.Show(msg, CommonConst.AppName, buttons, icon, defaultButton);
        }
    }
}
