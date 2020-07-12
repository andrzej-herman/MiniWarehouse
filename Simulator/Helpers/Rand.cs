using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Helpers
{
    public static class Rand
    {
        #region Private

        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        private static int GetRandom(int minimum, int maximum)
        {
            byte[] randomNumber = new byte[1];
            _generator.GetBytes(randomNumber);
            double asciiValueOfRandomChar = Convert.ToDouble(randomNumber[0]);
            double multiplier = Math.Max(0, (asciiValueOfRandomChar / 255d) - 0.00000000001d);
            int range = maximum - minimum + 1;
            double randomVAlueInRange = Math.Floor(multiplier * range);
            return (int)(minimum + randomVAlueInRange);
        }
        #endregion

        #region Public

        public static string GetRandomBatchNumber()
        {
            string result = string.Empty;
            for (int idx = 0; idx < 6; idx++)
            {
                result += GetRandom(0, 9).ToString();
            }

            return result;
        }

        public static int GetRandomPalletStateId()
        {
            var result = GetRandom(1, 30);
            return result == 10 ? 2 : result == 20 ? 3 : 1;
        }

        #endregion
    }
}
