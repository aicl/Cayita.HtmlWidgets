using System;
using Cayita.HtmlWidgets.Core;

namespace Cayita.HtmlWidgets
{

	public class TableBorderProperty:BorderPropertyBase{
		public TableBorderProperty():base(){}

		public int? AllBorderSpacing {get;set;}
		public int? HorizontalBorderSpacing {get;set;}
		public int? VerticalBorderSpacing {get;set;}

		public string Collapse{get;set;}

		public override string ToString ()
		{
			string bs=string.Empty;
			if(VerticalBorderSpacing.HasValue){
				bs=string.Format("border-spacing:{0}px {1}px",HorizontalBorderSpacing??(AllBorderSpacing??0), VerticalBorderSpacing );
			}
			else if(HorizontalBorderSpacing.HasValue){
				bs=string.Format("border-spacing:{0}px{1}",HorizontalBorderSpacing,
				                 AllBorderSpacing.HasValue? string.Format(" {0}px",AllBorderSpacing):string.Empty );
			}
			else{
				bs= AllBorderSpacing.HasValue? string.Format("border-spacing:{0}px",AllBorderSpacing):string.Empty;
			}

			var bc = string.IsNullOrEmpty(Collapse)?string.Empty: string.Format("border-collapse:{0};",Collapse);
			return base.ToString()+  string.Format("{0}{1}",bc,bs).Trim();
		}
	}

}
