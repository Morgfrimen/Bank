using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Config.Config
{

	/// <summary>
	///     Конфигурация приложения
	/// </summary>
	/// <remarks>Не использовать пуличный конструктор, он нужен только для десерелизации штатными средствами NET 5.0</remarks>
	public sealed class Config
	{

		#region Static Fields and Constants

		private static readonly string _path = $@"{Environment.CurrentDirectory}\{nameof(Config)}\config.json";

		#endregion

		#region Constructors

		static Config() => Con = GetConfig();

		#endregion

		#region Properties

		/// <summary>
		///     Запрещенные строки
		/// </summary>
		public string[] BanString { get; } = {"*", "#", "ТБ=01"};

		/// <summary>
		///     Сортировка и фильтрация возможна только по первым 4 столбцам (такое задание)
		/// </summary>
		public char Separator { get; } = '|';

		/// <summary>
		///     Сортировка и фильтрация возможна только по первым 4 столбцам (такое задание)
		/// </summary>
		public int SortRun { get; } = 4;

		public static Config Con { get; private set; }

		#endregion

		#region Methods

		private static Config GetConfig()
		{
			try
			{
				if (!Directory.Exists($@"{Environment.CurrentDirectory}\{nameof(Config)}"))
					Directory.CreateDirectory($@"{Environment.CurrentDirectory}\{nameof(Config)}");

				if (File.Exists(_path))
				{
					JsonSerializerOptions? setting = new JsonSerializerOptions();
					using StreamReader stream = new StreamReader(_path, Encoding.Unicode);
					Con = JsonSerializer.Deserialize<Config>(stream.ReadToEnd());
				}
				else
				{
					Con = new Config();
					using StreamWriter stream = new StreamWriter(_path, false, Encoding.Unicode);
					string str = JsonSerializer.Serialize(Con);
					stream.Write(str);
				}

				return Con;
			}
			catch (Exception exception)
			{
				Logger.Logger.Error(exception, nameof(Config), "Constructor");

				return new Config();
			}

		}

		#endregion

		//TODO: xml and xlms
	}

}