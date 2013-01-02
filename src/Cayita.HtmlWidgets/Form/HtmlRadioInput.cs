using ServiceStack.Html;
using ServiceStack.Common;
using ServiceStack.Text;
using Cayita.HtmlWidgets.Core;

namespace Cayita.HtmlWidgets
{

	public class HtmlRadioInput:HtmlInputBase{

		public HtmlRadioInput():base(){
			Type="radio";
		}

		public bool Inline{get;set;}

		public string Label {get;set;}

		public bool Checked{
			get{
				string checked_;
				return Attributes.TryGetValue("checked", out checked_);
			}
			set{
				if(value) Attributes["checked"]= "true";
				else if(Attributes.ContainsKey("checked")) Attributes.Remove("checked");
			}
		}

		public override string ToString ()
		{
			HtmlLabel l = new HtmlLabel(){Class="radio{0}".Fmt(Inline?" inline":"")};
			l.InnerHtml = base.ToString();
			if(!Label.IsNullOrEmpty())  l.InnerHtml= l.InnerHtml+Label;
			return l.ToString();
		}
	}

}
