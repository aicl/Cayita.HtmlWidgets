using ServiceStack.Common;
using System;
using Cayita.HtmlWidgets.Core;

namespace Cayita.HtmlWidgets
{

	public class HtmlField:IHtmlField{

		public HtmlField(){

			ControlGroupDiv = new HtmlDiv(){Class="control-group"};
			ControlDiv= new HtmlDiv(){Class="controls"};
			Label = new HtmlLabel();
		}

		public HtmlDiv ControlGroupDiv {get;	set;}
		public HtmlDiv ControlDiv{get;set;}
		public HtmlLabel Label {get;set;}

		public void SetControlsInRow(){
			ControlDiv.AddCssClass("controls-row");
		}

		public void AddHtmlInput(HtmlInputBase inputField, HtmlParagragh helpBlock=null ){

			ControlDiv.AddHtmlTag(inputField);
			if (helpBlock!=default(HtmlParagragh)){
				if(helpBlock.Class.IsNullOrEmpty() ) helpBlock.Class="help-block";
				ControlDiv.AddHtmlTag(helpBlock);
			}
		}

		public void AddHtmlInput(Action<HtmlInputBase, HtmlParagragh> configAction ){
			HtmlInput hi = new HtmlInput();
			HtmlParagragh p = new HtmlParagragh();
			configAction(hi, p);
			AddHtmlInput(hi, p);
		}

		public void AddHtmlInput(Action<HtmlInputBase> configAction ){
			HtmlInput hi = new HtmlInput();
			configAction(hi);
			AddHtmlInput(hi);
		}

		public void AddHtmlTextInput(Action<HtmlTextInput, HtmlParagragh> configAction ){
			HtmlTextInput hi = new  HtmlTextInput();
			HtmlParagragh p = new HtmlParagragh();
			configAction(hi, p);
			AddHtmlInput(hi, p);
		}

		public void AddHtmlTextInput(Action<HtmlTextInput> configAction ){
			HtmlTextInput hi = new  HtmlTextInput();
			configAction(hi);
			AddHtmlInput(hi);
		}

		public void AddHtmlCheckboxInput(Action<HtmlCheckboxInput, HtmlParagragh> configAction ){
			HtmlCheckboxInput hi = new  HtmlCheckboxInput();
			HtmlParagragh p = new HtmlParagragh();
			configAction(hi,p);
			AddHtmlInput(hi,p);
		}

		public void AddHtmlCheckboxInput(Action<HtmlCheckboxInput> configAction ){
			HtmlCheckboxInput hi = new  HtmlCheckboxInput();
			configAction(hi);
			AddHtmlInput(hi);
		}

		public void AddHtmlRadioInput(Action<HtmlRadioInput> configAction ){
			HtmlRadioInput hi = new  HtmlRadioInput();
			configAction(hi);
			AddHtmlInput(hi);
		}

		#region IHtmlField implementation
		public string ToHtml ()
		{
			//return ControlGroupDiv.  "{0}{1}".Fmt( Label.ToString(), ControlDiv.ToString());
			ControlGroupDiv.AddHtmlTag(Label);
			ControlGroupDiv.AddHtmlTag(ControlDiv);
			return ControlGroupDiv.ToString();

		}
		#endregion
	}


}
