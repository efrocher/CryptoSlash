﻿namespace CryptoSlash
{
    public interface ICipher
    {
        public string Encrypt(string message);

        public string Decrypt(string message);
    }
}
