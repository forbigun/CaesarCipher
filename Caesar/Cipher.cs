using System;

namespace Caesar
{
    class Cipher
    {
        const string ALPHABET = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        int k;
        public Cipher(int rotate)
        {
            if (rotate > 33)
                k = 33;
            else  k = rotate;
        }

        public string EncryptOrDecrypt(string text, bool encrypt)
        {
            int key = encrypt ? k : -k;
            string encText = "";
            int startIndex;
            int targetIndex;
            for (int i = 0; i < text.Length; i++)
            {
                startIndex = Array.IndexOf(ALPHABET.ToCharArray(), char.ToLower(text[i]));
                if(startIndex != -1)
                {
                    targetIndex = (33 + startIndex + key) % 33;
                    if (char.IsLower(text[i]))
                    {
                        encText += ALPHABET[targetIndex];
                    }
                    else
                    {
                        encText += char.ToUpper(ALPHABET[targetIndex]);
                    }
                }
                else
                {
                    encText += text[i];
                }
         
            }
            return encText;
        }

    }
}
