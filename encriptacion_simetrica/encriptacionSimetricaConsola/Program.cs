using System;
using System.IO;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

public class Program
{
    public static void Main()
    {
        string plainText = "Este es un texto para probar la fiabilidad de esta librería de encriptación llamada BouncyCastle.";
        string password = "pJj5D1ro4LzxQnh";

        // Generar una clave y un vector de inicialización (IV) desde la contraseña
        byte[] key = GenerateKey(password);
        byte[] iv = GenerateIV();

        // Texto sin encriptar
        Console.WriteLine("Texto sin encriptar: " + plainText);

        // Encriptar el texto
        byte[] cipherText = Encrypt(plainText, key, iv);
        Console.WriteLine("Texto cifrado: " + Convert.ToBase64String(cipherText));

        // Desencriptar el texto
        string decryptedText = Decrypt(cipherText, key, iv);
        Console.WriteLine("Texto descifrado: " + decryptedText);
    }

    static byte[] GenerateKey(string password)
    {
        var sha256 = new Sha256Digest();
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] key = new byte[sha256.GetDigestSize()];
        sha256.BlockUpdate(passwordBytes, 0, passwordBytes.Length);
        sha256.DoFinal(key, 0);
        return key;
    }

    static byte[] GenerateIV()
    {
        SecureRandom random = new SecureRandom();
        byte[] iv = new byte[16]; // AES block size is 16 bytes
        random.NextBytes(iv);
        return iv;
    }

    static byte[] Encrypt(string plainText, byte[] key, byte[] iv)
    {
        PaddedBufferedBlockCipher cipher = new PaddedBufferedBlockCipher(new CbcBlockCipher(new AesEngine()));
        cipher.Init(true, new ParametersWithIV(new KeyParameter(key), iv));

        byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] outputBytes = new byte[cipher.GetOutputSize(inputBytes.Length)];
        int length = cipher.ProcessBytes(inputBytes, 0, inputBytes.Length, outputBytes, 0);
        cipher.DoFinal(outputBytes, length);

        return outputBytes;
    }

    static string Decrypt(byte[] cipherText, byte[] key, byte[] iv)
    {
        PaddedBufferedBlockCipher cipher = new PaddedBufferedBlockCipher(new CbcBlockCipher(new AesEngine()));
        cipher.Init(false, new ParametersWithIV(new KeyParameter(key), iv));

        byte[] outputBytes = new byte[cipher.GetOutputSize(cipherText.Length)];
        int length = cipher.ProcessBytes(cipherText, 0, cipherText.Length, outputBytes, 0);
        cipher.DoFinal(outputBytes, length);

        return Encoding.UTF8.GetString(outputBytes).TrimEnd('\0');
    }
}
