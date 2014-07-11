using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace LessConsole {
	class Program {
		static void Main(string[] args) {

			string lessPath = System.Configuration.ConfigurationSettings.AppSettings["lesspath"];
			string lessFileNames = System.Configuration.ConfigurationSettings.AppSettings["lessfilenames"];
			
			string[] targetFiles = lessFileNames.Split(("|").ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			DirectoryInfo dirInfo = new DirectoryInfo(lessPath);
			FileInfo[] fileInfos = dirInfo.GetFiles("*.less", SearchOption.AllDirectories);


			StringBuilder batchFileContent = new StringBuilder();
			string cmdformat = "lessc {0} > {1}";

			ExecuteCmd execCmd = new ExecuteCmd();


			foreach (var fileInfo in fileInfos) {
				foreach (string lessFileName in targetFiles) {
					string[] arr = lessFileName.Split((",").ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
					if (fileInfo.Name.ToLower() == arr[0].ToLower()) {
						string descFileName = Path.Combine(lessPath, arr[1]);
						string lesscCommand = string.Format(cmdformat, fileInfo.FullName, descFileName);
						execCmd.ExecuteCommandSync(lesscCommand);
						//Thread.Sleep(1000);
					}
				}
			}

			Console.WriteLine("Press any key to quit");
			Console.ReadLine();
		}
	}

	public class ExecuteCmd {
		#region ExecuteCommand Sync and Async
		/// <summary>
		/// Executes a shell command synchronously.
		/// </summary>
		/// <param name="command">string command</param>
		/// <returns>string, as output of the command.</returns>
		public void ExecuteCommandSync(object command) {
			try {
				// create the ProcessStartInfo using "cmd" as the program to be run, and "/c " as the parameters.
				// Incidentally, /c tells cmd that we want it to execute the command that follows, and then exit.
				System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
				// The following commands are needed to redirect the standard output. 
				//This means that it will be redirected to the Process.StandardOutput StreamReader.
				procStartInfo.RedirectStandardOutput = true;
				procStartInfo.UseShellExecute = false;
				// Do not create the black window.
				procStartInfo.CreateNoWindow = true;
				// Now we create a process, assign its ProcessStartInfo and start it
				System.Diagnostics.Process proc = new System.Diagnostics.Process();
				proc.StartInfo = procStartInfo;
				proc.Start();

				// Get the output into a string
				string result = proc.StandardOutput.ReadToEnd();

				Console.WriteLine(command);

				// Display the command output.
				Console.WriteLine(result);
			} catch (Exception objException) {
				// Log the exception
			}
		}

		/// <summary>
		/// Execute the command Asynchronously.
		/// </summary>
		/// <param name="command">string command.</param>
		public void ExecuteCommandAsync(string command) {
			try {
				//Asynchronously start the Thread to process the Execute command request.
				Thread objThread = new Thread(new ParameterizedThreadStart(ExecuteCommandSync));
				//Make the thread as background thread.
				objThread.IsBackground = true;
				//Set the Priority of the thread.
				objThread.Priority = ThreadPriority.AboveNormal;
				//Start the thread.
				objThread.Start(command);
			} catch (ThreadStartException objException) {
				// Log the exception
			} catch (ThreadAbortException objException) {
				// Log the exception
			} catch (Exception objException) {
				// Log the exception
			}
		}
		#endregion
	}
}
