using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;
using Tesseract.ConsoleDemo;

namespace AutoDial
{
    public class ResultPrinter
    {
        readonly FormattedConsoleLogger logger;

        public ResultPrinter(FormattedConsoleLogger logger)
        {
            this.logger = logger;
        }

        public void Print(ResultIterator iter)
        {
            logger.Log("Is beginning of block: {0}", iter.IsAtBeginningOf(PageIteratorLevel.Block));
            logger.Log("Is beginning of para: {0}", iter.IsAtBeginningOf(PageIteratorLevel.Para));
            logger.Log("Is beginning of text line: {0}", iter.IsAtBeginningOf(PageIteratorLevel.TextLine));
            logger.Log("Is beginning of word: {0}", iter.IsAtBeginningOf(PageIteratorLevel.Word));
            logger.Log("Is beginning of symbol: {0}", iter.IsAtBeginningOf(PageIteratorLevel.Symbol));

            logger.Log("Block text: \"{0}\"", iter.GetText(PageIteratorLevel.Block));
            logger.Log("Para text: \"{0}\"", iter.GetText(PageIteratorLevel.Para));
            logger.Log("TextLine text: \"{0}\"", iter.GetText(PageIteratorLevel.TextLine));
            logger.Log("Word text: \"{0}\"", iter.GetText(PageIteratorLevel.Word));
            logger.Log("Symbol text: \"{0}\"", iter.GetText(PageIteratorLevel.Symbol));
        }
    }
}
