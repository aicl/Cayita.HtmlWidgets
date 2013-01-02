using System;
using Cayita.HtmlWidgets.Core;

namespace Cayita.HtmlWidgets
{

	public class SideProperty:SideBase{

		public SideProperty(string property):base(){
			Property=property;
		}

		public string Property {get;set;}

		public override string ToString(){
			var r= base.ToString();
			return (string.IsNullOrEmpty(r))?
				string.Empty:
					string.Format("{0}:{1}", Property, r);
		}
	}
	
}
