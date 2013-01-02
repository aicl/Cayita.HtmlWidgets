using ServiceStack.Html;
using ServiceStack.Common;
using ServiceStack.Text;
using System;
using Cayita.HtmlWidgets.Core;

namespace Cayita.HtmlWidgets
{

	public class HtmlForm:TagBase{

		public HtmlForm():base("form"){
			Class="form-horizontal";
			ActionButonDiv = new HtmlDiv{Class="form-actions"};
			Method="post";
		}

		public string Method{
			get{
				string method;
				return Attributes.TryGetValue("method", out method)? method:string.Empty;
			}
			set{
				Attributes["method"]= value;
			}
		}

		public string Action{
			get{
				string action;
				return Attributes.TryGetValue("action", out action)? action:string.Empty;
			}
			set{
				Attributes["action"]= value;
			}
		}

		public HtmlDiv ActionButonDiv{get;set;}

		public void AddHtmlField(IHtmlField field){
			InnerHtml= InnerHtml+field.ToHtml();
		}

		public void AddHtmlField(Action<HtmlField> config){
			var hf= new HtmlField();
			config(hf);
			AddHtmlField(hf);
		}

		public void AddHtmlHiddenField(Action<HtmlField> config){
			var hf= new HtmlField();
			hf.ControlGroupDiv.Style.Hidden=true;
			config(hf);
			AddHtmlField(hf);
		}

		public void AddActionButton(HtmlButton action){
			ActionButonDiv.AddHtmlTag(action);
		}

		public string Title {get;set;}

		public override string ToString ()
		{
			if(!Title.IsNullOrEmpty()){

				var fs = new HtmlFieldset();
				fs.InnerHtml= "<legend>{0}</legend>{1}".Fmt(Title,InnerHtml);
				InnerHtml = fs.InnerHtml;

			}
			if(!ActionButonDiv.InnerHtml.IsNullOrEmpty()) AddHtmlTag(ActionButonDiv);
			return base.ToString();
		}

	}

/*
<form class="form-horizontal" >
    <fieldset>
      <div id="legend" class="">
        <legend class="">Form Name</legend>
      </div>

<div class="control-group">

          <!-- Text input-->
          <label class="control-label" for="input01">Text input</label>
          <div class="controls">
            <input type="text" placeholder="placeholder" class="input-xlarge">
            <p class="help-block">Supporting help text</p>
			<input type="text" placeholder="another placeholder" class="input-xlarge">
            <p class="help-block">Supporting help text</p>
			<input type="checkbox" value="Option one">
          </div>
<label class="control-label" for="input01">EN LA MISMA FILA</label>
<div class="controls controls-row">
  <input class="span4" type="text" placeholder=".span4">
  <input class="span1" type="text" placeholder=".span1">
</div>

 </div>

*/

	/*
	 <label class="checkbox">
              <input type="checkbox" value="Option one"> Option one 1 
     </label>

	*/

}
