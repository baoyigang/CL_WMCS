using System;
using System.Collections.Generic;
using System.Text;
using MCP;
 

namespace App.Dispatching
{
    public class TCPMessageParse : MCP.IProtocolParse
    {
        public Message Parse(string msg)
        {
            Message result = null;

            try
            {
                
                string Comd = "";
                string[] Rows = msg.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                for (int i = 0; i < Rows.Length; i++)
                {

                    string[] msgs = Rows[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (msgs.Length < 4)
                    {
                        msgs = new string[4];
                        msgs[0] = "";
                        msgs[1] = "";
                        msgs[2] = "";
                        msgs[3] = "";
                    }

                    Comd = msgs[0];
                    dictionary.Add("BillNo" + i.ToString(), msgs[1]);
                    dictionary.Add("Result" + i.ToString(), msgs[2]);
                    dictionary.Add("MSG" + i.ToString(), msgs[3]);


                }

                result = new Message(true, msg, Comd, dictionary);
            }
            catch
            {
                result = new Message(msg);
            }
            return result;
        }
    }
}