using ServiceStack.Html;
using System;
using Cayita.HtmlWidgets.Core;

namespace Cayita.HtmlWidgets
{
	public abstract class TableBase:TagBase
	{
		public int RowsCount{get; protected set;}

		public HtmlRowStyle RowStyle{get;set;}
		public HtmlRowStyle AlternateRowStyle { get;set;}

		protected internal TableBase (string tagName):base(tagName){
			Style = new HtmlTableStyle();
			RowsCount=0;
			RowStyle = new HtmlRowStyle();
			AlternateRowStyle= new HtmlRowStyle();
		}

		public virtual void AddRow(Action<RowBase> rowConfig, string alternateRowCss=null){
			HtmlRow row = new HtmlRow();
			row.Parent=this;
			ApplyStyleToRow (row, alternateRowCss);
			RowsCount++;
			rowConfig(row);
			InnerHtml=InnerHtml+row.ToString();
		}

		protected void ApplyStyleToRow ( RowBase row, string alternateRowCss=null)
		{
			if (RowsCount % 2 == 0)
				row.Style = RowStyle;
			else {
				row.Style = AlternateRowStyle ?? RowStyle;
				if (!string.IsNullOrEmpty (alternateRowCss))
					row.Attributes ["class"] = alternateRowCss;
			}
		}

	}
}

