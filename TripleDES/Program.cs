using System;
using System.Security.Cryptography;

public class TripleDESExample
{
    public static void Main(string[] args)
    {
        // Clave y vector de inicialización (IV) para TripleDES
        byte[] key = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        byte[] iv = new byte[] { 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70, 0x80 };

        // Texto plano a cifrar
        string plaintext = "Este es el texto plano a cifrar.";

        // Cifrado con TripleDES
        byte[] ciphertext = EncryptTripleDES(plaintext, key, iv);
        Console.WriteLine($"Texto cifrado: {Convert.ToBase64String(ciphertext)}");

        // Descifrado con TripleDES
        string decryptedText = DecryptTripleDES(ciphertext, key, iv);
        Console.WriteLine($"Texto descifrado: {decryptedText}");
    }

    // Función para cifrar con TripleDES
    public static byte[] EncryptTripleDES(string plaintext, byte[] key, byte[] iv)
    {
        using (TripleDES tripleDES = TripleDES.Create())
        {
            tripleDES.Key = key;
            tripleDES.IV = iv;

            using (ICryptoTransform encryptor = tripleDES.CreateEncryptor())
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plaintext);
                        }
                        return ms.ToArray();
                    }
                }
            }
        }
    }

    // Función para descifrar con TripleDES
    public static string DecryptTripleDES(byte[] ciphertext, byte[] key, byte[] iv)
    {
        using (TripleDES tripleDES = TripleDES.Create())
        {
            tripleDES.Key = key;
            tripleDES.IV = iv;

            using (ICryptoTransform decryptor = tripleDES.CreateDecryptor())
            {
                using (MemoryStream ms = new MemoryStream(ciphertext))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
