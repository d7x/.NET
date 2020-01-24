using System;  
using System.IO;  
using System.Security.Cryptography;  
using System.Text;  
  
namespace EncryptionDecryptionUsingSymmetricKey  
{  
    public class Program  
    {  
		
		
	    public static void Main(string[] args)
		{
			var str_text_user = "4as8gqENn26uTs9srvQLyg=="; //16 bytes
			var str_text_password = "oQ5iORgUrswNRsJKH9VaCw=="; //16 bytes
			var str_key = "_5TL#+GWWFv6pfT3!GXw7D86pkRRTv+$$tk^cL5hdU%";
			Console.WriteLine(Decrypt(str_text_user,str_key));
			Console.WriteLine(Decrypt(str_text_password,str_key));

			
		}

				public static string Decrypt(string encodedText, string key)
			{
				TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
				MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();

				byte[] byteHash;
				byte[] byteBuff;

				byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
				desCryptoProvider.Key = byteHash;
				desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
				byteBuff = Convert.FromBase64String(encodedText);

				string plaintext = Encoding.UTF8.GetString(desCryptoProvider.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
				return plaintext;
			}
		}  
}  
