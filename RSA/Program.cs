using System;
using System.Security.Cryptography;
using System.Text;

public class RSAEncryptionExample
{
    public static void Main(string[] args)
    {
        // Genera un nuevo par de claves RSA
        RSA rsa = RSA.Create();

        // Obtiene la clave pública y privada
        byte[] publicKey = rsa.ExportRSAPublicKey();
        byte[] privateKey = rsa.ExportRSAPrivateKey();

        // Texto plano a cifrar
        string plaintext = "Este es el texto plano a cifrar.";

        // Cifrado con clave pública
        byte[] ciphertext = EncryptWithPublicKey(plaintext, publicKey);
        Console.WriteLine($"Texto cifrado: {Convert.ToBase64String(ciphertext)}");

        // Descifrado con clave privada
        string decryptedText = DecryptWithPrivateKey(ciphertext, privateKey);
        Console.WriteLine($"Texto descifrado: {decryptedText}");
    }

    // Función para cifrar con clave pública
    public static byte[] EncryptWithPublicKey(string plaintext, byte[] publicKey)
    {
        using (RSA rsa = RSA.Create())
        {
            rsa.ImportRSAPublicKey(publicKey, out _);
            return rsa.Encrypt(Encoding.UTF8.GetBytes(plaintext), RSAEncryptionPadding.OaepSHA256);
        }
    }

    // Función para descifrar con clave privada
    public static string DecryptWithPrivateKey(byte[] ciphertext, byte[] privateKey)
    {
        using (RSA rsa = RSA.Create())
        {
            rsa.ImportRSAPrivateKey(privateKey, out _);
            return Encoding.UTF8.GetString(rsa.Decrypt(ciphertext, RSAEncryptionPadding.OaepSHA256));
        }
    }
}
