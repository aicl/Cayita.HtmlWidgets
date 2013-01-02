using System;

namespace Cayita.HtmlWidgets.Core
{

	public abstract class BorderPropertyBase{

		public BorderPropertyBase(){
			Width = new BorderWidthProperty();
			Radius = new BorderRadiusProperty();
		}

		public BorderWidthProperty Width {get;set;}
		public BorderRadiusProperty Radius {get;set;}
		public string Style {get;set;}
		public string Color {get;set;}
		public override string ToString(){
		
			var bw= Width==default(BorderWidthProperty)? string.Empty: Width.ToString();
			var st = string.IsNullOrEmpty(Style)?string.Empty: string.Format("border-style:{0};",Style);
			var cl = string.IsNullOrEmpty(Color)?string.Empty: string.Format("border-color:{0};",Color);
			var br= Radius==default(BorderRadiusProperty)? string.Empty: Radius.ToString();
			return string.Format("{0}{1}{2}{3}",
			                     bw,st,cl,br).Trim();
		}
	}


}

