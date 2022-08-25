using System;
using System.Runtime.InteropServices;
using System.Threading;

[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);
void PreventMonitorPowerdown ()
{
    SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
}

void AllowMonitorPowerdown ()
{
    SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
}
void PreventSleep ()
{
    SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_AWAYMODE_REQUIRED);
}

void KeepSystemAwake ()
{
    SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED);
}
PreventMonitorPowerdown();
Console.WriteLine("Setting Kernel Power Parameters....");
while (true)
{
    PreventMonitorPowerdown();
    Console.WriteLine("Resetting Kernel Declarations - " + DateTime.Now.ToString("h:mm:ss tt"));
    Thread.Sleep(10000);
}