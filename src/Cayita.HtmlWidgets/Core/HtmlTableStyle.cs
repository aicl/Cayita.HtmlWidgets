using Cayita.HtmlWidgets.Core;

namespace Cayita.HtmlWidgets
{
	public class HtmlTableStyle:ElementStyleBase{

		public HtmlTableStyle():base(){
			Border= new TableBorderProperty();
		}
	}
	
}
