using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace DocumentManage
{
	public class ProcessConfigXML
	{
		public static string LoadData(string strKey)
		{
			Config2XMLFile config2XMLFile = new Config2XMLFile(Application.StartupPath + "\\Data\\ConfigData.xml", "config", "key", "value", "user");
			return config2XMLFile.Load(strKey);
		}

		public static bool SaveData(string strKey, string strValue)
		{
			Config2XMLFile config2XMLFile = new Config2XMLFile(Application.StartupPath + "\\Data\\ConfigData.xml", "config", "key", "value", "user");
			return config2XMLFile.Save(strKey, strValue);
		}

		public static string Dictionary2ConfigString(Dictionary<string, object> inDic)
		{
			bool flag = inDic == null;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (KeyValuePair<string, object> current in inDic)
				{
					string arg = string.Empty;
					bool flag2 = current.Value.GetType() == typeof(bool);
					if (flag2)
					{
						arg = (((bool)current.Value) ? "true" : "false");
					}
					else
					{
						bool flag3 = current.Value.GetType() == typeof(DateTime);
						if (flag3)
						{
							arg = ((DateTime)current.Value).ToString("yyyy-MM-dd hh:mm:ss.fff");
						}
						else
						{
							arg = current.Value.ToString();
						}
					}
					stringBuilder.AppendFormat("{0}={1};", current.Key, arg);
				}
				result = stringBuilder.ToString();
			}
			return result;
		}

		public static Dictionary<string, object> ConfigString2Dictionary(string configString, Dictionary<string, object> temp)
		{
			bool flag = string.IsNullOrEmpty(configString);
			Dictionary<string, object> result;
			if (flag)
			{
				result = temp;
			}
			else
			{
				string text = configString.ToUpper();
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				foreach (KeyValuePair<string, object> current in temp)
				{
					int length = current.Key.Length;
					string text2 = string.Empty;
					int num = configString.IndexOf(current.Key);
					bool flag2 = num == -1;
					if (flag2)
					{
						num = text.IndexOf(current.Key.ToUpper());
					}
					bool flag3 = num > -1;
					if (flag3)
					{
						int num2 = configString.IndexOf(";", num + length + 1);
						bool flag4 = num2 > -1;
						if (flag4)
						{
							text2 = configString.Substring(num + length + 1, num2 - num - length - 1);
						}
						else
						{
							text2 = configString.Substring(num + length + 1);
						}
					}
					bool flag5 = current.Value.GetType() == typeof(int);
					if (flag5)
					{
						dictionary.Add(current.Key, int.Parse(text2));
					}
					else
					{
						bool flag6 = current.Value.GetType() == typeof(bool);
						if (flag6)
						{
							bool flag7 = text2.ToUpper() == "TRUE";
							if (flag7)
							{
								dictionary.Add(current.Key, true);
							}
							else
							{
								dictionary.Add(current.Key, false);
							}
						}
						else
						{
							bool flag8 = current.Value.GetType() == typeof(DateTime);
							if (flag8)
							{
								DateTime dateTime = DateTime.MinValue;
								try
								{
									dateTime = DateTime.ParseExact(text2, "yyyy-MM-dd hh:mm:ss.fff", CultureInfo.InvariantCulture);
								}
								catch
								{
									dateTime = DateTime.MinValue;
								}
								dictionary.Add(current.Key, dateTime);
							}
							else
							{
								dictionary.Add(current.Key, text2);
							}
						}
					}
				}
				result = dictionary;
			}
			return result;
		}
	}
}
