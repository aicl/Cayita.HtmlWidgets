using System;

namespace Cayita.HtmlWidgets
{
	public class HtmlTableHeader:TableBase
	{
		protected internal HtmlTableHeader ():base("thead"){}

		public override void AddRow(Action<RowBase> rowConfig, string alternateRowCss=null){
			HtmlHeaderRow row = new HtmlHeaderRow();
			ApplyStyleToRow (row, alternateRowCss);
			RowsCount++;
			rowConfig(row);
			InnerHtml=InnerHtml+row.ToString();
		}

	}

}

