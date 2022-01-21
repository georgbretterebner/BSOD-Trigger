using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

public class CriticalProcess
{
    [DllImport("ntdll.dll", SetLastError = true)]
    private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);

    static void Main(string[] args)
    {
        int isCritical = 1;  // we want this to be a Critical Process
        int BreakOnTermination = 0x1D;  // value for BreakOnTermination (flag)

        Process.EnterDebugMode();  //acquire Debug Privileges

        // setting the BreakOnTermination = 1 for the current process
        NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
    }
}