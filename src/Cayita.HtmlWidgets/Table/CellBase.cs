using Cayita.HtmlWidgets.Core;
using Cayita.HtmlWidgets.Common;
namespace Cayita.HtmlWidgets
{
	public abstract class CellBase:TagBase{

		internal protected CellBase(string tagName):base(tagName){
			Style = new HtmlCellStyle();
		}

		public RowBase Parent {get;  set;}

		public int? ColumnSpan{
			get{ 
				int? r=null;
				string v;
				if(Attributes.TryGetValue("colspan", out v)){
					int i;
					if (int.TryParse(v, out i)) r=i; 
				}
				return r;
			}
			set{
				if(value.HasValue && value.Value!=default(int))
					Attributes["colspan"]= value.Value.ToString();
				else
					if(Attributes.ContainsKey("colspan")) Attributes.Remove("colspan");
			}
		}

		public void SetValue(object value){
			InnerHtml= value!=null?value.ToString():"";
		}

		public void SetValue(){
			InnerHtml= Extensions.HtmlSpace;
		}

	}

}

