using System;
using System.Xml;

namespace DocumentManage
{
	public class Config2XMLFile
	{
		private string _filePath;

		private string _tableName;

		private string _keyField;

		private string _valueField;

		private string _currentUserField;

		private XmlNode getNodeConfig(XmlDocument doc, string sName, string sCurrentUser)
		{
			string xpath = string.Format("/{0}s/{0}[@{1}='{2}']", this._tableName, this._keyField, sName);
			bool flag = !string.IsNullOrEmpty(sCurrentUser);
			if (flag)
			{
				xpath = string.Format("/{0}s/{0}[@{1}='{2}' and  @{3}='{4}']", new object[]
				{
					this._tableName,
					this._keyField,
					sName,
					this._currentUserField,
					sCurrentUser
				});
			}
			bool flag2 = doc == null;
			if (flag2)
			{
				doc = new XmlDocument();
				doc.Load(this._filePath);
			}
			return doc.DocumentElement.SelectSingleNode(xpath);
		}

		public Config2XMLFile(string filePath, string tableName, string keyField, string valueField, string currentUserField)
		{
			this._filePath = filePath;
			this._tableName = tableName;
			this._keyField = keyField;
			this._valueField = valueField;
			this._currentUserField = currentUserField;
		}

		public bool Delete(string sName)
		{
			return this.DeleteCurrentUser(sName, string.Empty);
		}

		public bool DeleteCurrentUser(string sName, string sCurrentUser)
		{
			bool result = false;
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(this._filePath);
				XmlNode nodeConfig = this.getNodeConfig(xmlDocument, sName, sCurrentUser);
				bool flag = nodeConfig != null;
				if (flag)
				{
					xmlDocument.DocumentElement.RemoveChild(nodeConfig);
					xmlDocument.Save(this._filePath);
					result = true;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
			}
			return result;
		}

		public string Load(string sName)
		{
			return this.LoadCurrentUser(sName, string.Empty);
		}

		public string LoadCurrentUser(string sName, string sCurrentUser)
		{
			string result = string.Empty;
			try
			{
				using (XmlReader xmlReader = XmlReader.Create(this._filePath))
				{
					while (xmlReader.Read())
					{
						bool flag = !string.IsNullOrEmpty(sCurrentUser);
						if (flag)
						{
							bool flag2 = xmlReader.GetAttribute(this._keyField) == sName && xmlReader.GetAttribute(this._currentUserField) == sCurrentUser;
							if (flag2)
							{
								result = xmlReader.GetAttribute(this._valueField);
								break;
							}
						}
						else
						{
							bool flag3 = xmlReader.GetAttribute(this._keyField) == sName;
							if (flag3)
							{
								result = xmlReader.GetAttribute(this._valueField);
								break;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
			}
			return result;
		}

		public bool Save(string sName, string sValue)
		{
			return this.SaveCurrentUser(sName, string.Empty, sValue);
		}

		public bool SaveCurrentUser(string sName, string sCurrentUser, string sValue)
		{
			bool result = false;
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(this._filePath);
				XmlNode nodeConfig = this.getNodeConfig(xmlDocument, sName, sCurrentUser);
				XmlNode xmlNode = xmlDocument.CreateNode("element", this._tableName, "");
				XmlAttribute xmlAttribute = xmlDocument.CreateAttribute(this._keyField);
				xmlAttribute.Value = sName;
				xmlNode.Attributes.Append(xmlAttribute);
				bool flag = !string.IsNullOrEmpty(sCurrentUser);
				if (flag)
				{
					xmlAttribute = xmlDocument.CreateAttribute(this._currentUserField);
					xmlAttribute.Value = sCurrentUser;
					xmlNode.Attributes.Append(xmlAttribute);
				}
				xmlAttribute = xmlDocument.CreateAttribute(this._valueField);
				xmlAttribute.Value = sValue;
				xmlNode.Attributes.Append(xmlAttribute);
				bool flag2 = nodeConfig == null;
				if (flag2)
				{
					xmlDocument.DocumentElement.AppendChild(xmlNode);
				}
				else
				{
					xmlDocument.DocumentElement.ReplaceChild(xmlNode, nodeConfig);
				}
				xmlDocument.Save(this._filePath);
				result = true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
			}
			return result;
		}
	}
}
