using Cafe_Solution.csForm;
using Cafe_Solution.Utils;
using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_Solution.Handlers
{
    internal class KeyboardHandler : IKeyboardHandler
    {
        MainForm myForm;
        public static List<SharpHotKey> Hotkeys = new List<SharpHotKey>();
        public static void AddHotKey(MainForm form, Action function, Keys key, bool ctrl = false, bool shift = false, bool alt = false)
        {
            MiscUtils.AddHotKey(form, function, key, ctrl, shift, alt);
            Hotkeys.Add(new SharpHotKey(function, key, ctrl, shift, alt));
        }

        public KeyboardHandler(MainForm form)
        {
            myForm = form;
        }
        public bool OnKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey)
        {
            if (type == KeyType.RawKeyDown)
            {


                // check if my hotkey
                int mod = ((int)modifiers);
                bool ctrlDown = mod.IsBitmaskOn((int)CefEventFlags.ControlDown);
                bool shiftDown = mod.IsBitmaskOn((int)CefEventFlags.ShiftDown);
                bool altDown = mod.IsBitmaskOn((int)CefEventFlags.AltDown);

                // per registered hotkey
                foreach (SharpHotKey key in Hotkeys)
                {
                    if (key.KeyCode == windowsKeyCode)
                    {
                        if (key.Ctrl == ctrlDown && key.Shift == shiftDown && key.Alt == altDown)
                        {
                            myForm.InvokeOnParent(delegate ()
                            {
                                key.Callback();
                            });
                        }
                    }
                }
            }
            return false;
        }

        public bool OnPreKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey, ref bool isKeyboardShortcut)
        {
            return false;
        }

    }
}

internal class SharpHotKey
{

    public Keys Key;
    public int KeyCode;
    public bool Ctrl;
    public bool Shift;
    public bool Alt;

    public Action Callback;

    public SharpHotKey(Action callback, Keys key, bool ctrl = false, bool shift = false, bool alt = false)
    {
        Callback = callback;
        Key = key;
        KeyCode = (int)key;
        Ctrl = ctrl;
        Shift = shift;
        Alt = alt;
    }
}

