using System;

namespace EFcrud
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string path = @"C:\NET\VS19\EFtutorial\EFcrud\Data\StripsList.txt";
            StripManager SM = new StripManager();
            //SM.InitialiseerDatabank(path);
            //SM.ToonReeksen();
            //SM.ToonReeksenMetStrip();
            //SM.ToonStrips();
            //SM.ToonStripsInclude();
            //SM.ToonStripsFilter();
            //SM.ToonStripsIncludeAsNoTracking();
            //SM.UpdateStrip();
            SM.VerwijderStrip();
        }
    }
}
