using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encartonneuse
{
    class CarteES
    {
        static SerialPort USB_PORT;
        byte usb_opto_rly88_found = 0;
        byte[] SerBuf = new byte[10];

        public void Init()
        {
            USB_PORT = new SerialPort();

            if (USB_PORT.IsOpen)
            {
                USB_PORT.Close();
            }// close any existing handle


            USB_PORT.PortName = "COM4";    // retrieves "COMx" from selection in combo box
            USB_PORT.Parity = 0;
            USB_PORT.BaudRate = 19200;
            USB_PORT.StopBits = StopBits.Two;
            USB_PORT.DataBits = 8;
            USB_PORT.ReadTimeout = 50;
            USB_PORT.WriteTimeout = 50;
            USB_PORT.Open();

            SerBuf[0] = 0x5A;       // get version command for RLY16, returns module id and software version
            transmit(1);
            receive(2);

            if (SerBuf[0] == 12)  // if the module id is that of the usb-opto-rly88  
            {
                //textBox_ver.Text = string.Format("{0}", SerBuf[1]);  //print the software version on screen
                usb_opto_rly88_found = 1;                            // and set the usb-i2c found indicator
            }
            Task t1 = new Task(async () =>
            {
                while (true)
                {
                    await Task.Delay(10);
                    if (USB_PORT.IsOpen)
                    {
                        GetInputeStates();
                    }
                    else
                    {
                        USB_PORT.Close();
                        MessageBox.Show("Connexion à la carte E/S perdue, Veuillez verifier les branchement puis cliquez sur OK.");
                    }
                    while (USB_PORT.IsOpen == false)
                    {
                        try
                        {
                            USB_PORT.PortName = "COM7";    // retrieves "COMx" from selection in combo box
                            USB_PORT.Parity = 0;
                            USB_PORT.BaudRate = 19200;
                            USB_PORT.StopBits = StopBits.Two;
                            USB_PORT.DataBits = 8;
                            USB_PORT.ReadTimeout = 50;
                            USB_PORT.WriteTimeout = 50;
                            USB_PORT.Open();
                            MessageBox.Show("Connexion à la carte ES retrouvée.");
                        }
                        catch { }
                    }
                }
            });
            t1.Start();
        }

        public async void Relay(int i, bool status)
        {
            byte x = 0x00;
            switch (i)
            {
                case 1:
                    if (status) { x = 0x65; } else { x = 0x6F; }
                    break;
                case 2:
                    if (status) { x = 0x66; } else { x = 0x70; }
                    break;
                case 3:
                    if (status) { x = 0x67; } else { x = 0x71; }
                    break;
                case 4:
                    if (status) { x = 0x68; } else { x = 0x72; }
                    break;
                case 5:
                    if (status) { x = 0x69; } else { x = 0x73; }
                    break;
                case 6:
                    if (status) { x = 0x6A; } else { x = 0x74; }
                    break;
                case 7:
                    if (status) { x = 0x6B; } else { x = 0x75; }
                    break;
                case 8:
                    if (status) { x = 0x6C; } else { x = 0x76; }
                    break;
                default:
                    break;
            }
            await Task.Delay(100);
            SerBuf[0] = (byte)x;
            transmit(1);
        }

        public bool input1 = false, input2 = false, input3 = false, input4 = false, input5 = false, input6 = false, input7 = false, input8 = false;
        private void GetInputeStates()
        {
            SerBuf[0] = 0x19;       // get input states command
            transmit(1);
            receive(1);
            if ((SerBuf[0] & 0x01) == 0) input1 = false; else input1 = true;
            if ((SerBuf[0] & 0x02) == 0) input2 = false; else input2 = true;
            if ((SerBuf[0] & 0x04) == 0) input3 = false; else input3 = true;
            if ((SerBuf[0] & 0x08) == 0) input4 = false; else input4 = true;
            if ((SerBuf[0] & 0x10) == 0) input5 = false; else input5 = true;
            if ((SerBuf[0] & 0x20) == 0) input6 = false; else input6 = true;
            if ((SerBuf[0] & 0x40) == 0) input7 = false; else input7 = true;
            if ((SerBuf[0] & 0x80) == 0) input8 = false; else input8 = true;
        }

        private void transmit(byte write_bytes)
        {
            try
            {
                USB_PORT.Write(SerBuf, 0, write_bytes);      // writes specified amount of SerBuf out on COM port
            }
            catch (Exception)
            {
                MessageBox.Show("L'envoi de données à échoué !" + Environment.NewLine + "Cette erreur peu être due à une deconnexion de la carte Entrée/Sortie.", "Erreur d'envoi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void receive(byte read_bytes)
        {
            byte x;

            for (x = 0; x < read_bytes; x++)       // this will call the read function for the passed number times, 
            {                                      // this way it ensures each byte has been correctly recieved while
                try                                // still using timeouts
                {
                    USB_PORT.Read(SerBuf, x, 1);     // retrieves 1 byte at a time and places in SerBuf at position x
                }
                catch (Exception)                   // timeout or other error occured, set lost comms indicator
                {
                    MessageBox.Show("La réception de données à échoué !" + Environment.NewLine + "Cette erreur peu être due à une deconnexion de la carte Entrée/Sortie.", "Erreur de reception", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    SerBuf[0] = 255;
                    usb_opto_rly88_found = 0;
                }
            }
        }

        public void all_OFF()
        {
            for (int i = 0; i <= 8; i++)
            {
                Relay(i, false);
            }
        }
    }
}