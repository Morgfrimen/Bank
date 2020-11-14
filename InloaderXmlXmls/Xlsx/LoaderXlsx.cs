using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

using DbContex;
using DbContex.Models;

using Microsoft.Office.Interop.Excel;

using Excel = Microsoft.Office.Interop.Excel;

namespace InloaderXmlXmls.Xlsx
{

	//TODO: REfactor :)
	public class LoaderXlsx : ILoader
	{

		#region Constructors

		internal LoaderXlsx(string path) => Path = path;

		#endregion

		#region Properties

		private string Path { get; }

		#endregion

		#region Methods

		private void FormaterRange(Excel.Range range)
		{
			range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
			range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
			range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
			range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;
			range.Borders.get_Item(XlBordersIndex.xlInsideHorizontal).LineStyle = XlLineStyle.xlContinuous;
			range.Borders.get_Item(XlBordersIndex.xlInsideVertical).LineStyle = XlLineStyle.xlContinuous;
			range.EntireColumn.AutoFit();
			range.EntireRow.AutoFit();
			range.HorizontalAlignment = Constants.xlCenter;
			range.VerticalAlignment = Constants.xlCenter;
		}

		public void LoadXmlFile()
		{
			try
			{

				if (File.Exists(Path))
				{
					File.Delete(Path);
				}

				//TODO: Проверить, есть ли вообще Excel на ПК
				Application ex = new Application();

#if DEBUG
				ex.Visible = true;
#endif
                try
                {
                    ex.Workbooks.Open(Path,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
                }
                catch 
                {
	                Workbook workBook = ex.Workbooks.Add(Type.Missing);
				}
				

				Worksheet sheet = (Worksheet) ex.Worksheets.get_Item(1);
				sheet.Name = "Бюджет";

				#region Одиночные ячейки в шапке

				#region долгосрочная

				Excel.Range range = sheet.get_Range("C4").Cells;
				range.Value = "долгосрочная";
				range.EntireColumn.AutoFit();
				range.EntireRow.AutoFit();
				range.HorizontalAlignment = Constants.xlCenter;
				range.VerticalAlignment = Constants.xlCenter;
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region просроченная

				range = sheet.get_Range("D4").Cells;
				range.Value = "просроченная";
				range.EntireColumn.AutoFit();
				range.EntireRow.AutoFit();
				range.HorizontalAlignment = Constants.xlCenter;
				range.VerticalAlignment = Constants.xlCenter;
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region всего

				range = sheet.get_Range("E4").Cells;
				range.Value = "всего";
				range.EntireColumn.AutoFit();
				range.EntireRow.AutoFit();
				range.HorizontalAlignment = Constants.xlCenter;
				range.VerticalAlignment = Constants.xlCenter;
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region в том числе неденежные

				range = sheet.get_Range("F4").Cells;
				range.Value = "в том числе неденежные";
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region всего

				range = sheet.get_Range("G4").Cells;
				range.Value = "всего";
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region в том числе неденежные

				range = sheet.get_Range("H4").Cells;
				range.Value = "в том числе неденежные";
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region долгосрочная

				range = sheet.get_Range("J4").Cells;
				range.Value = "долгосрочная";
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region просроченная

				range = sheet.get_Range("K4").Cells;
				range.Value = "просроченная";
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region долгосрочная

				range = sheet.get_Range("M4").Cells;
				range.Value = "долгосрочная";
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region просроченная

				range = sheet.get_Range("N4").Cells;
				range.Value = "просроченная";
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#endregion

				#region Шапка с объединениями

				#region Номер (код) счета бюджетного учета

				Excel.Range _excelRowRande = sheet.get_Range("A1", "A4").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "Номер (код) счета бюджетного учета";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region Сумма задолженности, руб

				_excelRowRande = sheet.get_Range("B1", "N1").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "Сумма задолженности, руб";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region на начало года

				_excelRowRande = sheet.get_Range("B2", "D2").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "на начало года";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region изменение задолженности

				_excelRowRande = sheet.get_Range("E2", "H2").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "изменение задолженности";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region на конец отчетного периода

				_excelRowRande = sheet.get_Range("I2", "K2").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "на конец отчетного периода";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region на конец аналогичного периода прошлого финансового года

				_excelRowRande = sheet.get_Range("L2", "N2").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "на конец аналогичного периода прошлого финансового года";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region из них:

				_excelRowRande = sheet.get_Range("C3", "D3").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "из них:";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region увеличение

				_excelRowRande = sheet.get_Range("E3", "F3").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "увеличение";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region уменьшение

				_excelRowRande = sheet.get_Range("G3", "H3").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "уменьшение";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region из них:

				_excelRowRande = sheet.get_Range("J3", "K3").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "из них:";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region из них:

				_excelRowRande = sheet.get_Range("M3", "N3").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "из них:";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region всего

				_excelRowRande = sheet.get_Range("B3", "B4").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "всего";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region всего

				_excelRowRande = sheet.get_Range("I3", "I4").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "всего";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region всего

				_excelRowRande = sheet.get_Range("L3", "L4").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "всего";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#endregion

				#region Номера в шапке

				for (int number = 1; number <= 14; number++)
					sheet.Cells[5, number] = number;
				range = sheet.get_Range("A5", "N5").Cells;
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlInsideHorizontal).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlInsideVertical).LineStyle = XlLineStyle.xlContinuous;
				range.EntireColumn.AutoFit();
				range.EntireRow.AutoFit();
				range.HorizontalAlignment = Constants.xlCenter;
				range.VerticalAlignment = Constants.xlCenter;

				#endregion

				List<TableFirst> table = DbContextApp.GetDbContextApp.TableFirsts.ToList();
				var res = table.RemoveAll
				(
					item =>
						string.IsNullOrEmpty(item.A1)
						&& string.IsNullOrEmpty(item.B1)
						&& string.IsNullOrEmpty(item.V1)
						&& string.IsNullOrEmpty(item.G1)
				);
				int excelRow = 5;

				for (int rowIndex = 0; rowIndex < table.Count(); rowIndex++)
				{
					excelRow++;

					if (table[rowIndex].A1.Replace(" ", string.Empty) == string.Empty
					    && table[rowIndex].B1.Replace(" ", string.Empty) == string.Empty
					    && table[rowIndex].V1.Replace(" ", string.Empty) == string.Empty
					    && table[rowIndex].G1.Replace(" ", string.Empty) == string.Empty)
					{
						excelRow -= 1;

						continue;
					}

					string value = string.Join(" ", table[rowIndex].A1, table[rowIndex].B1, table[rowIndex].V1, table[rowIndex].G1);

					range = sheet.get_Range($"A{excelRow}").Cells;
					range.Value = value;

					range = sheet.get_Range($"B{excelRow}").Cells;
					range.Value = table[rowIndex].X2 == default ? "-" : table[rowIndex].X2.ToString();

					range = sheet.get_Range($"C{excelRow}").Cells;
					range.Value = table[rowIndex].X3 == default ? "-" : table[rowIndex].X3.ToString();

					range = sheet.get_Range($"D{excelRow}").Cells;
					range.Value = table[rowIndex].X4 == default ? "-" : table[rowIndex].X4.ToString();

					range = sheet.get_Range($"E{excelRow}").Cells;
					range.Value = table[rowIndex].X5 == default ? "-" : table[rowIndex].X5.ToString();

					range = sheet.get_Range($"F{excelRow}").Cells;
					range.Value = table[rowIndex].X6 == default ? "-" : table[rowIndex].X6.ToString();

					range = sheet.get_Range($"G{excelRow}").Cells;
					range.Value = table[rowIndex].X7 == default ? "-" : table[rowIndex].X7.ToString();

					range = sheet.get_Range($"H{excelRow}").Cells;
					range.Value = table[rowIndex].X8 == default ? "-" : table[rowIndex].X8.ToString();

					range = sheet.get_Range($"I{excelRow}").Cells;
					range.Value = table[rowIndex].X9 == default ? "-" : table[rowIndex].X9.ToString();

					range = sheet.get_Range($"J{excelRow}").Cells;
					range.Value = table[rowIndex].X10 == default ? "-" : table[rowIndex].X10.ToString();

					range = sheet.get_Range($"K{excelRow}").Cells;
					range.Value = table[rowIndex].X11 == default ? "-" : table[rowIndex].X11.ToString();

					range = sheet.get_Range($"L{excelRow}").Cells;
					range.Value = table[rowIndex].X12 == default ? "-" : table[rowIndex].X12.ToString();

					range = sheet.get_Range($"M{excelRow}").Cells;
					range.Value = table[rowIndex].X13 == default ? "-" : table[rowIndex].X13.ToString();

					range = sheet.get_Range($"N{excelRow}").Cells;
					range.Value = table[rowIndex].X14 == default ? "-" : table[rowIndex].X14.ToString();

				}

				(sheet.Cells[table.Count + 5 + 1, 1] as Excel.Range).Value = "Всего задолженности: ";
				(sheet.Cells[table.Count + 5 + 1, 2] as Excel.Range).Formula = $"=SUM(B6:B{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 3] as Excel.Range).Formula = $"=SUM(C6:C{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 4] as Excel.Range).Formula = $"=SUM(D6:D{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 5] as Excel.Range).Formula = $"=SUM(E6:E{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 6] as Excel.Range).Formula = $"=SUM(F6:F{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 7] as Excel.Range).Formula = $"=SUM(G6:G{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 8] as Excel.Range).Formula = $"=SUM(H6:H{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 9] as Excel.Range).Formula = $"=SUM(I6:I{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 10] as Excel.Range).Formula = $"=SUM(J6:J{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 11] as Excel.Range).Formula = $"=SUM(K6:K{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 12] as Excel.Range).Formula = $"=SUM(L6:L{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 13] as Excel.Range).Formula = $"=SUM(M6:M{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 14] as Excel.Range).Formula = $"=SUM(N6:N{table.Count + 5})";

				sheet.Calculate();

				range = sheet.get_Range("A6", $"N{table.Count + 5 + 1}").Cells;
				FormaterRange(range);



				sheet.SaveAs(Path);
				ex.Quit();
            }
			catch (Exception exception)
			{
				Logger.Logger.Error(exception, nameof(LoaderXlsx), nameof(LoadXmlFile));

				throw;
			}
		}

