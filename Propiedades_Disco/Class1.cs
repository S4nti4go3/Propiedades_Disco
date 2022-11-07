using System;
using System.IO;
using System.Text;
using System.Linq;
using Microsoft.Win32;
using System.Management;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Propiedades_Disco
{
    public class Class1
    {
        public static string Serial_HDD()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive");
                foreach (ManagementObject queryObj in searcher.Get()) { return queryObj["SerialNumber"].ToString(); }
            }
            catch { return ""; }
            return "";
        }

        public static string targetasRed()
        {
            string nombres = "";
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters) { nombres += adapter.Description + "\n\n"; }
            return nombres;
        }

        public static string macAddress()
        {
            string nombres = "";
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters) { nombres += adapter.Description + ": " + adapter.GetPhysicalAddress() + "\n\n"; }
            return nombres;
        }

        public static string Serial_CD()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_CDROMDrive");
                foreach (ManagementObject queryObj in searcher.Get()) { return queryObj["SerialCD"].ToString(); }
            }
            catch { return "No hay instancias disponibles."; }
            return "No hay instancias disponibles.";
        }

    }
}
