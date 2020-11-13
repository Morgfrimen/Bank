using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

using InloaderXmlXmls.Xml.Model;

namespace InloaderXmlXmls.Xml
{

	internal sealed class LoaderXml : ILoader
	{

		#region Constructors

		internal LoaderXml(string path) => Path = path;

		#endregion

		#region Properties

		private string Path { get; }

		#endregion

		#region Methods

		public void LoadXmlFile()
		{
			//TODO: Выпилить
			RootXml rootXml = new RootXml();
			rootXml.Report = new Report();
			rootXml.Report.FormVariant = new FormVariant();
			rootXml.Report.Code = "042";
			rootXml.Report.AlbumCode = "МЕС_К";
			rootXml.Report.FormVariant.Number = 1;
			rootXml.Report.FormVariant.NsiVariantCode = "0000";
			rootXml.Report.FormVariant.Table = new Table();
			rootXml.Report.FormVariant.Table.Code = "Строка";

			Data[] datas = new Data[DbContex.DbContextApp.GetDbContextApp.TableFirsts.Count() + 1];
			var TableList = DbContex.DbContextApp.GetDbContextApp.TableFirsts.ToList();
			for (int indexData = 0; indexData < datas.Length - 1; indexData++)
			{
				datas[indexData] = new Data()
				{
					First = TableList[indexData].V1.ToString(),
					Second = TableList[indexData].G1.ToString(),
					X2 = TableList[indexData].X2,
					X3 = TableList[indexData].X3,
					X4 = TableList[indexData].X4,
					X5 = TableList[indexData].X5,
					X6 = TableList[indexData].X6,
					X7 = TableList[indexData].X7,
					X8 = TableList[indexData].X8,
					X9 = TableList[indexData].X9,
					X10 = TableList[indexData].X10,
					X11 = TableList[indexData].X11,
					X12 = TableList[indexData].X12,
					X13 = TableList[indexData].X13,
					X14 = TableList[indexData].X14
				};
			}
			datas[datas.Length - 1] = new Data()
			{
				First = "88888",
				Second = "888",
				X2 = TableList.Sum(item=>item.X2),
				X3 = TableList.Sum(item => item.X3),
				X4 = TableList.Sum(item => item.X4),
				X5 = TableList.Sum(item => item.X5),
				X6 = TableList.Sum(item => item.X6),
				X7 = TableList.Sum(item => item.X7),
				X8 = TableList.Sum(item => item.X8),
				X9 = TableList.Sum(item => item.X9),
				X10 = TableList.Sum(item => item.X10),
				X11 = TableList.Sum(item => item.X11),
				X12 = TableList.Sum(item => item.X12),
				X13 = TableList.Sum(item => item.X13),
				X14 = TableList.Sum(item => item.X14)
			};
			rootXml.Report.FormVariant.Table.Data = datas;

			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(RootXml));
				string textFromFile = string.Empty;
				using (FileStream fileStream = new FileStream(Path, FileMode.OpenOrCreate))
				{
					xmlSerializer.Serialize(fileStream,rootXml);
				}
			
				using (StreamReader fileStream = new StreamReader(Path,Encoding.GetEncoding(1251)))
				{
					textFromFile = fileStream.ReadToEnd();
					
				}
				//Форматирование
				textFromFile = Regex.Replace(textFromFile, @"_x\d{1,2}=" + "\"0\"",string.Empty,RegexOptions.Compiled);
				textFromFile = Regex.Replace(textFromFile, "\\S+=\"\"", string.Empty, RegexOptions.Compiled);
                textFromFile = Regex.Replace(textFromFile, @" {2,100}", @"", RegexOptions.Compiled);
                textFromFile = Regex.Replace(textFromFile, @"((<Report)|(</Report).*\r\n)", new string(' ', 4) + @"$1", RegexOptions.Compiled);
                textFromFile = Regex.Replace(textFromFile, @"((<FormVariant)|(</FormVariant).*\r\n)", new string(' ', 8) + @"$1", RegexOptions.Compiled);
                textFromFile = Regex.Replace(textFromFile, @"((<Table)|(</Table).*\r\n)", new string(' ', 12) + @"$1", RegexOptions.Compiled);
                textFromFile = Regex.Replace(textFromFile, @"((<Data)|(</Data).*\r\n)", new string(' ', 16) + @"$1", RegexOptions.Compiled);
                using (StreamWriter streamWriter = new StreamWriter(Path,false,Encoding.GetEncoding(1251)))
				{
					streamWriter.Write(textFromFile);
				}


			}
			catch (Exception exception)
			{
				Logger.Logger.Error(exception, nameof(LoaderXml), nameof(Path) + $"{Environment.NewLine}Ошибка в сохранении Xml файла");

				throw;
			}
		}

		#endregion

	}

}