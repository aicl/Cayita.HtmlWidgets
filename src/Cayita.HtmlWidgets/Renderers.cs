using System;

namespace Cayita.HtmlWidgets
{
	public  static  class Renderers
	{

		public static HtmlParagragh HtmlFormat(this bool value, string trueValue="Yes", string falseValue="No",
		                                   HtmlStyle styleIf=null, 
		                                   HtmlStyle styleElse=null){
			HtmlStyle style = (value? styleIf: styleElse)?? new HtmlStyle(){TextAlign="center" };

			return new HtmlParagragh{
				Style=style,
				Text= value? trueValue: falseValue
			};
		}

		public static HtmlParagragh HtmlFormat(this bool? value, string trueValue="Yes", string falseValue="No",
		                                   HtmlStyle styleIf=null, 
		                                   HtmlStyle styleElse=null){

			if(value.HasValue) return HtmlFormat (value.Value,trueValue, falseValue, styleIf,styleElse);

			return new HtmlParagragh(){
				Text="",
				Style=styleElse?? new HtmlStyle(){TextAlign="center" }
			};
		}


		public static HtmlParagragh HtmlFormat(this decimal value, string format="##,0.00", 
		                             HtmlStyle styleIf=null, 
		                             HtmlStyle styleElse=null,
		                             Func<decimal,bool> condition=null
		                             )
		{
			HtmlStyle style;

			if( condition!=null){
				style= (condition(value)? styleIf: styleElse )??new HtmlStyle(){TextAlign="right" };
			}
			else{
				style =  new HtmlStyle(){TextAlign="right" };
				if(value<0) style.Color="red";
			}

			return new HtmlParagragh(){
				Text=  value.ToString(format),
				Style= style
			};
		}

		public static HtmlParagragh HtmlFormat(this decimal? value, string format="##,0.00", 
		                             HtmlStyle styleIf=null, 
		                             HtmlStyle styleElse=null,
		                             Func<decimal,bool> condition=null
		                             )
		{
			if(value.HasValue) return HtmlFormat(value.Value, format,styleIf, styleElse, condition);

			return new HtmlParagragh(){
				Text="",
				Style=styleElse?? new HtmlStyle(){TextAlign="right" }
			};
		}


		public static HtmlParagragh HtmlFormat(this int value, string format="##,0", 
		                             HtmlStyle styleIf=null, 
		                             HtmlStyle styleElse=null,
		                             Func<int,bool> condition=null
		                             )
		{
			HtmlStyle style;

			if( condition!=null){
				style= (condition(value)? styleIf: styleElse )??new HtmlStyle(){TextAlign="center" };
			}
			else{
				style =  new HtmlStyle(){TextAlign="center" };
				if(value<0) style.Color="red";
			}


			return new HtmlParagragh(){
				Text=  value.ToString(format),
				Style= style
			};
		}

		public static HtmlParagragh HtmlFormat(this int? value, string format="##,0", 
		                             HtmlStyle styleIf=null, 
		                             HtmlStyle styleElse=null,
		                             Func<int,bool> condition=null
		                             )
		{
			if(value.HasValue) return HtmlFormat(value.Value, format,styleIf, styleElse, condition);

			return new HtmlParagragh(){
				Text="",
				Style= styleElse?? new HtmlStyle(){TextAlign="center"}
			};
		}

		public static HtmlParagragh HtmlFormat (this DateTime date, string format="dd.MM.yyyy", 
		                             HtmlStyle styleIf=null, 
		                             HtmlStyle styleElse=null,
		                             Func<DateTime,bool> condition=null
		                             )
		{
			HtmlStyle style;

			if( condition!=null){
				style= (condition(date)? styleIf: styleElse )??new HtmlStyle(){TextAlign="center" };
			}
			else
				style =  new HtmlStyle(){TextAlign="center"};

			return new HtmlParagragh(){
				Text= date!=default(DateTime)? date.ToString(format):"",
				Style= style
			};
		}

		public static HtmlParagragh HtmlFormat (this DateTime? date, string format="dd.MM.yyyy",
		                             HtmlStyle styleIf=null, 
		                             HtmlStyle styleElse=null,
		                             Func<DateTime,bool> condition=null){
			return 
				HtmlFormat((date.HasValue)? date.Value:default(DateTime),
				       format,  styleIf, styleElse, condition  );
				
		}

	}
}

