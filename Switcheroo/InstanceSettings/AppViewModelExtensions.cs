using System;
using System.Collections.Generic;
using System.Linq;

namespace Switcheroo.InstanceSettings
{
    public static class AppViewModelExtensions
    {
        public static bool IsPinnedToBottom(this AppWindowViewModel appWindow)
        {
            return GetPinnedToBottomList().Any(ptr => (long)ptr == (long)appWindow.HWnd);
        }

        public static void PinToBottom(this AppWindowViewModel appWindow)
        {
            if (GetPinnedToBottomList().Any(ptr => (long)ptr == (long)appWindow.HWnd))
                return;

            GetPinnedToBottomList().Add(appWindow.HWnd);
        }

        public static void UnpinFromBottom(this AppWindowViewModel appWindow)
        {
            if (GetPinnedToBottomList().All(ptr => (long) ptr != (long) appWindow.HWnd))
                return;

            GetPinnedToBottomList().RemoveAll(ptr => (long) ptr == (long) appWindow.HWnd);
        }

        private static List<IntPtr> GetPinnedToBottomList()
        {
            return NonPersistedSettings.Default.PinnedToBottom;
        }
    }
}