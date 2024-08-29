using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAZA
{
    static internal class DPIFix
    {
        const int WinDefaultDPI = 96;

        /// <summary>
        /// Исправление блюра при включенном масштабировании в ОС windows 8 и выше
        /// </summary>
        public static void DpiFix()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }
        }

        /// <summary>
        /// WinAPI SetProcessDPIAware 
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        /// <summary>
        /// Исправление размера шрифтов
        /// </summary>
        /// <param name="c"></param>
        public static float DpiFixFonts(Control c)
        {
            Graphics g = c.CreateGraphics();
            float dx = g.DpiX
                , dy = g.DpiY
                , fontsScale = Math.Max(dx, dy) / WinDefaultDPI
            ;
            g.Dispose();
            return fontsScale;
        }

    }
}
