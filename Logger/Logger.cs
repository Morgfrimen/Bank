using System;
using System.IO;
using System.Text;

namespace Logger
{

	public static class Logger
	{

		#region Methods

		/// <summary>
		///     Запись лога с ошибкой
		/// </summary>
		/// <param name="exception">Вызвонная ошибка</param>
		/// <param name="nameClass">Имя класса</param>
		/// <param name="nameMethod">Имя вызванного метода</param>
		public static void Error(Exception exception, string nameClass, string nameMethod) => WriteLog
			($"Error > {exception.Message} :> {nameClass} ----> {nameMethod}");

		/// <summary>
		///     Информация о вызываемом методе
		/// </summary>
		/// <param name="nameClass">Имя класса</param>
		/// <param name="nameMethod">Имя вызванного метода</param>
		public static void InformationCalledMethod(string nameClass, string nameMethod) => WriteLog($"Call in {nameClass} method {nameMethod}");

		/// <summary>
		///     Информация о завершившимся методе
		/// </summary>
		/// <param name="nameClass">Имя класса</param>
		/// <param name="nameMethod">Имя вызванного метода</param>
		public static void InformationSuccesMethod(string nameClass, string nameMethod) => WriteLog($"Succes method {nameMethod} in {nameClass}");

		private static void WriteLog(string message)
		{
			string path = $@"{Environment.CurrentDirectory}\Logs";

			try
			{
				using StreamWriter stream = new StreamWriter($@"{path}\Log{DateTime.Now: ddMMyyyy}.log", true, Encoding.Unicode);
				stream.Write(message + Environment.NewLine);
			}
			catch (IOException)
			{

				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
					WriteLog(message);

				}

			}
			catch
			{

				//TODO: Пока похер на отвал логгера
			}
		}

		#endregion

	}

}