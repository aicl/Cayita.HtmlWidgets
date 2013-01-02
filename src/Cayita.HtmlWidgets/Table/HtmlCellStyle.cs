using Cayita.HtmlWidgets.Core;
namespace Cayita.HtmlWidgets
{
	public class HtmlCellStyle:ElementStyleBase{

		public HtmlCellStyle():base(){
			Border= new CellBorderProperty();
		}
	}
}

