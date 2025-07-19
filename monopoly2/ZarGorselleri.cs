using System.Drawing;
using System.IO;

namespace monopoly2
{
    public class ZarGorselleri
    {
        public static Image GetZarGorseli(int zar1, int zar2)
        {
            string zarResmi = $"zarlar/{zar1}_{zar2}.png";
            if (File.Exists(zarResmi))
            {
                return Image.FromFile(zarResmi);
            }
            return null;
        }
    }
} 