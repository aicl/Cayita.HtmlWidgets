namespace Cayita.HtmlWidgets
{
	public class HtmlCell:CellBase{
		internal protected HtmlCell():base("td"){}
	}

	public class HtmlHeaderCell:CellBase
	{
		public HtmlHeaderCell():base("th"){}

	}

	public class HtmlFooterCell:CellBase{
		public HtmlFooterCell():base("th"){}
	}


}

