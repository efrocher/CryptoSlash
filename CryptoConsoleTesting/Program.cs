using BenchmarkDotNet.Running;
using CryptoSlash;

namespace CryptoConsoleTesting
{
    internal class Program
    {
        internal const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        internal const string TestText = "Cryptography prior to the modern age was effectively synonymous with encryption, converting readable information (plaintext) to unintelligible nonsense text (ciphertext), which can only be read by reversing the process (decryption). The sender of an encrypted (coded) message shares the decryption (decoding) technique only with intended recipients to preclude access from adversaries. The cryptography literature often uses the names \"Alice\" (or \"A\") for the sender, \"Bob\" (or \"B\") for the intended recipient, and \"Eve\" (or \"E\") for the eavesdropping adversary.[6] Since the development of rotor cipher machines in World War I and the advent of computers in World War II, cryptography methods have become increasingly complex and their applications more varied.\r\n\r\nModern cryptography is heavily based on mathematical theory and computer science practice; cryptographic algorithms are designed around computational hardness assumptions, making such algorithms hard to break in actual practice by any adversary. While it is theoretically possible to break into a well-designed system, it is infeasible in actual practice to do so. Such schemes, if well designed, are therefore termed \"computationally secure\"; theoretical advances (e.g., improvements in integer factorization algorithms) and faster computing technology require these designs to be continually reevaluated, and if necessary, adapted. Information-theoretically secure schemes that provably cannot be broken even with unlimited computing power, such as the one-time pad, are much more difficult to use in practice than the best theoretically breakable, but computationally secure, schemes.\r\n\r\nThe growth of cryptographic technology has raised a number of legal issues in the Information Age. Cryptography's potential for use as a tool for espionage and sedition has led many governments to classify it as a weapon and to limit or even prohibit its use and export.[7] In some jurisdictions where the use of cryptography is legal, laws permit investigators to compel the disclosure of encryption keys for documents relevant to an investigation.[8][9] Cryptography also plays a major role in digital rights management and copyright infringement disputes in regard to digital media.";

        static void Main(string[] args)
        {
            ICipher cipher = new Vigenere("BA")
            {
                AutoKey = true,
            };

            string encrypted = cipher.Encrypt(Alphabet);
            Console.WriteLine(encrypted);
            Console.WriteLine(cipher.Decrypt(encrypted));

            //BenchmarkRunner.Run(typeof(CryptoBenchmark));
        }
    }
}