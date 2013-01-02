using System.Collections.Generic;
using ServiceStack.Common.Extensions;

namespace Cayita.HtmlWidgets
{

	public class HtmlGrid<T>:GridBase<T>{

		public HtmlGrid():base(){
			GridStyle = new HtmlGridStyle();
			Columns = new List<GridColumnBase<T>>();
		}

		public override GridColumnBase<T> CreateGridColumn(){

			GridColumn<T> gc = new GridColumn<T>();

			if(GridStyle!=default(GridStyleBase)){
				gc.CellStyle.PopulateWith(GridStyle.CellStyle);
				gc.HeaderCellStyle.PopulateWith(GridStyle.HeaderCellStyle);  // th
				gc.HeaderTextSytle.PopulateWith(GridStyle.HeaderTextStyle);  // p
				gc.FooterCellStyle.PopulateWith(GridStyle.FooterCellStyle);  // th
			} 

			return gc;
		}

	}

	public class HtmlGridSimple<T>:HtmlGrid<T>{
		public HtmlGridSimple():base(){
			OmitFooter=true;
			OmitHeader=true;
		}
	}

}


