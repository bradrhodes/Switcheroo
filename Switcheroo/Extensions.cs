using System.Collections.Generic;
using System.Linq;
using Switcheroo.Core;
using Switcheroo.Properties;

namespace Switcheroo
{
    public static class Extensions
    {
        public static bool IsPinnedToBottom(this AppWindowViewModel appWindow)
        {
            return GetPinnedToBottomList().Any<string>(p => string.Equals(p, appWindow.WindowTitle));
        }

        public static void PinToBottom(this AppWindowViewModel appWindow)
        {
            if (GetPinnedToBottomList().Any(p => string.Equals(p, appWindow.WindowTitle)))
                return;

            GetPinnedToBottomList().Add(appWindow.WindowTitle);
            SavePinnedToBottomList();
        }

        public static void UnpinFromBottom(this AppWindowViewModel appWindow)
        {
            if (!GetPinnedToBottomList().Any(p => string.Equals(p, appWindow.WindowTitle)))
                return;

            GetPinnedToBottomList().Remove(appWindow.WindowTitle);
            SavePinnedToBottomList();
        }

        private static List<string> GetPinnedToBottomList()
        {
            return Settings.Default.PinnedToBottom ?? new List<string>();
        }

        private static void SavePinnedToBottomList()
        {
            Settings.Default.Save();
        }
    }
}