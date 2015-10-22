using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

using NLog;

namespace AutoDial
{
    class ImageManipulationUtils
    {
        private Logger m_logger;
        private GeneralUtils m_genUtils;

        string m_captureLocationX = System.Configuration.ConfigurationManager.AppSettings["captureLocationX"];
        string m_captureLocationY = System.Configuration.ConfigurationManager.AppSettings["captureLocationY"];
        string m_captureWidth = System.Configuration.ConfigurationManager.AppSettings["captureWidth"];
        string m_captureHeight = System.Configuration.ConfigurationManager.AppSettings["captureHeight"];

        bool m_bSafeMode = false;

        public ImageManipulationUtils(LogAndErrorsUtils logAndErrors, bool m_bSaveImage = true)
        {
            m_logger = logAndErrors.getLogger();
            m_genUtils = new GeneralUtils(logAndErrors);
        }

        public void setSafeMode(bool bSafe) 
        {
            m_bSafeMode = bSafe;
            if (m_bSafeMode)
            {
               // m_logger.Debug("Safe mode enabled!");
               // m_captureHeight = (2 * Int32.Parse(m_captureHeight)).ToString();
               // m_logger.Debug("New height: {0}", m_captureHeight);
            }
        }
        public bool getSafeMode()
        {
            return m_bSafeMode;
        }

        public void saveBlackAndWhiteImg(ref Bitmap imgToConvert, string dateImage)
        {
            m_logger.Debug("Start: Convert image to black and white");
            string strImgFileName = m_genUtils.generateImageFilename(dateImage);
           // if (System.IO.File.Exists(strImgFileName))
           // {
           //     Bitmap imgToConvert = (Bitmap)Image.FromFile(strImgFileName);
                Bitmap imgBlackAndWhite = convertToBlackAndWhite(imgToConvert);
                if (imgBlackAndWhite == null)
                {
                    return;
                }

                string strBlackAndWhiteFilename = m_genUtils.generateImgBlackAndWhiteFilename(dateImage);
                m_logger.Debug("Saving image: " + strBlackAndWhiteFilename);

                imgBlackAndWhite.Save(strBlackAndWhiteFilename);
               
            // }
           // else
           // {
           //     m_logger.Error("saveBlackAndWhiteImgVersion() - File not found: " + strImgFileName);
           //     m_logAndErrors.errorPopup("File not found", "File not found" + strImgFileName + " See the log for more details.");
           // }
   
   }

        private Bitmap convertToBlackAndWhite(Bitmap Bmp)
        {            m_logger.Debug("Start: GrayScale()");

            int startX = m_genUtils.convertStringToInt("captureLocationX", m_captureLocationX, m_logger);
            int startY = m_genUtils.convertStringToInt("captureLocationY", m_captureLocationY, m_logger);
            int width = m_genUtils.convertStringToInt("captureWidth", m_captureWidth, m_logger);
            int height = m_genUtils.convertStringToInt("captureHeight", m_captureHeight, m_logger);

            if (m_bSafeMode)
            {
                height = height * 2;
            }
            Bitmap OutputImage = new Bitmap(width, height);

            int rgb;
            Color c;

            // Check for image size
            int colourBmpWidth = Bmp.Width;
            int colourBmpHeight = Bmp.Height;

            if (((startX + width - 1) > colourBmpWidth) || ((startY + height  - 1) > colourBmpHeight)) 
            {
                m_logger.Debug("Wrong size of the original image. Probably couldn,t capture it.");
                return null;
            }


            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    c = Bmp.GetPixel(x + startX, y + startY);
                    rgb = (int)(c.R * 0.21 + c.G * 0.72 + c.B * 0.07);
                    System.Drawing.Color colourBlackOrWhite = (rgb <= 127) ? Color.Black : Color.White;

                    OutputImage.SetPixel(x, y, colourBlackOrWhite);
                    //OutputImage.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            return OutputImage;
        }
    }
}
