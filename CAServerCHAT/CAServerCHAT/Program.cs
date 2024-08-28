using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;


namespace CAClientCHAT
{
    class Program
    {
        public static Hashtable clientsList = new Hashtable();

        static void Main(string[] args)
        {
            LogClass log = new LogClass();
            
            int intPort;
            string logLEVEL = "DEBUG";


            if (!File.Exists("ServerConf.ini"))
            {
                using (StreamWriter sw = new StreamWriter("ServerConf.ini"))
                {
                    sw.WriteLine("PORT=8888");
                    sw.WriteLine("logLEVEL=DEBUG");
                    sw.Close();
                }
                log.WriteLog(2, "Creato file di configurazione", logLEVEL);
            }

            StreamReader sr = new StreamReader("ServerConf.ini");

            string port;
            
            using (StreamReader reader = new StreamReader("ServerConf.ini"))
            {
                port = reader.ReadLine();
                port = port.Substring(5).Trim();
                logLEVEL = reader.ReadToEnd().Replace("logLEVEL=","").Trim(); 
            }


            if (logLEVEL != "DEBUG" && logLEVEL != "INFO" && logLEVEL != "WARN" && logLEVEL != "ERROR")
            {
                Console.WriteLine("ATTENZIONE: logLEVEL nel file di configurazione errato!\n Impostato il livello 'DEBUG'");
                log.WriteLog(3, "ATTENZIONE: logLEVEL nel file di configurazione errato!\n Impostato il livello 'DEBUG'", logLEVEL);
                logLEVEL = "DEBUG";
            }


            try
            {
                intPort = int.Parse(port);

                if (intPort < 1024 || intPort > 65000)
                {
                    Console.WriteLine("ATTENZIONE: porta nel file di configurazione errata, deve essere compresa tra 1024 e 65000! \nE' statà impostata la porta: 8888\n");
                    log.WriteLog(3, "ATTENZIONE: porta nel file di configurazione errata, deve essere compresa tra 1024 e 65000! E' statà impostata la porta: 8888", logLEVEL);
                    intPort = 8888;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ATTENZIONE: porta nel file di configurazione errata! \nE' statà impostata la porta: 8888\n");
                log.WriteLog(3, "ATTENZIONE: porta nel file di configurazione errata! E' statà impostata la porta: 8888", logLEVEL);
                intPort = 8888;
            }


            try
            {
                TcpListener serverSocket = new TcpListener(intPort);
                TcpClient clientSocket = default(TcpClient);
                int counter = 0;

                serverSocket.Start();
                Console.WriteLine ("Server di Chat Pronto..");
                log.WriteLog(1, "Server di Chat Pronto..", logLEVEL);
                Console.WriteLine("");
                counter = 0;

                while (true)
                {
                    counter += 1;
                    clientSocket = serverSocket.AcceptTcpClient();

                    byte[] bytesFrom = new byte[clientSocket.ReceiveBufferSize];
                    string dataFromClient = null;

                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    dataFromClient = System.Text.Encoding.UTF8.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("ç@ç"));
                
                    clientsList.Add(dataFromClient, clientSocket);

                    broadcast("['" + dataFromClient + "' si è connesso] \n", dataFromClient, false);

                    Console.WriteLine("['" + dataFromClient + "' si è connesso]");
                    log.WriteLog(1, "['" + dataFromClient + "' si è connesso]", logLEVEL);
                    handleClinet client = new handleClinet();
                    client.logLEVEL = logLEVEL;
                    client.startClient(clientSocket, dataFromClient, clientsList);
                }
            }
            catch (Exception ex)
            {
                log.WriteLog(4, ex.Message, logLEVEL);
            }
        }

        public static void broadcast(string msg, string uName, bool flag)
        {
            string usernames = "[USERS]";
            List<DictionaryEntry> usersDisconnected = new List<DictionaryEntry>();
            
            foreach (DictionaryEntry Item in clientsList)
            {
                TcpClient broadcastSocket;
                broadcastSocket = (TcpClient)Item.Value;

                if (broadcastSocket.Client.Connected)
                {
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    NetworkStream broadcastStream2 = broadcastSocket.GetStream();
                    Byte[] broadcastBytes = null;
                    Byte[] broadcastBytes2 = null;

                    usernames += Item.Key.ToString() + Environment.NewLine;

                    if (flag == true)
                    {
                        broadcastBytes = Encoding.UTF8.GetBytes(uName + ": " + msg);
                    }
                    else
                    {
                        broadcastBytes = Encoding.UTF8.GetBytes(msg);
                    }

                    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    broadcastStream.Flush();

                    broadcastBytes2 = Encoding.UTF8.GetBytes(usernames + "[/USERS]");
                    broadcastStream2.Write(broadcastBytes2, 0, broadcastBytes2.Length);
                    broadcastStream2.Flush();
                }
                else
                {
                    usersDisconnected.Add(Item);
                }
            }

            for (int i = 0; i < usersDisconnected.Count; i++)
			{
                clientsList.Remove(usersDisconnected[i].Key);
                broadcast("['" + usersDisconnected[i].Key.ToString() + "' si è disconnesso] \n", "", false);
			}
        }  
    }


    public class handleClinet
    {
        LogClass log = new LogClass();

        TcpClient clientSocket;
        string clNo;
        public string logLEVEL { get; set; }
        Hashtable clientsList;

        public void startClient(TcpClient inClientSocket, string clNo, Hashtable cList)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clNo;
            this.clientsList = cList;
            Thread ctThread = new Thread(doChat);
            ctThread.Start();
        }

        private void doChat()
        {
            int requestCount = 0;
            byte[] bytesFrom = new byte[clientSocket.ReceiveBufferSize];
            string dataFromClient = null;
            string rCount = null;
            requestCount = 0;

            try
            {
                while (true)
                {
                    requestCount = requestCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    dataFromClient = System.Text.Encoding.UTF8.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("ç@ç"));
                    Console.WriteLine(clNo + ": " + dataFromClient);
                    log.WriteLog(1, clNo + ": " + dataFromClient, logLEVEL);
                    rCount = Convert.ToString(requestCount);


                    TcpClient broadcastSocket;
                    broadcastSocket = clientSocket;

                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    Byte[] broadcastBytes = null;

                    string usernames = "[USERS]";

                    foreach (DictionaryEntry Item in clientsList)
                    {
                        usernames += Item.Key.ToString() + Environment.NewLine;    
                    }

                    broadcastBytes = Encoding.UTF8.GetBytes(usernames + "[/USERS]");
                    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    broadcastStream.Flush();


                    Program.broadcast (dataFromClient, clNo, true);
                }
            }
            catch (Exception ex)
            {
                log.WriteLog(4, ex.Message, logLEVEL);
            }
        }
    } 
}
