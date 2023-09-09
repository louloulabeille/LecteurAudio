// See https://aka.ms/new-console-template for more information

using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main()
    {
        using Process process = new();
        process.StartInfo.FileName = Environment.CurrentDirectory + "\\LecteurAudio.exe";
        process.Start();
        
        if (TestProcessLance(process) )
        {
            process.Kill();
        }
        Process.GetCurrentProcess().Kill();

    }
    private static bool TestProcessLance (Process processTest)
    {
        Process[] ps = Process.GetProcesses();
        foreach (Process p in ps)
            if (processTest.Id != p.Id)
                if (processTest.ProcessName == p.ProcessName)
                    return true;
        return false;
    }
}