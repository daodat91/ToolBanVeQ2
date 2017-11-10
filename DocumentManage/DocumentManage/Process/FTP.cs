using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace FTPDotNet20
{
	public class FTP
	{
		private const int BufferSize = 512;

		private string _strServer;

		private string _strUser;

		private string _strPass;

		private int _iPort;

		private int _iTimeOut;

		private string _strWorkingDirectory;

		private long _lBytesTotal;

		private long _lFileSize;

		private FileStream _filestream;

		private Stream _streamFTPWebRequestRespone;

		private FtpWebResponse _ftpWebRespone;

		public string Server
		{
			get
			{
				return this._strServer;
			}
			set
			{
				this._strServer = value;
			}
		}

		public string User
		{
			get
			{
				return this._strUser;
			}
			set
			{
				this._strUser = value;
			}
		}

		public string Pass
		{
			get
			{
				return this._strPass;
			}
			set
			{
				this._strPass = value;
			}
		}

		public int Port
		{
			get
			{
				return this._iPort;
			}
			set
			{
				this._iPort = value;
			}
		}

		public int Timeout
		{
			get
			{
				return this._iTimeOut;
			}
			set
			{
				this._iTimeOut = value;
			}
		}

		public string WorkingDirectory
		{
			get
			{
				return this._strWorkingDirectory;
			}
			set
			{
				value = value.TrimEnd(new char[]
				{
					'/'
				});
				bool flag = value.Contains("/") || value == "";
				if (flag)
				{
					this._strWorkingDirectory = value;
				}
				else
				{
					this._strWorkingDirectory += value;
				}
				this._strWorkingDirectory += "/";
			}
		}

		public long BytesTotal
		{
			get
			{
				return this._lBytesTotal;
			}
		}

		public long FileSize
		{
			get
			{
				return this._lFileSize;
			}
		}

		public FTP()
		{
			this._strServer = "";
			this._iPort = 21;
			this._strUser = "";
			this._strPass = "";
			this._iTimeOut = 10000;
			this._strWorkingDirectory = "/";
		}

		public FTP(string server, string user, string pass)
		{
			this._strServer = server;
			this._strUser = user;
			this._strPass = pass;
			this._iPort = 21;
			this._iTimeOut = 10000;
			this._strWorkingDirectory = "/";
		}

		public FTP(string server, int port, string user, string pass)
		{
			this._strServer = server;
			this._strUser = user;
			this._strPass = pass;
			this._iPort = port;
			this._iTimeOut = 10000;
			this._strWorkingDirectory = "/";
		}

		public void OpenUpload(string filename)
		{
			this.OpenUpload(filename, filename, false);
		}

		public void OpenUpload(string filename, string remotefilename)
		{
			this.OpenUpload(filename, remotefilename, false);
		}

		public void OpenUpload(string filename, bool resume)
		{
			this.OpenUpload(filename, filename, resume);
		}

		public void OpenUpload(string filename, string remote_filename, bool resume)
		{
			FileInfo fileInfo = new FileInfo(filename);
			string uri = this.GetUri(remote_filename);
			FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(uri));
			ftpWebRequest.Credentials = new NetworkCredential(this._strUser, this._strPass);
			ftpWebRequest.KeepAlive = false;
			ftpWebRequest.Method = "STOR";
			ftpWebRequest.UseBinary = true;
			this._lFileSize = (ftpWebRequest.ContentLength = fileInfo.Length);
			this._lBytesTotal = 0L;
			this._filestream = fileInfo.OpenRead();
			this._streamFTPWebRequestRespone = ftpWebRequest.GetRequestStream();
			if (resume)
			{
				long fileSize = this.GetFileSize(remote_filename);
				this._filestream.Seek(fileSize, SeekOrigin.Begin);
			}
		}

		public long DoUpload()
		{
			byte[] buffer = new byte[512];
			int num;
			try
			{
				num = this._filestream.Read(buffer, 0, 512);
				this._lBytesTotal += (long)num;
				this._streamFTPWebRequestRespone.Write(buffer, 0, num);
				bool flag = num <= 0;
				if (flag)
				{
					this._filestream.Close();
					this._filestream = null;
					this._streamFTPWebRequestRespone.Close();
					this._streamFTPWebRequestRespone = null;
				}
			}
			catch (Exception ex)
			{
				this._filestream.Close();
				this._filestream = null;
				this._streamFTPWebRequestRespone.Close();
				this._streamFTPWebRequestRespone = null;
				throw ex;
			}
			return (long)num;
		}

		public void OpenDownload(string filename)
		{
			this.OpenDownload(filename, filename, false);
		}

		public void OpenDownload(string filename, bool resume)
		{
			this.OpenDownload(filename, filename, resume);
		}

		public void OpenDownload(string filename, string localfilename)
		{
			this.OpenDownload(filename, localfilename, false);
		}

		public void OpenDownload(string remote_filename, string local_filename, bool resume)
		{
			FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(this.GetUri(remote_filename)));
			ftpWebRequest.Method = "RETR";
			ftpWebRequest.UseBinary = true;
			ftpWebRequest.Credentials = new NetworkCredential(this._strUser, this._strPass);
			this._ftpWebRespone = (FtpWebResponse)ftpWebRequest.GetResponse();
			this._streamFTPWebRequestRespone = this._ftpWebRespone.GetResponseStream();
			try
			{
				this._lFileSize = this.GetFileSize(remote_filename);
			}
			catch
			{
				this._lFileSize = 0L;
			}
			this._lBytesTotal = 0L;
			bool flag = resume && File.Exists(local_filename);
			if (flag)
			{
				try
				{
					this._filestream = new FileStream(local_filename, FileMode.Open);
				}
				catch (Exception ex)
				{
					this._filestream = null;
					throw new Exception(ex.Message);
				}
				this._filestream.Seek(this._filestream.Length, SeekOrigin.Begin);
				this._lBytesTotal = this._filestream.Length;
			}
			else
			{
				try
				{
					this._filestream = new FileStream(local_filename, FileMode.Create);
				}
				catch (Exception ex2)
				{
					this._filestream = null;
					throw new Exception(ex2.Message);
				}
			}
		}

		public long DoDownload()
		{
			byte[] buffer = new byte[512];
			long num;
			long result;
			try
			{
				num = (long)this._streamFTPWebRequestRespone.Read(buffer, 0, 512);
				bool flag = num <= 0L;
				if (flag)
				{
					this._streamFTPWebRequestRespone.Close();
					this._filestream.Close();
					this._ftpWebRespone.Close();
					result = num;
					return result;
				}
				this._filestream.Write(buffer, 0, (int)num);
				this._lBytesTotal += num;
			}
			catch (Exception ex)
			{
				this._streamFTPWebRequestRespone.Close();
				this._filestream.Close();
				this._ftpWebRespone.Close();
				this._filestream = null;
				throw ex;
			}
			result = num;
			return result;
		}

		private string GetUri(string remote_filename)
		{
			return string.Format("ftp://{0}:{1}{2}{3}", new object[]
			{
				this._strServer,
				this._iPort,
				this._strWorkingDirectory,
				remote_filename
			});
		}

		private long GetFileSize(string filename)
		{
			long result = 0L;
			try
			{
				FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(this.GetUri(filename)));
				ftpWebRequest.Method = "SIZE";
				ftpWebRequest.UseBinary = true;
				ftpWebRequest.Credentials = new NetworkCredential(this._strUser, this._strPass);
				FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
				Stream responseStream = ftpWebResponse.GetResponseStream();
				result = ftpWebResponse.ContentLength;
				responseStream.Close();
				ftpWebResponse.Close();
			}
			catch (Exception var_4_73)
			{
			}
			return result;
		}

		public string[] GetFileList()
		{
			StringBuilder stringBuilder = new StringBuilder();
			string[] result;
			try
			{
				FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(this.GetUri("")));
				ftpWebRequest.UseBinary = true;
				ftpWebRequest.Credentials = new NetworkCredential(this._strUser, this._strPass);
				ftpWebRequest.Method = "NLST";
				WebResponse response = ftpWebRequest.GetResponse();
				StreamReader streamReader = new StreamReader(response.GetResponseStream());
				for (string text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
				{
					stringBuilder.Append(text);
					stringBuilder.Append("\n");
				}
				bool flag = stringBuilder.Length > 0;
				if (flag)
				{
					stringBuilder.Remove(stringBuilder.ToString().LastIndexOf('\n'), 1);
				}
				streamReader.Close();
				response.Close();
				result = stringBuilder.ToString().Split(new char[]
				{
					'\n'
				});
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}

		public string[] GetFilesDetailList()
		{
			string[] result;
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(this.GetUri("")));
				ftpWebRequest.Credentials = new NetworkCredential(this._strUser, this._strPass);
				ftpWebRequest.Method = "LIST";
				WebResponse response = ftpWebRequest.GetResponse();
				StreamReader streamReader = new StreamReader(response.GetResponseStream());
				for (string text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
				{
					stringBuilder.Append(text);
					stringBuilder.Append("\n");
				}
				stringBuilder.Remove(stringBuilder.ToString().LastIndexOf("\n"), 1);
				streamReader.Close();
				response.Close();
				result = stringBuilder.ToString().Split(new char[]
				{
					'\n'
				});
			}
			catch (Exception var_8_D2)
			{
				string[] array = null;
				result = array;
			}
			return result;
		}

		public void RemoveDir(string dir)
		{
			try
			{
				FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(this.GetUri(dir)));
				ftpWebRequest.Credentials = new NetworkCredential(this._strUser, this._strPass);
				ftpWebRequest.KeepAlive = false;
				ftpWebRequest.Method = "RMD";
				string text = string.Empty;
				FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
				long contentLength = ftpWebResponse.ContentLength;
				Stream responseStream = ftpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream);
				text = streamReader.ReadToEnd();
				streamReader.Close();
				responseStream.Close();
				ftpWebResponse.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "FTP 2.0 Delete");
				throw ex;
			}
		}

		public void RemoveFile(string fileName)
		{
			try
			{
				FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(this.GetUri(fileName)));
				ftpWebRequest.Credentials = new NetworkCredential(this._strUser, this._strPass);
				ftpWebRequest.KeepAlive = false;
				ftpWebRequest.Method = "DELE";
				string text = string.Empty;
				FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
				long contentLength = ftpWebResponse.ContentLength;
				Stream responseStream = ftpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream);
				text = streamReader.ReadToEnd();
				streamReader.Close();
				responseStream.Close();
				ftpWebResponse.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "FTP 2.0 Delete");
				throw ex;
			}
		}

		private void RenameFile(string currentFilename, string newFilename)
		{
			try
			{
				FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(this.GetUri(currentFilename)));
				ftpWebRequest.Method = "RENAME";
				ftpWebRequest.RenameTo = newFilename;
				ftpWebRequest.UseBinary = true;
				ftpWebRequest.Credentials = new NetworkCredential(this._strUser, this._strPass);
				FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
				Stream responseStream = ftpWebResponse.GetResponseStream();
				responseStream.Close();
				ftpWebResponse.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public void MakeDir(string dirName)
		{
			try
			{
				FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(this.GetUri(dirName)));
				ftpWebRequest.Method = "MKD";
				ftpWebRequest.UseBinary = true;
				ftpWebRequest.Credentials = new NetworkCredential(this._strUser, this._strPass);
				FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
				Stream responseStream = ftpWebResponse.GetResponseStream();
				responseStream.Close();
				ftpWebResponse.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public bool FileExist(string filename)
		{
			bool result = true;
			FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(this.GetUri(filename)));
			ftpWebRequest.Credentials = new NetworkCredential(this._strUser, this._strPass);
			ftpWebRequest.Method = "SIZE";
			try
			{
				FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
				ftpWebResponse.Close();
			}
			catch (WebException ex)
			{
				FtpWebResponse ftpWebResponse2 = (FtpWebResponse)ex.Response;
				bool flag = ftpWebResponse2.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable;
				if (flag)
				{
					result = false;
				}
				ftpWebResponse2.Close();
			}
			return result;
		}

		public bool CopyFile(string strRoot, string folderName, string fileName, string folderNameToCopy, string fileNameToCopy)
		{
			bool result;
			try
			{
				this._strWorkingDirectory = string.Format("/{0}/{1}/", strRoot, folderName);
				FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(this.GetUri(fileName)));
				ftpWebRequest.Credentials = new NetworkCredential(this._strUser, this._strPass);
				ftpWebRequest.KeepAlive = false;
				ftpWebRequest.Method = "RETR";
				FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
				Stream stream = ftpWebResponse.GetResponseStream();
				this._lBytesTotal = 0L;
				MemoryStream memoryStream = new MemoryStream();
				byte[] array = new byte[512];
				int num;
				while ((num = stream.Read(array, 0, array.Length)) > 0)
				{
					this._lBytesTotal += (long)num;
					memoryStream.Write(array, 0, num);
				}
				byte[] array2 = memoryStream.ToArray();
				memoryStream.Close();
				memoryStream.Dispose();
				this._strWorkingDirectory = string.Format("/{0}/{1}/", strRoot, folderNameToCopy);
				ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(this.GetUri(fileNameToCopy)));
				ftpWebRequest.Credentials = new NetworkCredential(this._strUser, this._strPass);
				ftpWebRequest.Method = "STOR";
				stream = ftpWebRequest.GetRequestStream();
				stream.Write(array2, 0, array2.Length);
				stream.Close();
				stream.Dispose();
				ftpWebResponse.Close();
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "FTP 2.0 CopyFile");
				throw ex;
			}
			return result;
		}
	}
}
