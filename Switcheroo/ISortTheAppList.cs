using System;
using System.Collections.Generic;
using ManagedWinapi.Windows;

namespace Switcheroo
{
    public interface ISortTheAppList
    {
        List<AppWindowViewModel> Sort()  
    }

    public static class EnumerableOfAppWindowViewModelExtensions
    {
        public static List<AppWindowViewModel> Sort(this IEnumerable<AppWindowViewModel> windowList,
            WindowInfo foregroundWindowInfo)
        {
            var result = new List<AppWindowViewModel>();

            foreach (var appWindowViewModel in windowList)
            {
            }

        }
    }

    public static class AppViewModelExtensions
    {
        public static WindowInfo GetWindowInfo(this AppWindowViewModel windowViewModel)
        {
            return new WindowInfo(windowViewModel.AppWindow.HWnd, windowViewModel.AppWindow.Process.Id);
        }
    }

    public static class SystemWindowExtensions
    {
        public static WindowInfo GetWindowInfo(this SystemWindow window)
        {
            return new WindowInfo(window.HWnd, window.Process.Id);
        }
    }

    public static class WindowInfoExtensions
    {
        public static bool IsRelatedTo(this WindowInfo window1, WindowInfo window2)
        {
            return window1.HWnd == window2.HWnd || window1.ProcessId == window2.ProcessId;
        }
    }

    public class WindowInfo
    {
        public WindowInfo(IntPtr hWnd, int processId)
        {
            HWnd = hWnd;
            ProcessId = processId;
        }

        public IntPtr HWnd { get; }
        public int ProcessId { get; }
    }
}