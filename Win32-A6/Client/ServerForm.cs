using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class ServerForm : Form
    {
        // This delegate enables asynchronous calls for setting 
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);
       
        //accept thread
        Thread t;
        //send handler
        MySocket ServerSendHandler;
        MySocket ClientSendHandler;
        public ServerForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

       
        private void Connect_Click(object sender, EventArgs e)
        {
            MySocket s = new MySocket(ServerIPTxt.Text.ToString());
            Thread t = new Thread(new ThreadStart(s.acceptConn));
            s.OnSockMessage += new MessageDelegate(OnSockMessage);
            t.Start();
            ListenBtn.Enabled = false;
            ConnectBtn.Enabled = false;
        }
        private void UserName_TextChanged(object sender, EventArgs e)
        {

        }      
  
        private void send_Click(object sender, EventArgs e)
        {
            // send message here
            SendText();
        }

        private void SendText()
        {
            try
            {
                string[] tempArray = new string[outMsg.Lines.Length];
                tempArray = outMsg.Lines;

                for (int counter = 0; counter < tempArray.Length; counter++)
                {
                    if (tempArray[counter].Length > 0)
                    {
                        byte[] byteData = Encoding.ASCII.GetBytes(tempArray[counter]);
                        if (ClientSendHandler == null)
                        {
                            ServerSendHandler.Soc.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), ServerSendHandler);
                        }
                        else
                        {
                            ClientSendHandler.Soc.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), ClientSendHandler);
                        }
                    }
                    SetText("Me: " + tempArray[counter]);
                }

                // erase message after send
                outMsg.Clear();
            }
            catch (Exception ex)
            {
                SetText(ex.ToString());
            }
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;
                int byteSend = handler.EndSend(ar);               
            }
            catch (Exception ex)
            {
                SetText(ex.ToString());
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            
            
        }



        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.listBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                listBox1.Items.Add(text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySocket s = new MySocket(ServerIPTxt.Text.ToString());
            s.Connect();
            
        }

       

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (t != null)
            {
                t.Abort();
            }
            //if (ClientSendHandler == null)
            //{
            //    ServerSendHandler.Close();
            //}
            //else
            //{
            //    ClientSendHandler.Close();
            //}
        }

        private void OnSockMessage(object sender, SockEventArgs e)
        {
            SetText(e.SockMsg);
        }
    }
}
