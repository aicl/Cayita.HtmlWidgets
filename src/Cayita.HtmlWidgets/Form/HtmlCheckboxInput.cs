using ServiceStack.Common;
using ServiceStack.Text;
using Cayita.HtmlWidgets.Core;

namespace Cayita.HtmlWidgets
{

	public class HtmlCheckboxInput:HtmlInputBase{

		public HtmlCheckboxInput():base(){
			Type="checkbox";
			Value="true";
		}

		public string Label {get;set;}

		public bool Inline{get;set;}

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
			HtmlLabel l = new HtmlLabel(){Class="checkbox{0}".Fmt(Inline?" inline":"")};
			if(!Label.IsNullOrEmpty())  l.InnerHtml= l.InnerHtml+Label;
			l.InnerHtml = base.ToString();
			return l.ToString();
		}
	}

	/*
	 <label class="checkbox">
              <input type="checkbox" value="Option one"> Option one 1 
     </label>

	*/

}
