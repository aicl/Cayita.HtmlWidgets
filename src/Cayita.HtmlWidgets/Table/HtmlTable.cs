using ServiceStack.Html;
namespace Cayita.HtmlWidgets
{

	public class HtmlTable:TableBase
	{
		public HtmlTable ():base("table"){
			Header= new HtmlTableHeader();
			Footer = new HtmlTableFooter();
		}

		public HtmlTableHeader Header {
			get; set;
		}

		public HtmlTableFooter Footer {
			get; set;
		}

		public override string ToString ()
		{

			var oldInner = InnerHtml;
			InnerHtml="";

			if(Footer!=default(HtmlTableFooter)){
				InnerHtml= Footer.ToString()+ InnerHtml;
			}

			if(Header!=default(HtmlTableHeader)){
				InnerHtml= Header.ToString()+ InnerHtml;
			}

			var tbody= new TagBuilder("tbody");
			tbody.InnerHtml= oldInner;
			InnerHtml = InnerHtml+ tbody.ToString(TagRenderMode.Normal);

			var r= base.ToString();
			InnerHtml= oldInner;

			return r;
		}

	}

}
