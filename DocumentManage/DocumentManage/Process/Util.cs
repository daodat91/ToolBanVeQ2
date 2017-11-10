using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DocumentManage
{
	public class Util
	{
		private static byte[] bytes = Encoding.ASCII.GetBytes("Security");

		public static string Decrypt(string cryptedString)
		{
			bool flag = cryptedString == null || cryptedString.Trim() == "";
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				try
				{
					DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
					MemoryStream stream = new MemoryStream(Convert.FromBase64String(cryptedString));
					CryptoStream stream2 = new CryptoStream(stream, dESCryptoServiceProvider.CreateDecryptor(Util.bytes, Util.bytes), CryptoStreamMode.Read);
					StreamReader streamReader = new StreamReader(stream2);
					result = streamReader.ReadToEnd();
				}
				catch (Exception var_6_64)
				{
					result = "";
				}
			}
			return result;
		}

		public static string Encrypt(string originalString)
		{
			bool flag = originalString == null || originalString.Trim() == "";
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				try
				{
					DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
					MemoryStream memoryStream = new MemoryStream();
					CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(Util.bytes, Util.bytes), CryptoStreamMode.Write);
					StreamWriter streamWriter = new StreamWriter(cryptoStream);
					streamWriter.Write(originalString);
					streamWriter.Flush();
					cryptoStream.FlushFinalBlock();
					streamWriter.Flush();
					result = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
				}
				catch (Exception)
				{
					result = "";
				}
			}
			return result;
		}
	}
}
