using System;

namespace Cayita.HtmlWidgets
{
	public class HtmlTableFooter:TableBase{

		public HtmlTableFooter():base("tfoot"){}

		public override void AddRow(Action<RowBase> rowConfig, string alternateRowCss=null){
			HtmlFooterRow row = new HtmlFooterRow();
			ApplyStyleToRow (row, alternateRowCss);
			RowsCount++;
			rowConfig(row);
			InnerHtml=InnerHtml+row.ToString();
		}
	}
}

