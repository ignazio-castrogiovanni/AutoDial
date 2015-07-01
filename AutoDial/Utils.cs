using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AutoDial
{
    public class Utils
    {
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter imgConv = new ImageConverter();
            return (byte[])imgConv.ConvertTo(img, typeof(byte[]));
        }
    }
}
