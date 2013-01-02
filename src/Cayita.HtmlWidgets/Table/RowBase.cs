using ServiceStack.Html;
using System;
using Cayita.HtmlWidgets.Core;

namespace Cayita.HtmlWidgets
{
	public abstract class RowBase:TagBuilder{

		protected internal RowBase():base("tr"){
			Style= new HtmlRowStyle();
		}

		public TableBase Parent {get;set;}

		public StyleBase Style{get;set;}

		public HtmlCellStyle CellStyle{get;set;}

		public string Id {
			get{
				string id;
				return Attributes.TryGetValue("id", out id)? id:string.Empty;
			}
			set{
				Attributes["id"]= value;
			}
		}



		public virtual void AddCell(Action<CellBase> config){
			HtmlCell cell = new HtmlCell();
			if(CellStyle!=default(HtmlCellStyle)) cell.Style= CellStyle;
			cell.Parent=this;
			config(cell);
			InnerHtml=InnerHtml+cell.ToString();
		}


		public int? RowSpan {get;set;}

		public override string ToString ()
		{
			if (RowSpan.HasValue && RowSpan.Value!=default(int))
				Attributes["rowspan"]=RowSpan.Value.ToString();

			if( Style!=default(StyleBase) ){
				var s = Style.ToString();
				if( !string.IsNullOrEmpty(s)) Attributes["style"]= Style.ToString();
			}

			return base.ToString(TagRenderMode.Normal);
		}

	}
}

