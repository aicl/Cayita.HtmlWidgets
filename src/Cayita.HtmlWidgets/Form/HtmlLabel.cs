using Cayita.HtmlWidgets.Core;

namespace Cayita.HtmlWidgets
{

	public class HtmlLabel:TagBase{
		public HtmlLabel():base("label"){
			Class="control-label";
		}

		public string For{
			get{
				string forInput;
				return Attributes.TryGetValue("for", out forInput)? forInput:string.Empty;
			}
			set{
				Attributes["for"]= value;
			}
		}

	}


}
