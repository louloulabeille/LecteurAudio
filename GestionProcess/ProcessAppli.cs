using System.Diagnostics;

namespace GestionProcess
{
    /// <summary>
    /// class qui gère qu'une seule appli qui est lancé
    /// </summary>
    public class ProcessAppli
    {
        /// <summary>
        /// méthode qui arrete le process s'il est déjà lancé
        /// </summary>
        /// <param name="process"></param>
        public static void ProcessStarted(Process process)
        {
            if (TestProcessLance(process))
            {
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// process qui verifie sur le Pc si le process est déjà lancé
        /// </summary>
        /// <param name="processTest"></param>
        /// <returns></returns>
        private static bool TestProcessLance(Process processTest)
        {
            Process[] ps = Process.GetProcesses();
            foreach (Process p in ps)
                if (processTest.Id != p.Id)
                    if (processTest.ProcessName == p.ProcessName)
                        return true;
            return false;
        }
    }
}