using System;
using System.IO.Ports;

namespace Microsoft.Samples.Kinect.SkeletonBasics
{
    class CommManager
    {
        public static SerialPort ComPort;
        public String[] ports;
        public int baudRate = 9600;
        public int BaudRate
        {
            get
            {
                if (ComPort != null)
                    return ComPort.BaudRate;
                return 0;
            }
            set
            {
                if (ComPort != null)
                    ComPort.BaudRate = value;
            }
        }
        public CommManager()
        {
            ports = SerialPort.GetPortNames();
            ComPort = null;
        }
        public CommManager(String port)
        {
            ports = SerialPort.GetPortNames();
            if (ComPort != null && ComPort.PortName == port)
                return;
            else if (ComPort != null)
                ComPort.Close();
            ComPort = new SerialPort(port);
            try
            {
                ComPort.Open();
            }
            catch
            {

            }
            ComPort.WriteTimeout = 500;
        }
        public int write(byte [] array) {
            if (ComPort != null)
                ComPort.Write(array, 0, 7);
            else
                return 0;
            return -1;
        }
    }
}