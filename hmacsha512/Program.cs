using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        string originalText = "Este es un mensaje secreto.";
        byte[] keyBytes = Encoding.UTF8.GetBytes("MiClaveMuySecreta123");

        try
        {
            byte[] encryptedBytes = EncryptStringToBytes_HMACSHA512(originalText, keyBytes);
            string encryptedText = Convert.ToBase64String(encryptedBytes);
            Console.WriteLine($"Texto cifrado: {encryptedText}");

            string decryptedText = DecryptStringFromBytes_HMACSHA512(encryptedBytes, keyBytes);
            Console.WriteLine($"Texto descifrado: {decryptedText}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static byte[] EncryptStringToBytes_HMACSHA512(string plainText, byte[] keyBytes)
    {
        using (HMACSHA512 hmac = new HMACSHA512(keyBytes))
        {
            byte[] encryptedBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(plainText));
            return encryptedBytes;
        }
    }

    static string DecryptStringFromBytes_HMACSHA512(byte[] cipherTextBytes, byte[] keyBytes)
    {
        using (HMACSHA512 hmac = new HMACSHA512(keyBytes))
        {
            byte[] decryptedBytes = hmac.ComputeHash(cipherTextBytes);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
