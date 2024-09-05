using System.Text;

namespace Utils 
{
    public static class StringExtension
    {

        private const byte StartAscii = 33;
        private const byte EndAscii = 126;

        private static char[,] CreateVigenereTable()
        {
        int totalCharacters = EndAscii - StartAscii + 1;
        char[,] vigenereTable = new char[totalCharacters + 1, totalCharacters + 1];

        for (int i = 1; i <= totalCharacters; i++)
        {
            char asciiValue = (char)(StartAscii + (i - 1));
            vigenereTable[0, i] = asciiValue;
            vigenereTable[i, 0] = asciiValue;
        }

        for (int i = 1; i <= totalCharacters; i++)
        {
            for (int j = 1; j <= totalCharacters; j++)
            {
                char asciiValue = (char)(StartAscii + ((i + j - 2) % totalCharacters));
                vigenereTable[i, j] = asciiValue;
            }
        }

        return vigenereTable;
        }

        private static string DecryptText(string encryptedText, string key)
        {
        StringBuilder decryptedText = new StringBuilder();
        int keyLength = key.Length;
        char[,] vigenereTable = CreateVigenereTable();
        int totalCharacters = EndAscii - StartAscii + 1;

        for (int i = 0; i < encryptedText.Length; i++)
        {
            char encryptedChar = encryptedText[i];
            char keyChar = key[i % keyLength];
            int row = 0, col = 0;

            for (int j = 1; j <= totalCharacters; j++)
            {
                if (vigenereTable[j, 0] == keyChar)
                {
                    row = j;
                    break;
                }
            }

            for (int j = 1; j <= totalCharacters; j++)
            {
                if (vigenereTable[row, j] == encryptedChar)
                {
                    col = j;
                    break;
                }
            }

            char decryptedChar = vigenereTable[0, col];
            decryptedText.Append(decryptedChar);
        }

        return decryptedText.ToString();
        }

        public static string DecryptText(this string encyrptText)
        {
            var totalText = "";

            for(int i = 0; i < encyrptText.Count(); i++)
            {
                if(i == 22)
                {
                    totalText += '"';
                }
                if(i == 63)
                {
                    totalText += '\\';
                }
                if(i == 78)
                {
                    totalText += '\\';
                }
                totalText += encyrptText[i]; 
            }

            return DecryptText(encryptedText: totalText, key: "connectionstringkey");
        }

    }

}