		public void LoadXmlFile(IList<TableFirst> tableFirsts)
		{
			try
			{

				if (File.Exists(Path))
				{
					File.Delete(Path);
				}

				//TODO: Проверить, есть ли вообще Excel на ПК
				Application ex = new Application();

#if DEBUG
				ex.Visible = true;
#endif
				try
				{
					ex.Workbooks.Open(Path,
				Type.Missing, Type.Missing, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing);
				}
				catch
				{
					Workbook workBook = ex.Workbooks.Add(Type.Missing);
				}


				Worksheet sheet = (Worksheet)ex.Worksheets.get_Item(1);
				sheet.Name = "Бюджет";

				#region Одиночные ячейки в шапке

				#region долгосрочная

				Excel.Range range = sheet.get_Range("C4").Cells;
				range.Value = "долгосрочная";
				range.EntireColumn.AutoFit();
				range.EntireRow.AutoFit();
				range.HorizontalAlignment = Constants.xlCenter;
				range.VerticalAlignment = Constants.xlCenter;
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region просроченная

				range = sheet.get_Range("D4").Cells;
				range.Value = "просроченная";
				range.EntireColumn.AutoFit();
				range.EntireRow.AutoFit();
				range.HorizontalAlignment = Constants.xlCenter;
				range.VerticalAlignment = Constants.xlCenter;
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region всего

				range = sheet.get_Range("E4").Cells;
				range.Value = "всего";
				range.EntireColumn.AutoFit();
				range.EntireRow.AutoFit();
				range.HorizontalAlignment = Constants.xlCenter;
				range.VerticalAlignment = Constants.xlCenter;
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region в том числе неденежные

				range = sheet.get_Range("F4").Cells;
				range.Value = "в том числе неденежные";
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region всего

				range = sheet.get_Range("G4").Cells;
				range.Value = "всего";
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region в том числе неденежные

				range = sheet.get_Range("H4").Cells;
				range.Value = "в том числе неденежные";
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region долгосрочная

				range = sheet.get_Range("J4").Cells;
				range.Value = "долгосрочная";
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region просроченная

				range = sheet.get_Range("K4").Cells;
				range.Value = "просроченная";
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region долгосрочная

				range = sheet.get_Range("M4").Cells;
				range.Value = "долгосрочная";
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region просроченная

				range = sheet.get_Range("N4").Cells;
				range.Value = "просроченная";
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#endregion

				#region Шапка с объединениями

				#region Номер (код) счета бюджетного учета

				Excel.Range _excelRowRande = sheet.get_Range("A1", "A4").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "Номер (код) счета бюджетного учета";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region Сумма задолженности, руб

				_excelRowRande = sheet.get_Range("B1", "N1").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "Сумма задолженности, руб";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region на начало года

				_excelRowRande = sheet.get_Range("B2", "D2").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "на начало года";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region изменение задолженности

				_excelRowRande = sheet.get_Range("E2", "H2").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "изменение задолженности";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region на конец отчетного периода

				_excelRowRande = sheet.get_Range("I2", "K2").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "на конец отчетного периода";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region на конец аналогичного периода прошлого финансового года

				_excelRowRande = sheet.get_Range("L2", "N2").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "на конец аналогичного периода прошлого финансового года";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region из них:

				_excelRowRande = sheet.get_Range("C3", "D3").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "из них:";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region увеличение

				_excelRowRande = sheet.get_Range("E3", "F3").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "увеличение";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region уменьшение

				_excelRowRande = sheet.get_Range("G3", "H3").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "уменьшение";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region из них:

				_excelRowRande = sheet.get_Range("J3", "K3").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "из них:";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region из них:

				_excelRowRande = sheet.get_Range("M3", "N3").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "из них:";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region всего

				_excelRowRande = sheet.get_Range("B3", "B4").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "всего";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region всего

				_excelRowRande = sheet.get_Range("I3", "I4").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "всего";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#region всего

				_excelRowRande = sheet.get_Range("L3", "L4").Cells;
				_excelRowRande.Merge(Type.Missing);
				_excelRowRande.Value = "всего";
				_excelRowRande.EntireColumn.AutoFit();
				_excelRowRande.EntireRow.AutoFit();
				_excelRowRande.HorizontalAlignment = Constants.xlCenter;
				_excelRowRande.VerticalAlignment = Constants.xlCenter;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				_excelRowRande.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

				#endregion

				#endregion

				#region Номера в шапке

				for (int number = 1; number <= 14; number++)
					sheet.Cells[5, number] = number;
				range = sheet.get_Range("A5", "N5").Cells;
				range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlInsideHorizontal).LineStyle = XlLineStyle.xlContinuous;
				range.Borders.get_Item(XlBordersIndex.xlInsideVertical).LineStyle = XlLineStyle.xlContinuous;
				range.EntireColumn.AutoFit();
				range.EntireRow.AutoFit();
				range.HorizontalAlignment = Constants.xlCenter;
				range.VerticalAlignment = Constants.xlCenter;

				#endregion

				List<TableFirst> table = tableFirsts.ToList();
				var res = table.RemoveAll
				(
					item =>
						string.IsNullOrEmpty(item.A1)
						&& string.IsNullOrEmpty(item.B1)
						&& string.IsNullOrEmpty(item.V1)
						&& string.IsNullOrEmpty(item.G1)
				);
				int excelRow = 5;

				for (int rowIndex = 0; rowIndex < table.Count(); rowIndex++)
				{
					excelRow++;

					if (table[rowIndex].A1.Replace(" ", string.Empty) == string.Empty
						&& table[rowIndex].B1.Replace(" ", string.Empty) == string.Empty
						&& table[rowIndex].V1.Replace(" ", string.Empty) == string.Empty
						&& table[rowIndex].G1.Replace(" ", string.Empty) == string.Empty)
					{
						excelRow -= 1;

						continue;
					}

					string value = string.Join(" ", table[rowIndex].A1, table[rowIndex].B1, table[rowIndex].V1, table[rowIndex].G1);

					range = sheet.get_Range($"A{excelRow}").Cells;
					range.Value = value;

					range = sheet.get_Range($"B{excelRow}").Cells;
					range.Value = table[rowIndex].X2 == default ? "-" : table[rowIndex].X2.ToString();

					range = sheet.get_Range($"C{excelRow}").Cells;
					range.Value = table[rowIndex].X3 == default ? "-" : table[rowIndex].X3.ToString();

					range = sheet.get_Range($"D{excelRow}").Cells;
					range.Value = table[rowIndex].X4 == default ? "-" : table[rowIndex].X4.ToString();

					range = sheet.get_Range($"E{excelRow}").Cells;
					range.Value = table[rowIndex].X5 == default ? "-" : table[rowIndex].X5.ToString();

					range = sheet.get_Range($"F{excelRow}").Cells;
					range.Value = table[rowIndex].X6 == default ? "-" : table[rowIndex].X6.ToString();

					range = sheet.get_Range($"G{excelRow}").Cells;
					range.Value = table[rowIndex].X7 == default ? "-" : table[rowIndex].X7.ToString();

					range = sheet.get_Range($"H{excelRow}").Cells;
					range.Value = table[rowIndex].X8 == default ? "-" : table[rowIndex].X8.ToString();

					range = sheet.get_Range($"I{excelRow}").Cells;
					range.Value = table[rowIndex].X9 == default ? "-" : table[rowIndex].X9.ToString();

					range = sheet.get_Range($"J{excelRow}").Cells;
					range.Value = table[rowIndex].X10 == default ? "-" : table[rowIndex].X10.ToString();

					range = sheet.get_Range($"K{excelRow}").Cells;
					range.Value = table[rowIndex].X11 == default ? "-" : table[rowIndex].X11.ToString();

					range = sheet.get_Range($"L{excelRow}").Cells;
					range.Value = table[rowIndex].X12 == default ? "-" : table[rowIndex].X12.ToString();

					range = sheet.get_Range($"M{excelRow}").Cells;
					range.Value = table[rowIndex].X13 == default ? "-" : table[rowIndex].X13.ToString();

					range = sheet.get_Range($"N{excelRow}").Cells;
					range.Value = table[rowIndex].X14 == default ? "-" : table[rowIndex].X14.ToString();

				}

				(sheet.Cells[table.Count + 5 + 1, 1] as Excel.Range).Value = "Всего задолженности: ";
				(sheet.Cells[table.Count + 5 + 1, 2] as Excel.Range).Formula = $"=SUM(B6:B{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 3] as Excel.Range).Formula = $"=SUM(C6:C{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 4] as Excel.Range).Formula = $"=SUM(D6:D{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 5] as Excel.Range).Formula = $"=SUM(E6:E{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 6] as Excel.Range).Formula = $"=SUM(F6:F{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 7] as Excel.Range).Formula = $"=SUM(G6:G{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 8] as Excel.Range).Formula = $"=SUM(H6:H{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 9] as Excel.Range).Formula = $"=SUM(I6:I{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 10] as Excel.Range).Formula = $"=SUM(J6:J{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 11] as Excel.Range).Formula = $"=SUM(K6:K{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 12] as Excel.Range).Formula = $"=SUM(L6:L{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 13] as Excel.Range).Formula = $"=SUM(M6:M{table.Count + 5})";
				(sheet.Cells[table.Count + 5 + 1, 14] as Excel.Range).Formula = $"=SUM(N6:N{table.Count + 5})";

				sheet.Calculate();

				range = sheet.get_Range("A6", $"N{table.Count + 5 + 1}").Cells;
				FormaterRange(range);



				sheet.SaveAs(Path);
				ex.Quit();
			}
			catch (Exception exception)
			{
				Logger.Logger.Error(exception, nameof(LoaderXlsx), nameof(LoadXmlFile));

				throw;
			}
		}

		#endregion

	}

}