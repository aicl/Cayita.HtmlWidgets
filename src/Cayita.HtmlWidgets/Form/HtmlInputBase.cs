using ServiceStack.Html;


namespace Cayita.HtmlWidgets.Core
{

	public abstract class HtmlInputBase:TagBase{

		public HtmlInputBase():base("input"){
			TagRenderMode= TagRenderMode.SelfClosing;
			Type="text";
		}

		public string Value{
			get{
				string val;
				return Attributes.TryGetValue("value", out val)? val:string.Empty;
			}
			set{
				Attributes["value"]= value;
			}
		}

		public string Type{
			get{
				string inputType;
				return Attributes.TryGetValue("type", out inputType)? inputType:string.Empty;
			}
			set{
				Attributes["type"]= value;
			}
		}

		public string Placeholder{
			get{
				string placeholder;
				return Attributes.TryGetValue("placeholder", out placeholder)? placeholder:string.Empty;
			}
			set{
				Attributes["placeholder"]= value;
			}
		}

		public bool Required{
			get{
				string required;
				return Attributes.TryGetValue("required", out required);
			}
			set{
				if(value) Attributes["required"]= "true";
				else if(Attributes.ContainsKey("required")) Attributes.Remove("required");
			}
		}

		public bool AriaRequired{
			get{
				string required;
				return Attributes.TryGetValue("aria-required", out required);
			}
			set{
				if(value) Attributes["aria-required"]= "true";
				else if(Attributes.ContainsKey("aria-required")) Attributes.Remove("aria-required");
			}
		}

	}

	/*
	 <label class="checkbox">
              <input type="checkbox" value="Option one"> Option one 1 
     </label>

	*/

}
