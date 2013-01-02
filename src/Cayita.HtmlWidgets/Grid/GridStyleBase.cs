using Cayita.HtmlWidgets.Core;

namespace Cayita.HtmlWidgets
{
	public abstract class GridStyleBase{

		public HtmlStyle TitleStyle {get;set;}  //p

		public HtmlStyle FootNoteStyle {get;set;}  //p

		public HtmlRowStyle RowStyle {get;set;}  // tr

		public HtmlRowStyle AlternateRowStyle {get;set;} //tr

		public HtmlTableStyle TableStyle {get;set;}      //table

		// GridColumn Style:

		public HtmlCellStyle CellStyle {get;set;}  // td

		public HtmlTableStyle HeaderStyle {get;set;} // thead style

		public HtmlCellStyle HeaderCellStyle {get;set;}  // cell style  th

		public HtmlTableStyle FooterStyle {get;set;} // tfoot style

		public HtmlCellStyle FooterCellStyle {get;set;}  // cell style  th

		public HtmlStyle HeaderTextStyle {get;set;}  //  p

		public GridStyleBase(){
			RowStyle = new HtmlRowStyle();
			AlternateRowStyle = new HtmlRowStyle();
			CellStyle = new HtmlCellStyle();
			TableStyle = new HtmlTableStyle();
			//TableStyle.FontFamily="Century Gothic, Arial, Helvetica, sans-serif";
			//TableStyle.FontSize.Value=95;
			TableStyle.FontSize.Unit="%";
			HeaderStyle= new HtmlTableStyle();
			FooterStyle = new HtmlTableStyle();
			TitleStyle = new HtmlStyle();
			FootNoteStyle = new HtmlStyle();
			HeaderCellStyle= new HtmlCellStyle();
			FooterCellStyle = new HtmlCellStyle();
			HeaderTextStyle = new HtmlStyle();
		}
	}
}

