using System;
using System.Dynamic;
using System.Runtime.InteropServices;//DllImport

using System.Threading;
using System.Diagnostics;//Process
public class MemoryHelper
{
    //在程序中用一个计时器，每隔几秒钟调用一次该函数，打开任务管理器，你会有惊奇的发现

    #region 内存回收
    [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
    public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
    /// <summary>
    /// 释放内存
    /// </summary>
    public static void ClearMemory_old()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
            //App 
            //App.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
        }
    }




    //网上大多推荐使用系统的SetProcessWorkingSetSize的函数API，但是经过实践发现并不好用。建议使用EmptyWorkingSet函数。
    [DllImport("psapi.dll")]
    static extern int EmptyWorkingSet(IntPtr hwProc);

    /// <summary>
    /// 释放内存
    /// </summary>
    public static void ClearMemory()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Process[] processes = Process.GetProcesses();
        foreach (Process process in processes)
        {
            //对于系统进程会拒绝访问，导致出错，此处对异常不进行处理。
            try
            {
                EmptyWorkingSet(process.Handle);
            }
            catch { }
        }
    }
    #endregion
}