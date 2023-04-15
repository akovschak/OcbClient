using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OcbClient
{
    public class OcbClient
    {

        public OcbClient()
        {
        }

        public bool Connect()
        {
            return false;
        }

        public bool Disconnect()
        {
            return false;
        }


        public bool AddLine(string line)
        {

            return false;
        }

        public bool InsertLine(string line, int lineNumber)
        {
            return false;
        }

        public bool DeleteLine(int lineNumber)
        {
            return false;
        }

        public bool ModifyLine(string line, int lineNumber)
        {
            return false;
        }

        public bool Clear()
        {
            return false;
        }

        //public bool SetState(StateEnum);
        public bool ChangeImage(string imageName)
        {
            return false;
        }

        public bool SetTax(string tax)
        {
            return false;
        }

        public bool SetTotal(string total)
        {
            return false;
        }

        public bool SetTaxAndTotal(string tax, string total)
        {
            return false;
        }

        public bool SetSubtotal(string subtotal)
        {
            return false;
        }

        public bool SetScrollMessage(string message)
        {
            return false;
        }


    }
}
