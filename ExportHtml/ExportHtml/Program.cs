using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ExportHtml {
	class Program {

		public static string SourcePath = System.Configuration.ConfigurationManager.AppSettings["sourcepath"];
		public static string DestinationPath = System.Configuration.ConfigurationManager.AppSettings["destinationpath"];

		public static string[] CopyFolders = { "css", "js", "img", "less" };

		public static string[] DocumentationFolders = { "css\\plugins\\bootstrap", "css\\plugins\\font-awesome", "css\\document", "js\\bootstrap", "js\\jquery", "js\\files"  };

		public static string[] DocumentationFiles = { "css\\components.css", 
														"css\\components.min.css", 
														"css\\site.css", 
														"css\\site.min.css",
													};

		static void Main(string[] args) {

			try {

				string HTMLFolderName = "HTML";
				string DocumentationFolderName = "Documentation";

				ProcessHTMLDirectory(HTMLFolderName);
				ProcessDOCDirectory(DocumentationFolderName);


			} catch (Exception ex) {
				Console.WriteLine("Exception =", ex.Message);
			}
			Console.WriteLine("Press any key to exit");
			Console.ReadLine();
		}

        public static void DownloadHTML(string url)
        {

        }

		public static void ProcessHTMLDirectory(string dirName) {
			string descPath = Path.Combine(DestinationPath, dirName);
			if (Directory.Exists(descPath) == false) {
				Directory.CreateDirectory(descPath);
			}
			foreach (string copyFolder in CopyFolders) {
				string sourceDir = Path.Combine(SourcePath, copyFolder);
				string descDir = Path.Combine(descPath, copyFolder);
				CopyDirectory(sourceDir, descDir);
			}
		}

		public static void ProcessDOCDirectory(string dirName) {
			string descPath = Path.Combine(DestinationPath, dirName);
			if (Directory.Exists(descPath) == false) {
				Directory.CreateDirectory(descPath);
			}
			foreach (string copyFolder in DocumentationFolders) {
				string sourceDir = Path.Combine(SourcePath, copyFolder);
				string descDir = Path.Combine(descPath, copyFolder);
				CopyDirectory(sourceDir, descDir);
			}

			foreach (string copyFile in DocumentationFiles) {
				string sourceFile = Path.Combine(SourcePath, copyFile);
				string descFile = Path.Combine(descPath, copyFile);
				if (File.Exists(sourceFile)) {
					FileInfo sourceFileInfo = new FileInfo(sourceFile);
					File.Copy(sourceFile, descFile);
				}
			}
		}

		public static void CleanDirectory(string dirPath) {
			Console.WriteLine("CleanDirectory = " + dirPath);
			if (Directory.Exists(dirPath)) {
				string[] files = Directory.GetFiles(dirPath);
				foreach (string fileName in files) {
					if (File.Exists(fileName)) {
						File.Delete(fileName);
					}
				}
			}
		}

		public static void CopyDirectory(string sourceDirectory, string destinationDirectory) {
			Console.WriteLine("File copy directory = " + sourceDirectory + " desc =" + sourceDirectory);
			if (Directory.Exists(sourceDirectory)) {
				DirectoryInfo sourceDirInfo = new DirectoryInfo(sourceDirectory);
				CleanDirectory(destinationDirectory);
				if (Directory.Exists(destinationDirectory) == false) {
					Directory.CreateDirectory(destinationDirectory.ToLower());
				}
				string[] files = Directory.GetFiles(sourceDirectory);
				foreach (string fileName in files) {
					FileInfo fileInfo = new FileInfo(fileName);
					string descFileName = Path.Combine(destinationDirectory, fileInfo.Name);
					if (File.Exists(descFileName)) {
						File.Delete(descFileName);
					}
					Console.WriteLine("File copy file = " + fileName + " desc =" + descFileName);
					File.Copy(fileName, descFileName);
				}
				string[] dirs = Directory.GetDirectories(sourceDirectory);
				foreach (string dirName in dirs) {
					DirectoryInfo dirInfo = new DirectoryInfo(dirName);
					string descDirName = Path.Combine(destinationDirectory, dirInfo.Name);
					CopyDirectory(dirInfo.FullName, descDirName);
				}
			}
		}
	}


}
