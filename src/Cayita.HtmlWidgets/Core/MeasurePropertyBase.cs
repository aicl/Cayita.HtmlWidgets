
namespace Cayita.HtmlWidgets.Core
{


	public abstract class MeasurePropertyBase{

		public MeasurePropertyBase(string property){
			Unit="px";
			Property= property;
		}

		public int? Value {get;set;}
		protected internal string Property {get;set;}

		public string Unit {get;set;}

		public override string ToString ()
		{
			return Value.HasValue? string.Format("{0}:{1}{2};",Property,Value,Unit):string.Empty;
		}
	}
}

