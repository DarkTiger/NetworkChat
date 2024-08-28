using System;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.IO;


namespace WFServerCHAT
{

    public partial class ClientChat : Form
    {

        bool canLoop = true;

        TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readData = null;
        string listaUtenti = "";
        bool inLettura = false;
        string logLEVEL = "DEBUG";
        LogClass log = new LogClass();

        public ClientChat()
        {
            InitializeComponent();
        }


        private void getMessage()
        {
            if (clientSocket.Connected)
            {
                while (canLoop)
                {
                    inLettura = true;

                    try
                    {
                        serverStream = clientSocket.GetStream();
                        int buffSize = 0;
                        byte[] inStream = new byte[clientSocket.ReceiveBufferSize];

                        buffSize = clientSocket.ReceiveBufferSize;
                        serverStream.Read(inStream, 0, buffSize);

                        string returndata = System.Text.Encoding.UTF8.GetString(inStream);

                        string messaggio = "";


                        if (returndata.Contains("[USERS]"))
                        {
                            listaUtenti = returndata;
                            listaUtenti = listaUtenti.Substring(returndata.IndexOf("[USERS]"), returndata.Length - returndata.IndexOf("[USERS]"));

                            messaggio = returndata;
                            messaggio = messaggio.Substring(0, returndata.IndexOf("[USERS]"));
                        }
                        else
                        {
                            messaggio = returndata.Replace(System.Environment.NewLine, "");
                            log.WriteLog(1, messaggio, logLEVEL);
                        }

                        readData = "" + messaggio.Replace("\n", "");

                        AddLogMessage();
                        AddUserInList();


                        if (!canLoop)
                        {
                            //byte[] outStream = System.Text.Encoding.UTF8.GetBytes("si è disconnesso]" + "ç@ç");
                            //serverStream.Write(outStream, 0, outStream.Length);
                            //serverStream.Flush();

                            clientSocket.GetStream().Close();
                            clientSocket.Close();
                            clientSocket.Client.Disconnect(false);
                        }
                    }
                    catch (Exception ex)
                    {
                        canLoop = false;
                        string exception = ex.Message;
                        MessageBox.Show("Host del server si è disconnesso!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        log.WriteLog(3, "Host del server si è disconnesso!", logLEVEL);
                    }
                }
            }
        }

        private void AddLogMessage()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(AddLogMessage));
            }
            else
            {
                if (readData != null && readData.Trim() != "")
                {
                    txtCorpoChat.Text += Environment.NewLine + readData;
                    log.WriteLog(1, readData, logLEVEL);
                }
            }
        }

        private void AddUserInList()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(AddUserInList));
            }
            else
            {
                string users = listaUtenti.Replace("[USERS]", "");
                users = users.Replace("[/USERS]", "");
                txtUsersList.Text = "";
                txtUsersList.Text = users;
            }
        }


        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text.Trim() != "")
            {
                if (clientSocket.Connected)
                {
                    byte[] outStream = System.Text.Encoding.UTF8.GetBytes(txtMessage.Text + "ç@ç");
                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();

                    txtMessage.Text = "";
                }
            }
        }

        private void btnConnectServer_Click(object sender, EventArgs e)
        {
            try
            {
                string ip1 = txtIPAddress1.Text.Trim();
                string ip2 = txtIPAddress2.Text.Trim();
                string ip3 = txtIPAddress3.Text.Trim();
                string ip4 = txtIPAddress4.Text.Trim();
                string port = txtPort.Text.Trim();

               // StreamReader sr = new StreamReader("ClientConf.ini");

                using (StreamReader reader = new StreamReader("ClientConf.ini"))
                {
                    reader.ReadLine();
                    reader.ReadLine();
                    logLEVEL = reader.ReadToEnd().Replace("logLEVEL=", "").Trim();
                    reader.Close();
                }


                if (logLEVEL != "DEBUG" && logLEVEL != "INFO" && logLEVEL != "WARN" && logLEVEL != "ERROR")
                {
                    MessageBox.Show("ATTENZIONE: logLEVEL nel file di configurazione errato!\n Impostato il livello 'DEBUG'", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    log.WriteLog(3, "ATTENZIONE: logLEVEL nel file di configurazione errato!\n Impostato il livello 'DEBUG'", logLEVEL);
                    logLEVEL = "DEBUG";
                }
 

                if (CheckAddressPart(ip1) && CheckAddressPart(ip2) && CheckAddressPart(ip3) && CheckAddressPart(ip4))
                {
                    if (CheckAddressPort(port))
                    {
                        AddLogMessage();
                        readData = "Connesso al Server di Chat ...";
                        clientSocket.Connect(ip1 + "." + ip2 + "." + ip3 + "." + ip4, Convert.ToInt32(txtPort.Text.Trim()));
                        serverStream = clientSocket.GetStream();

                        string nickName = txtNickname.Text;

                        if (nickName.Trim() == "")
                        {
                            Random randomNumber = new Random();
                            nickName = "Utente" + Convert.ToInt16(randomNumber.Next(1000, 9999));
                        }

                        byte[] outStream = System.Text.Encoding.UTF8.GetBytes(nickName + "ç@ç");
                        serverStream.Write(outStream, 0, outStream.Length);
                        serverStream.Flush();

                        Thread ctThread = new Thread(getMessage);
                        ctThread.Start();

                        if (clientSocket.Connected)
                        {
                            btnConnectServer.Text = "Connesso";

                            btnSendMessage.Enabled = true;
                            btnConnectServer.Enabled = false;
                            btnConnectServerConf.Enabled = false;
                            txtIPAddress1.Enabled = false;
                            txtIPAddress2.Enabled = false;
                            txtIPAddress3.Enabled = false;
                            txtIPAddress4.Enabled = false;
                            txtPort.Enabled = false;
                            txtCorpoChat.ReadOnly = true;
                            txtNickname.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Porta non valida", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        log.WriteLog(3, "Porta non valida", logLEVEL);
                    }
                }
                else
                {
                    MessageBox.Show("Indirizzo non valido", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    log.WriteLog(3, "Indirizzo non valido", logLEVEL);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Server non raggiungibile", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                log.WriteLog(3, "Server non raggiungibile", logLEVEL);
            }
        }

        private bool CheckAddressPart(string addressPart)
        {
            if (addressPart != "")
            {
                if ((addressPart.Length <= 3 && addressPart.Length >= 1) && (Convert.ToInt32(addressPart) >= 0 && Convert.ToInt32(addressPart) <= 255))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckAddressPort(string addressPort)
        {
            if (addressPort != "")
            {
                if (Convert.ToInt32(addressPort) >= 1024 && Convert.ToInt32(addressPort) <= 65535)
                {
                    return true;
                }
            }

            return false;
        }

        private void ClientChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            canLoop = false;
        }

        private void btnConnectServerConf_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("ClientConf.ini"))
                {
                    string totalIP;
                    string[] ip;
                    string port;
                    int intPort;
                    int intIP1;
                    int intIP2;
                    int intIP3;
                    int intIP4;

                    using (StreamReader reader = new StreamReader("ClientConf.ini"))
                    {
                        totalIP = reader.ReadLine();
                        ip = totalIP.Split('.');

                        port = reader.ReadLine().Replace("PORT=", "").Trim(); //ReadToEnd().Replace("PORT=","").Trim();
                        reader.Close();
                    }

                    string ip1 = ip[0].Replace("IP=","").Trim();
                    string ip2 = ip[1].Trim();
                    string ip3 = ip[2].Trim();
                    string ip4 = ip[3].Trim();


                    try
                    {
                        intPort = int.Parse(port);
                        intIP1 = int.Parse(ip1);
                        intIP2 = int.Parse(ip2);
                        intIP3 = int.Parse(ip3);
                        intIP4 = int.Parse(ip4);

                        if (intPort < 1024 || intPort > 65000)
                        {
                            MessageBox.Show("ATTENZIONE: impostazioni nel file di configurazione errate!\n\nE' stato impostato:\nIP: 172.0.0.1\nPORTA: 8888\n", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            log.WriteLog(3, "ATTENZIONE: impostazioni nel file di configurazione errate! E' stato impostato: IP: 172.0.0.1  PORTA: 8888", logLEVEL);
                            intPort = 8888;
                            ip1 = "127";
                            ip2 = "0";
                            ip3 = "0";
                            ip4 = "1";
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("ATTENZIONE: impostazioni nel file di configurazione errate!\n\nE' stato impostato:\nIP: 172.0.0.1\nPORTA: 8888\n", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        log.WriteLog(3, "ATTENZIONE: impostazioni nel file di configurazione errate! E' stato impostato: IP: 172.0.0.1  PORTA: 8888", logLEVEL);
                        intPort = 8888;
                        ip1 = "127";
                        ip2 = "0";
                        ip3 = "0";
                        ip4 = "1";
                    }


                    if (CheckAddressPart(ip1) && CheckAddressPart(ip2) && CheckAddressPart(ip3) && CheckAddressPart(ip4))
                    {
                        AddLogMessage();
                        readData = "Connesso al Server di Chat ...";
                        log.WriteLog(1, "Connesso al Server di Chat", logLEVEL);
                        clientSocket.Connect(ip1 + "." + ip2 + "." + ip3 + "." + ip4, intPort);
                        serverStream = clientSocket.GetStream();

                        string nickName = txtNickname.Text;

                        if (nickName.Trim() == "")
                        {
                            Random randomNumber = new Random();
                            nickName = "Utente" + Convert.ToInt16(randomNumber.Next(1000, 9999));
                        }

                        byte[] outStream = System.Text.Encoding.UTF8.GetBytes(nickName + "ç@ç");
                        serverStream.Write(outStream, 0, outStream.Length);
                        serverStream.Flush();

                        Thread ctThread = new Thread(getMessage);
                        ctThread.Start();

                        if (clientSocket.Connected)
                        {
                            btnConnectServer.Text = "Connesso";

                            btnSendMessage.Enabled = true;
                            btnConnectServer.Enabled = false;
                            btnConnectServerConf.Enabled = false;
                            txtIPAddress1.Enabled = false;
                            txtIPAddress2.Enabled = false;
                            txtIPAddress3.Enabled = false;
                            txtIPAddress4.Enabled = false;
                            txtPort.Enabled = false;
                            txtCorpoChat.ReadOnly = true;
                            txtNickname.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Indirizzo non valido", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        log.WriteLog(3, "Indirizzo non valido", logLEVEL);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Server non raggiungibile", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                log.WriteLog(3, "Server non raggiungibile", logLEVEL);
            }
        }

        private void ClientChat_Load(object sender, EventArgs e)
        {
            if (!File.Exists("ClientConf.ini"))
            {
                using (StreamWriter sw = new StreamWriter("ClientConf.ini"))
                {
                    sw.WriteLine("IP=127.0.0.1");
                    sw.WriteLine("PORT=8888");
                    sw.WriteLine("logLEVEL=DEBUG");
                    sw.Close();
                }
                log.WriteLog(2, "Creato file di configurazione", logLEVEL);
            }
        }
    }
}
