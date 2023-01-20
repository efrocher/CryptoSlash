using BenchmarkDotNet.Attributes;
using CryptoSlash;

namespace CryptoConsoleTesting
{
    public class CryptoBenchmark
    {
        private const string Message = Program.TestText;
        private const string Key = "THISISAGOODKEY";

        [Benchmark]
        public void DefaultVigenere()
        {
            string e = Vigenere.Encrypt(Message, Key);
            Vigenere.Decrypt(e, Key);
        }
    }
}
