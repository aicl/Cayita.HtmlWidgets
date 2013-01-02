using System;

namespace Cayita.HtmlWidgets
{
	public class HtmlRow:RowBase{
		protected internal HtmlRow():base(){}
	}

	public class HtmlHeaderRow:RowBase{
		protected internal HtmlHeaderRow():base(){}


		public override void AddCell(Action<CellBase> config){
			HtmlHeaderCell cell = new HtmlHeaderCell();
			if(CellStyle!=default(HtmlCellStyle)) cell.Style= CellStyle;
			cell.Parent=this;
			config(cell);
			InnerHtml=InnerHtml+cell.ToString();
		}

	}

	public class HtmlFooterRow:RowBase{
		protected internal HtmlFooterRow():base(){}

		public override void AddCell(Action<CellBase> config){
			HtmlFooterCell cell = new HtmlFooterCell();
			if(CellStyle!=default(HtmlCellStyle)) cell.Style= CellStyle;
			cell.Parent=this;
			config(cell);
			InnerHtml=InnerHtml+cell.ToString();
		}
	}

}

