using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    public delegate void MessageDelegate(object sender, SockEventArgs e);

    public class SockEventArgs : EventArgs
    {
        private string msg;

        public SockEventArgs(string msg) : base()
        {
            this.msg = msg;
        }

        public string SockMsg
        {
            get { return msg; }
            set { msg = value; }
        }
    }

    class MySocket
    {
        // Thread signal.
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public Socket Soc;
        //Events Defination
        public event MessageDelegate OnSockMessage;
        //Variable
        private AddressFamily addressFamily;
        private SocketType socketType;
        private ProtocolType protocolType;
        private EndPoint remoteEP;

        public string outputText;

        public string targetIP;

        public MySocket()
        {

        }
        public MySocket(string ip)
        {
            targetIP = ip;
        }
        public MySocket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
        {
            Soc = new Socket(addressFamily, socketType, protocolType);
            this.addressFamily = addressFamily;
            this.socketType = socketType;
            this.protocolType = protocolType;
        }

        public void acceptConn()
        {
            try
            {
                IPAddress ipAddress = Dns.Resolve("localhost").AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP socket.
                Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //listen for clients
                listener.Bind(localEndPoint);
                listener.Listen(5);

                RaiseMessageEvent("Server IP: " + ipAddress.ToString());
                RaiseMessageEvent("Waiting for new client ...");

                while (true)
                {
                    allDone.Reset();
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    allDone.WaitOne();
                }

            }
            catch (Exception ex)
            {
                RaiseMessageEvent(ex.ToString());
            }

        }

        public void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                allDone.Set();
                // Get the socket that handles the client request.
                Socket listener = (Socket)ar.AsyncState;
                Socket handler = (Socket)listener.EndAccept(ar); ;

                
                int index = handler.RemoteEndPoint.ToString().IndexOf(":");
                RaiseMessageEvent("Connect to client: " + handler.RemoteEndPoint.ToString().Substring(0, index));

                // Create the state object
                StateObject state = new StateObject();
                state.workSocket = handler;

                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), state); 
            }
            catch (Exception ex)
            {
                RaiseMessageEvent(ex.ToString());
            }
        }

        

        //public void ReceiveData()
        //{
        //    try
        //    {
        //        // Create the state object
        //        StateObject state = new StateObject();
        //        Socket handler = state.workSocket;

        //        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), state); 
        //    }
        //    catch (Exception ex)
        //    {
        //        RaiseMessageEvent(ex.ToString());
        //        CloseSocket();
        //    }
        //}

        public void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                String content = String.Empty;

                // Get the socket that handles the client request.
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket;

                int bytesRead = handler.EndReceive(ar);
                //state.sb.Clear();
                if (bytesRead > 0)
                {
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    // Check for end-of-file tag. If it is not there, read 
                    // more data.
                    content = state.sb.ToString();
                    int index = handler.RemoteEndPoint.ToString().IndexOf(":");
                    RaiseMessageEvent(handler.RemoteEndPoint.ToString().Substring(0, index) + ":" + content);
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
                }
            }
            catch (Exception ex)
            {
                RaiseMessageEvent(ex.ToString());
                CloseSocket();
            }
        }

        public void Connect()
        {
            try
            {
                IPAddress ipAddress = Dns.Resolve(targetIP).AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP socket.
                Socket ClientSendHandler = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.
                ClientSendHandler.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), ClientSendHandler);
            }
            catch (Exception ex)
            {
                RaiseMessageEvent(ex.ToString());
            }
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket server = (Socket)ar.AsyncState;
                // Complete the connection.
                server.EndConnect(ar);
                RaiseMessageEvent("Connected to server" + server.RemoteEndPoint.ToString());

                // Create the state object
                StateObject state = new StateObject();
                state.workSocket = server;

                server.BeginReceive(state.buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), state); 
            }
            catch (Exception ex)
            {
                RaiseMessageEvent(ex.ToString());
            }
        }

        private void RaiseMessageEvent(string Msg)
        {
            SockEventArgs Args = new SockEventArgs("");
            Args.SockMsg = Msg;
            if (OnSockMessage != null)
            {
                OnSockMessage(this, Args);
            }
        }

        public void CloseSocket()
        {
            try
            {
                if (Soc != null)
                {
                    if (Soc.Connected)
                    {
                        Soc.Shutdown(SocketShutdown.Both);
                        Soc.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                RaiseMessageEvent(ex.ToString());
            }
        }
    }
}
