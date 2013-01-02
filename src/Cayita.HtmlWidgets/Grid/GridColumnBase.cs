using System;
using Cayita.HtmlWidgets.Core;

namespace Cayita.HtmlWidgets
{
	public abstract class GridColumnBase <T>
	{
		public string HeaderText{get;set;}

		public HtmlStyle HeaderTextSytle{get;set;}  //p

		public HtmlCellStyle HeaderCellStyle {get;set;}  // cell style  th for header 

		public HtmlCellStyle FooterCellStyle {get;set;}  // cell style  th for summary rows

		public HtmlCellStyle CellStyle {get;set;}  // stilo de las celdas con el valor 

		public int? HeaderCellColumnSpan {get;set;}

		public int? FooterCellColumnSpan {get;set;}

		public  Func<T,int,CellBase,object> CellRenderFunc{
			get;set;
		}

		public  Func<object> FooterRenderFunc{ // footer

			get;set;
		}

		public bool Hidden{get;set;}

		protected internal GridColumnBase(){
			CellStyle= new HtmlCellStyle();
			HeaderCellStyle=new HtmlCellStyle();
			HeaderTextSytle = new HtmlStyle();
			FooterCellStyle = new HtmlCellStyle();
			Hidden=false;
		}

	}
}

