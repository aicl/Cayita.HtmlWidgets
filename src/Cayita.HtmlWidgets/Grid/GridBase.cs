using System.Linq;
using System.Collections.Generic;
using ServiceStack.Common.Extensions;
using System;
using ServiceStack.Text;
using Cayita.HtmlWidgets.Core;

namespace Cayita.HtmlWidgets
{
	public abstract class GridBase <T>:TagBase
	{

		static int divId=0;
		static int tableId=0;

		public string Title {get;set;}

		public string TableId {get;set;}

		public string TableName {get;set;}

		public string FootNote {get;set;}

		public IList<T> DataSource {get;set;}

		public GridStyleBase GridStyle {get;set;}

		protected IList<GridColumnBase<T>> Columns {get;set;}

		protected bool  OmitHeader {get;set;}
		protected bool  OmitFooter {get;set;}

		public abstract GridColumnBase<T> CreateGridColumn();

		public TagBase HeaderBand {get;set;}
		public TagBase FooterBand {get;set;}

		public GridCss Css {get;set;}

		void AddGridColum(GridColumnBase<T> gridColumn){
			Columns.Add(gridColumn);
		}

		public virtual void AddGridColum(Action<GridColumnBase<T>> config){
			var gc = CreateGridColumn();
			config(gc);
			AddGridColum(gc);
		}

		public GridBase ():base("div"){
			Css= new GridCss();
			OmitFooter=false;
			OmitHeader=false;
			Id= "div-{0}-{1}".Fmt( typeof(T).Name, ++divId);
			TableId= "table-{0}-{1}".Fmt( typeof(T).Name, ++tableId);
			TableName=typeof(T).Name;
		}


		public virtual RowBase  CreateRow(T record, int index=-1){

			HtmlRow dr  = new HtmlRow();

			foreach(var column in Columns){
				dr.AddCell(dt=>{
					dt.Style = column.CellStyle; 
					if(column.Hidden) dt.Style.Hidden=column.Hidden ;
					if (column.CellRenderFunc!=null){
						dt.SetValue( column.CellRenderFunc(record,index,dt));
					}
					else{
						dt.SetValue("");
					}
				});

			}
			return dr;
		}


