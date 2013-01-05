using System.Web;
using System;

namespace Cayita.HtmlWidgets.Common
{
	public static class Extensions
	{
		internal static readonly string HtmlSpace = "&nbsp;";

		internal static readonly string DateFormat = "dd.MM.yyyy";

		public static string ValueOrHtmlSpace(this string value){
			return !string.IsNullOrEmpty(value)?value:HtmlSpace;
		}

		public static string Decode(this string text, System.Text.Encoding encoder=null)
		{
			return HttpUtility.UrlDecode(text,encoder?? System.Text.Encoding.UTF8);
		}

		public static string Encode(this string text, System.Text.Encoding encoder=null)
		{
			return HttpUtility.UrlEncode(text, encoder?? System.Text.Encoding.UTF8);
		}

		public static string Format(this DateTime date, string format=null){
			return date!=default(DateTime)? date.ToString(format??DateFormat):string.Empty;
		}

		public static string Format(this DateTime? date, string format=null){
			return Format((date.HasValue? date.Value: new DateTime()), format);
		}

		public static string Format(this bool value, string trueValue="Yes", string falseValue="No"
		                                   ){
			return  value? trueValue: falseValue;
		}

		public static string Format(this bool? value, string trueValue="Yes", string falseValue="No"){

			return value.HasValue? Format (value.Value,trueValue, falseValue): "";

		}

		public static string Format(this decimal value, string format="##,0.00"    )
		{
			return value.ToString(format);
		}

		public static string Format(this decimal? value, string format="##,0.00")
		{
			return (value.HasValue)?
				Format(value.Value, format):
					string.Empty;
		}


	}
}

