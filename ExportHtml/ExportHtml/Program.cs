using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace ExportHtml {
	class Program {

		public static string SourcePath = System.Configuration.ConfigurationManager.AppSettings["sourcepath"];
		public static string DestinationPath = System.Configuration.ConfigurationManager.AppSettings["destinationpath"];

		public static string[] CopyFolders = { "css", "js", "img", "less", "php" };

		public static string[] DocumentationFolders = { "css\\plugins\\bootstrap", "css\\plugins\\font-awesome", "css\\document", "js\\bootstrap", "js\\jquery", "js\\app" };

		public static string[] DocumentationFiles = { "css\\components.css", 
														"css\\components.min.css", 
														"css\\site.css", 
														"css\\site.min.css",
													};

		public static string HTMLFolderName = "HTML";
		public static string DocumentationFolderName = "Documentation";
		public static string websiteUrl = "http://localhost:1010/";

		static void Main(string[] args) {

			try {


				string descPath = Path.Combine(DestinationPath, HTMLFolderName);
				CleanDirectory(descPath);
				descPath = Path.Combine(DestinationPath, DocumentationFolderName);
				CleanDirectory(descPath);

				ProcessHTMLDirectory(HTMLFolderName);
				ProcessDOCDirectory(DocumentationFolderName);

				string viewPath = Path.Combine(SourcePath, "Views/Home");
				string[] viewFiles = Directory.GetFiles(viewPath);

				foreach (string viewFile in viewFiles) {
					CreateHTMLFile(viewFile, "Home", HTMLFolderName);
					CreateHTMLFile(viewFile, "Document", DocumentationFolderName);
				}
				descPath = Path.Combine(DestinationPath, HTMLFolderName, "js", "pages");
				CheckJSFiles(descPath, "");
				descPath = Path.Combine(DestinationPath, HTMLFolderName, "js", "app");
				CheckJSFiles(descPath, "");
				descPath = Path.Combine(DestinationPath, HTMLFolderName, "js", "plugins", "jqueryfileupload");
				CheckJSFiles(descPath, "main.js");
			} catch (Exception ex) {
				Console.WriteLine("Exception =" + ex.Message);
			}
			Console.WriteLine("Press any key to exit");
			Console.ReadLine();
		}

		private static void CheckJSFiles(string folderPath, string targetFileName) {
			if (Directory.Exists(folderPath)) {
				if (targetFileName != "") {
					if(File.Exists(Path.Combine(folderPath, targetFileName))){
						string result = File.ReadAllText(Path.Combine(folderPath, targetFileName));
						result = ReplaceContent(result);
						File.WriteAllText(Path.Combine(folderPath, targetFileName), result);
					}
				} else {
					string[] jsFiles = Directory.GetFiles(folderPath, "*.js", SearchOption.AllDirectories);
					foreach (string fileName in jsFiles) {
						string result = File.ReadAllText(fileName);
						result = ReplaceContent(result);
						File.WriteAllText(fileName, result);
					}
				}
			}
		}

		public static void CreateHTMLFile(string viewFile, string controllerName, string folderName) {
			try {
				//Console.WriteLine("CreateHTMLFile viewFile=" + viewFile + " controllerName=" + controllerName);
				FileInfo fileInfo = new FileInfo(viewFile);
				string htmlFileName = fileInfo.Name.Replace(".cshtml", "");
				string viewUrl = websiteUrl + controllerName + "/" + htmlFileName;
				string html = DownloadHTML(viewUrl);
				htmlFileName = htmlFileName.ToLower() + ".html";
				string descPath = Path.Combine(DestinationPath, folderName, htmlFileName);
				File.WriteAllText(descPath, html);
			} catch (Exception ex) {
				Console.WriteLine("CreateHTMLFile Exception =" + ex.Message);
			}
		}

		public static string ReplaceContent(string result) {
			result = ReplaceCSS(result);
			result = ReplaceJS(result);
			result = ReplaceIMG(result);
			result = ReplaceCSHTML(result);
			result = result.Replace("/php/", "php/");
			result = result.Replace(" class=\"\"", "");
			result = result.Replace("class=\"\"", "");
			return result;
		}

		public static string DownloadHTML(string url) {
			string result = string.Empty;
			try {
				using (WebClient webClient = new WebClient()) {
					result = webClient.DownloadString(url);
				}
				result = ReplaceContent(result);
				if (result.StartsWith("\r\n")) {
					result = result.Substring(2);
				}
			} catch (Exception ex) {
				Console.WriteLine("DownloadHTML Exception =" + ex.Message);
			}
			return result;
		}

		public static string ReplaceCSHTML(string result) {
			Regex regex = new Regex(
   @"href\s*=\s*(?:\""(?<href>[^\""]*)\""|(?<href>\\S+))",
   RegexOptions.IgnoreCase
   | RegexOptions.Multiline
   | RegexOptions.IgnorePatternWhitespace
   | RegexOptions.Compiled
   );
			MatchCollection matches = regex.Matches(result);
			foreach (Match m in matches) {
				if (m.Value.Contains("/Home") || m.Value.Contains("/Document")) {
					string href = m.Groups["href"].Value.Replace("/Home", "").Replace("/Document", "");
					if (href == "") {
						href = "/";
					} else {
						href = href.Replace("/", "");
						href = href.ToLower() + ".html";
					}
					result = result.Replace(m.Value, "href=\"" + href + "\"");
				}
			}
			return result;
		}

		public static string ReplaceCSS(string result) {
			Regex regex = new Regex(
				@"href\s*=\s*(?:\""\/css)",
				RegexOptions.IgnoreCase
				| RegexOptions.Multiline
				| RegexOptions.IgnorePatternWhitespace
				| RegexOptions.Compiled
				);
			result = regex.Replace(result, "href=\"css");
			regex = new Regex(
				@"href\s*=\s*(?:\'\/css)",
				RegexOptions.IgnoreCase
				| RegexOptions.Multiline
				| RegexOptions.IgnorePatternWhitespace
				| RegexOptions.Compiled
				);
			result = regex.Replace(result, "href='css");
			return result;
		}

		public static string ReplaceJS(string result) {
			Regex regex = new Regex(
				@"src\s*=\s*(?:\""\/js)",
				RegexOptions.IgnoreCase
				| RegexOptions.Multiline
				| RegexOptions.IgnorePatternWhitespace
				| RegexOptions.Compiled
				);
			result = regex.Replace(result, "src=\"js");
			regex = new Regex(
				@"src\s*=\s*(?:\'\/js)",
				RegexOptions.IgnoreCase
				| RegexOptions.Multiline
				| RegexOptions.IgnorePatternWhitespace
				| RegexOptions.Compiled
				);
			result = regex.Replace(result, "src='js");
			return result;
		}

		public static string ReplaceIMG(string result) {
			Regex regex = new Regex(
				@"src\s*=\s*(?:\""\/img)",
				RegexOptions.IgnoreCase
				| RegexOptions.Multiline
				| RegexOptions.IgnorePatternWhitespace
				| RegexOptions.Compiled
				);
			result = regex.Replace(result, "src=\"img");
			regex = new Regex(
				@"src\s*=\s*(?:\'\/img)",
				RegexOptions.IgnoreCase
				| RegexOptions.Multiline
				| RegexOptions.IgnorePatternWhitespace
				| RegexOptions.Compiled
				);
			result = regex.Replace(result, "src='img");
			return result;
		}

		public static void ProcessHTMLDirectory(string dirName) {
			try {
				string descPath = Path.Combine(DestinationPath, dirName);
				if (Directory.Exists(descPath) == false) {
					Directory.CreateDirectory(descPath);
				}
				foreach (string copyFolder in CopyFolders) {
					string sourceDir = Path.Combine(SourcePath, copyFolder);
					string descDir = Path.Combine(descPath, copyFolder);
					CopyDirectory(sourceDir, descDir);
				}
			} catch (Exception ex) {
				Console.WriteLine("ProcessHTMLDirectory Exception=" + ex.Message);
			}
		}

		public static void ProcessDOCDirectory(string dirName) {
			try {
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
						if (File.Exists(descFile)) {
							File.Delete(descFile);
						}
						File.Copy(sourceFile, descFile);
					}
				}
			} catch (Exception ex) {
				Console.WriteLine("ProcessDOCDirectory Exception=" + ex.Message);
			}
		}

		public static void CleanDirectory(string dirPath) {
			try {
				//Console.WriteLine("CleanDirectory = " + dirPath);
				if (Directory.Exists(dirPath)) {
					string[] files = Directory.GetFiles(dirPath);
					foreach (string fileName in files) {
						if (File.Exists(fileName)) {
							File.Delete(fileName);
						}
					}
				}
			} catch (Exception ex) {
				Console.WriteLine("CleanDirectory Exception=" + ex.Message);
			}
		}

		public static void CopyDirectory(string sourceDirectory, string destinationDirectory) {
			try {
				//Console.WriteLine("File copy directory = " + sourceDirectory + " desc =" + sourceDirectory);
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
						//Console.WriteLine("File copy file = " + fileName + " desc =" + descFileName);
						File.Copy(fileName, descFileName);
					}
					string[] dirs = Directory.GetDirectories(sourceDirectory);
					foreach (string dirName in dirs) {
						DirectoryInfo dirInfo = new DirectoryInfo(dirName);
						string descDirName = Path.Combine(destinationDirectory, dirInfo.Name);
						CopyDirectory(dirInfo.FullName, descDirName);
					}
				}
			} catch (Exception ex) {
				Console.WriteLine("CopyDirectory Exception=" + ex.Message);
			}
		}
	}


}
