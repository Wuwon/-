using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_Solution.Utils
{
    internal static class MiscUtils
    {
        public static void AddHotKey(Form form, Action function, Keys key, bool ctrl = false, bool shift = false, bool alt = false)
        {
            form.KeyPreview = true;
            form.KeyDown += delegate (object sender, KeyEventArgs e)
            {
                if (e.IsHotkey(key, ctrl, shift, alt))
                {
                    function();
                }
            };
        }

        public static bool IsHotkey(this KeyEventArgs eventData, Keys key, bool ctrl = false, bool shift = false, bool alt = false)
        {
            return eventData.KeyCode == key && eventData.Control == ctrl && eventData.Shift == shift && eventData.Alt == alt;
        }
        public static bool IsBitmaskOn(this int num, int bitmask)
        {
            return (num & bitmask) != 0;
        }
        public static void InvokeOnParent(this Control control, MethodInvoker method)
        {
            Control parent = control.Parent == null ? control : control.Parent;
            if (parent.IsHandleCreated)
            {
                parent.Invoke(method);
                return;
            }
        }
    }

}
