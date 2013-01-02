using System;

namespace Cayita.HtmlWidgets.Core
{


	public abstract class ElementStyleBase:StyleBase{

		public ElementStyleBase():base(){}

		public virtual BorderPropertyBase Border {get;set;}

		public override string ToString ()
		{
			var r= base.ToString();
			var v = r + (Border==default(BorderPropertyBase)?string.Empty: Border.ToString());
			return string.IsNullOrEmpty(v)?string.Empty:v;

		}
	}


	public abstract class StyleBase{  

		public StyleBase()
		{
			Width = new WidthProperty();
			Height= new HeightProperty();
			Padding = new PaddingProperty();
			Margin = new MarginProperty();
			FontSize = new FontSizeProperty();

			Color=string.Empty;
			BackgroundColor=string.Empty;
			Hidden=false;
		}

		public WidthProperty Width {get;set;}
		public HeightProperty Height  {get;set;}
		public PaddingProperty Padding {get;set;}
		public MarginProperty Margin {get;set;}

		public string BackgroundColor {get;set;}

		public FontSizeProperty FontSize{get;set;}
		public string FontWeight{get;set;}
		public string FontStyle{get;set;}
		public string FontFamily{get;set;}
		public string TextAlign {get;set;}

		public string Color {get;set;}
		public bool Hidden {get;set;}

		public override string ToString ()
		{
			var r= string.Format ("{0}{1}{2}{3}{4}", Width, Height, Padding,Margin, FontSize);

			if(!string.IsNullOrEmpty(BackgroundColor)) 
				r=string.Format("{0} background-color:{1};",r, BackgroundColor);
			if(!string.IsNullOrEmpty(Color)) 
				r=string.Format("{0} color:{1};",r, Color);

			if(!string.IsNullOrEmpty(FontWeight)) 
				r=string.Format("{0} font-weight:{1};",r, FontWeight);
			if(!string.IsNullOrEmpty(FontStyle)) 
				r=string.Format("{0} font-style:{1};",r, FontStyle);
			if(!string.IsNullOrEmpty(FontFamily)) 
				r=string.Format("{0} font-family:{1};",r, FontFamily);
			if(!string.IsNullOrEmpty(TextAlign)) 
				r=string.Format("{0} text-align:{1};",r, TextAlign);
			if(Hidden)
				r=string.Format("{0} display:none;",r);

			var v = r.Trim();
			return string.IsNullOrEmpty(v)?string.Empty:v;
		}
	}
}
