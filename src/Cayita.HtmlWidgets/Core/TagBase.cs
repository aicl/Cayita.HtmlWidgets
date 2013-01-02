using System;
using ServiceStack.Common;
using ServiceStack.Html;
using ServiceStack.Text;


namespace Cayita.HtmlWidgets.Core
{
	public abstract class TagBase:TagBuilder{  

		public TagBase(string tagName):base(tagName){

			TagRenderMode= TagRenderMode.Normal;

		}

		public TagRenderMode TagRenderMode{get;set;}


		public string Class{
			get{
			
				string cl;
				return Attributes.TryGetValue("class", out cl)? cl:string.Empty;
			}
			set{
				Attributes["class"]= value;
			}
		}


		public string Name{
			get{
			
				string name;
				return Attributes.TryGetValue("name", out name)? name:string.Empty;
			}
			set{
				Attributes["name"]= value;
			}
		}


		public virtual ElementStyleBase Style {get;set;}

		public string Id {
			get{
				string id;
				return Attributes.TryGetValue("id", out id)? id:string.Empty;
			}
			set{
				Attributes["id"]= value;
			}
		}

		public void AddStyle (string value, bool append=true)
		{

			string text;
			if (Attributes.TryGetValue ("style", out text))
			{
				string v;
				if(append)
					v= "{0}{1}{2}".Fmt(text, text.Trim().EndsWith(";")?"":";", value);
				else
					v= "{0}{1}{2}".Fmt(value, value.Trim().EndsWith(";")?"":";", text);

				Attributes["style"]=  v;
			}
			else
			{
				Attributes["style"]= value;
			}

		}


		public virtual void AddHtmlTag(TagBase tag){
			InnerHtml= InnerHtml+ tag;
		}

		public override string ToString ()
		{

			string oldStyle=string.Empty;
			Attributes.TryGetValue ("style", out oldStyle);
			BuildStyleAttribue();
			var r = base.ToString(TagRenderMode);
			if(!oldStyle.IsNullOrEmpty())Attributes["style"]= oldStyle;

			return r;
		}


		protected void BuildStyleAttribue(){

			if( Style!=default(ElementStyleBase) ){

				var s = Style.ToString();
				if( !string.IsNullOrEmpty(s)) AddStyle(s,false);

			}
		}


	}

}

