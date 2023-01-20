using System.Text;

namespace CryptoSlash
{
    public class Vigenere : ICipher
    {
        #region Properties
        private int[] KeyVals { get; set; }

        private string _key;
        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value.ToUpperLettersOnly();
                KeyVals = Key.ToKeyVals();
            }
        }

        public bool AutoKey { get; set; } = false;

        public bool KeepForeignChars { get; set; } = false;
        #endregion

        #region Constructors
        public Vigenere(string key)
        {
            Key = key;
        }
        #endregion

        #region Instance Methods
        public string Encrypt(string message)
        {
            message = message.ToUpperLettersOnly();
            int[] key = KeyVals.ToArray();

            if (key.Length == 0)
                return message;

            StringBuilder sb = new();
            int keyIndex = 0;
            foreach (char c in message)
            {
                // Chiffre le charactère courant
                char encoded = (char)(c + key[keyIndex]);
                if (encoded > 'Z')
                    encoded = (char)(encoded - 26);
                sb.Append(encoded);

                // Construction progressive de la clé si autokey
                if (AutoKey)
                    key[keyIndex] = c - Definitions.A_UTF16;

                // Avance dans la clé
                keyIndex++;
                if (keyIndex == key.Length)
                    keyIndex = 0;
            }

            return sb.ToString();
        }
        public string Decrypt(string encrypted)
        {
            encrypted = encrypted.ToUpperLettersOnly();
            int[] key = KeyVals.ToArray();

            if (key.Length == 0)
                return encrypted;

            StringBuilder sb = new();
            int keyIndex = 0;
            foreach (char c in encrypted)
            {
                // Chiffre le charactère courant
                char message = (char)(c - key[keyIndex]);
                if (message < 'A')
                    message = (char)(message + 26);
                sb.Append(message);

                // Construction progressive de la clé si autokey
                if (AutoKey)
                    key[keyIndex] = message - 'A';

                // Avance dans la clé
                keyIndex++;
                if (keyIndex == Key.Length)
                    keyIndex = 0;
            }

            return sb.ToString();
        }
        #endregion

        #region Static Methods
        public static string Encrypt(string message, string key)
        {
            return new Vigenere(key).Encrypt(message);
        }
        public static string Decrypt(string encrypted, string key)
        {
            return new Vigenere(key).Decrypt(encrypted);
        }
        #endregion
    }
}
