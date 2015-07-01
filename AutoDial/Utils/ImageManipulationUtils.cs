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
        private LogAndErrorsUtils m_logAndErrors;
        private GeneralUtils m_genUtils;

        public ImageManipulationUtils(LogAndErrorsUtils logAndErrors, bool m_bSaveImage = true)
        {
            m_logger = logAndErrors.getLogger();
        }

        public void saveGrayScaleImg(ref Bitmap imgToConvert, string dateImage)
        {
            m_logger.Debug("Start: Convert image to black and white");
            string strImgFileName = m_genUtils.generateImageFilename(dateImage);
           // if (System.IO.File.Exists(strImgFileName))
           // {
           //     Bitmap imgToConvert = (Bitmap)Image.FromFile(strImgFileName);
                Bitmap imgBlackAndWhite = convertToGrayScale(imgToConvert);

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

        private Bitmap convertToGrayScale(Bitmap Bmp)
        {

            m_logger.Debug("Start: GrayScale()");


            string captureLocationX = System.Configuration.ConfigurationManager.AppSettings["captureLocationX"];
            string captureLocationY = System.Configuration.ConfigurationManager.AppSettings["captureLocationY"];
            string captureWidth = System.Configuration.ConfigurationManager.AppSettings["captureWidth"];
            string captureHeight = System.Configuration.ConfigurationManager.AppSettings["captureHeight"];

            int startX = m_genUtils.convertStringToInt("captureLocationX", captureLocationX, m_logger);
            int startY = m_genUtils.convertStringToInt("captureLocationY", captureLocationY, m_logger);
            int width = m_genUtils.convertStringToInt("captureWidth", captureWidth, m_logger);
            int height = m_genUtils.convertStringToInt("captureHeight", captureHeight, m_logger);

            Bitmap OutputImage = new Bitmap(width, height);

            int rgb;
            Color c;

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    c = Bmp.GetPixel(x + startX, y + startY);
                    rgb = (int)(c.R * 0.21 + c.G * 0.72 + c.B * 0.07);
                    OutputImage.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            return OutputImage;
        }
    }
}
