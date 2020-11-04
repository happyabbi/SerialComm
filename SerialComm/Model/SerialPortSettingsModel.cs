using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Management;

namespace SerialComm.Model
{
    [Serializable]
    public class SerialPortSettingsModel : SingletonBase<SerialPortSettingsModel>
    {
        #region DataBits

        public int[] getDataBits = {5, 6, 7, 8};

        #endregion

        #region Comm. Port    

        public string DeviceID { get; set; }
        public string Description { get; set; }
        public string DeviceInfo { get; set; }

        public List<SerialPortSettingsModel> getCommPorts()
        {
            var devices = new List<SerialPortSettingsModel>();

            ManagementObjectCollection moc;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_SerialPort"))
            {
                moc = searcher.Get();
            }

            foreach (var device in moc)
                devices.Add(new SerialPortSettingsModel
                {
                    DeviceID = (string) device.GetPropertyValue("DeviceID"),
                    Description = (string) device.GetPropertyValue("Description"),
                    DeviceInfo = (string) device.GetPropertyValue("Description") + " (" +
                                 (string) device.GetPropertyValue("DeviceID") + ")"
                });

            moc.Dispose();
            return devices;
        }

        #endregion

        #region Baud Rate

        public string BaudRateName { get; set; }
        public int BaudRateValue { get; set; }

        public List<SerialPortSettingsModel> getBaudRates()
        {
            var returnBaudRates = new List<SerialPortSettingsModel>
            {
                new SerialPortSettingsModel {BaudRateName = "4800 baud", BaudRateValue = 4800},
                new SerialPortSettingsModel {BaudRateName = "9600 baud", BaudRateValue = 9600},
                new SerialPortSettingsModel {BaudRateName = "19200 baud", BaudRateValue = 19200},
                new SerialPortSettingsModel {BaudRateName = "38400 baud", BaudRateValue = 38400},
                new SerialPortSettingsModel {BaudRateName = "57600 baud", BaudRateValue = 57600},
                new SerialPortSettingsModel {BaudRateName = "115200 baud", BaudRateValue = 115200},
                new SerialPortSettingsModel {BaudRateName = "230400 baud", BaudRateValue = 230400}
            };
            return returnBaudRates;
        }

        #endregion

        #region Parity

        public string ParityName { get; set; }
        public Parity ParityValue { get; set; }

        public List<SerialPortSettingsModel> getParities()
        {
            var returnParities = new List<SerialPortSettingsModel>
            {
                new SerialPortSettingsModel {ParityName = "Even", ParityValue = Parity.Even},
                new SerialPortSettingsModel {ParityName = "Mark", ParityValue = Parity.Mark},
                new SerialPortSettingsModel {ParityName = "None", ParityValue = Parity.None},
                new SerialPortSettingsModel {ParityName = "Odd", ParityValue = Parity.Odd},
                new SerialPortSettingsModel {ParityName = "Space", ParityValue = Parity.Space}
            };
            return returnParities;
        }

        #endregion

        #region StopBits

        public string StopBitsName { get; set; }
        public StopBits StopBitsValue { get; set; }

        public List<SerialPortSettingsModel> getStopBits()
        {
            var returnStopBits = new List<SerialPortSettingsModel>
            {
                new SerialPortSettingsModel {StopBitsName = "None", StopBitsValue = StopBits.None},
                new SerialPortSettingsModel {StopBitsName = "One", StopBitsValue = StopBits.One},
                new SerialPortSettingsModel {StopBitsName = "OnePointFive", StopBitsValue = StopBits.OnePointFive},
                new SerialPortSettingsModel {StopBitsName = "Two", StopBitsValue = StopBits.Two}
            };
            return returnStopBits;
        }

        #endregion

        #region Line Ending

        public string LineEndingName { get; set; }
        public string LineEndingChars { get; set; }

        public List<SerialPortSettingsModel> getLineEndings()
        {
            var returnLineEndings = new List<SerialPortSettingsModel>
            {
                new SerialPortSettingsModel {LineEndingName = "No line ending", LineEndingChars = ""},
                new SerialPortSettingsModel {LineEndingName = "Newline", LineEndingChars = "\n"},
                new SerialPortSettingsModel {LineEndingName = "Carriage return", LineEndingChars = "\r"},
                new SerialPortSettingsModel {LineEndingName = "Both NL & CR", LineEndingChars = "\r\n"}
            };
            return returnLineEndings;
        }

        #endregion
    }
}