		public override string ToString ()
		{
			string alternateRowCss=string.Empty;

			HtmlTable table = new HtmlTable(){Name=TableName};
			if(!string.IsNullOrEmpty(TableId)) table.Id=TableId;

			if(Css!=default(GridCss)){
				if(!string.IsNullOrEmpty( Css.Name)) table.Attributes["class"]= Css.Name;
				alternateRowCss= Css.AlternateRow;
			}

			table.Style.PopulateWith( GridStyle.TableStyle);
			table.RowStyle.PopulateWith(GridStyle.RowStyle);
			table.AlternateRowStyle.PopulateWith(GridStyle.AlternateRowStyle);

			table.Header.Style.PopulateWith( GridStyle.HeaderStyle);
			table.Footer.Style.PopulateWith( GridStyle.FooterStyle);

			// header
			if(!OmitHeader)
			{
				if(!string.IsNullOrEmpty( Title)){
					table.Header.AddRow(tr=>{

						tr.AddCell(th=>{
							th.ColumnSpan= (Columns!=null && Columns.Count>0) ?Columns.Count: 1;
							th.SetValue(GridStyle.TitleStyle!=default(HtmlStyle)?
							            (new HtmlParagragh{Text=Title, Style= GridStyle.TitleStyle}).ToString():
							            Title);
						});

					});

				}


				if(HeaderBand!=default(TagBase)){

					table.Header.AddRow(hbr=>{
						hbr.AddCell(hbc=>{
							hbc.Style.TextAlign="left";
							hbc.Style.FontWeight="normal";
							hbc.ColumnSpan= (Columns!=null && Columns.Count>0) ?Columns.Count: 1;
							hbc.InnerHtml=HeaderBand.ToString();
						});
					});
				}

				if (Columns.Any(f=>(f.HeaderCellColumnSpan.HasValue &&
				 				f.HeaderCellColumnSpan.Value!=default(int)) ||
				                !string.IsNullOrEmpty (f.HeaderText))){

						table.Header.AddRow(trh=>{
							int number=0;
							int filled=0; 

						foreach(var column in Columns){

							trh.AddCell(th=>{

								th.Style = column.HeaderCellStyle;
								if(column.Hidden) th.Style.Hidden=column.Hidden;

								if(column.HeaderCellColumnSpan.HasValue && column.HeaderCellColumnSpan.Value!=default(int)){
									th.ColumnSpan=column.HeaderCellColumnSpan;

								}

								if (!string.IsNullOrEmpty (column.HeaderText)){
									th.SetValue(column.HeaderText);
									filled+= ((th.ColumnSpan.HasValue && th.ColumnSpan.Value>0)?th.ColumnSpan.Value+1:1  );
								}
								else if(number==filled ){
									th.Attributes.Add("height","0");
									th.SetValue();
									filled++;
								}
								number++;
							});
							if(filled>=( Columns.Count)) break;
						}
					});
				}

			}
			else{
				table.Header=null;
			}

			// TBody
			if(DataSource==null ||  Columns.Count==0) return table.ToString();

			foreach(var data in DataSource){

				table.AddRow(dr=>{

					foreach(var column in Columns){
						dr.AddCell( dt=>{
							dt.Style = column.CellStyle; 
						if(column.Hidden) dt.Style.Hidden=column.Hidden ;
							if (column.CellRenderFunc!=null){
								dt.SetValue( column.CellRenderFunc(data,table.RowsCount-1,dt));
							}
							else{
								dt.SetValue("");
							}
						});

					}

				},alternateRowCss);

			}

			// Footer
			if(!OmitFooter)
			{
				if( Columns.Any(column=>
				                  (	column.FooterCellColumnSpan.HasValue 
				 					&& column.FooterCellColumnSpan.Value!=default(int)) ||
				                  	column.FooterRenderFunc!=null
				                  ))
				{

					table.Footer.AddRow(trf=>{

						int number=0; int filled=0; 
						foreach(var column in Columns){
							trf.AddCell(th=>{

								th.Style = column.FooterCellStyle;
								if(column.Hidden) th.Style.Hidden=column.Hidden;
								if(column.FooterCellColumnSpan.HasValue && column.FooterCellColumnSpan.Value!=default(int)){
									th.ColumnSpan=column.FooterCellColumnSpan;

								}

								if (column.FooterRenderFunc!=null){
									th.SetValue(column.FooterRenderFunc());
									filled+= ((th.ColumnSpan.HasValue && th.ColumnSpan.Value>0)?th.ColumnSpan.Value+1:1  );

								}
								else if(number==filled ){
									th.Attributes.Add("height","0");
									th.SetValue();
									filled++;
								}

								number++;

							});

							if(filled>=( Columns.Count)) break;
						}
					});
				}

				if(FooterBand!=default(TagBase)){
					table.Footer.AddRow(fbr=>{
						fbr.AddCell(fbc=>{
							fbc.Style.TextAlign="left";
							fbc.Style.FontWeight="normal";
							fbc.ColumnSpan= (Columns!=null && Columns.Count>0) ?Columns.Count: 1;
							fbc.InnerHtml=FooterBand.ToString();
						});
					});
				}


				if(!string.IsNullOrEmpty(FootNote)){
					table.Footer.AddRow(tr=>{
						tr.AddCell(th=>{

							th.ColumnSpan= (Columns!=null && Columns.Count>0) ?Columns.Count: 1;
							th.SetValue( GridStyle.FootNoteStyle!=default(HtmlStyle)?
					            (new HtmlParagragh{Text=FootNote, Style= GridStyle.FootNoteStyle}).ToString():
								FootNote
							);
						});
					});

				}
			}
			else
				table.Footer=null;

			var pi = InnerHtml;
			AddHtmlTag(table);
			var r = base.ToString();
			InnerHtml= pi;
			return r;
		}
	}

}

