using Cayita.HtmlWidgets.Core;

namespace Cayita.HtmlWidgets
{

	public class HtmlGridStyle:GridStyleBase{
		public HtmlGridStyle():base(){

			TitleStyle.Padding.AllSides=4;

			FootNoteStyle.TextAlign="left";
			FootNoteStyle.FontSize.Value=90;
			FootNoteStyle.FontSize.Unit="%";
		}
	}


	public class GreyGridStyle:GridStyleBase
	{
		public GreyGridStyle ():base()
		{
			TableStyle.Border= new  TableBorderProperty 
			{
				Width=new BorderWidthProperty(){
					AllSides=0
				},
				Style ="solid",
				AllBorderSpacing=0,
				Radius= new BorderRadiusProperty(){
					AllSides=10
				},
			};

			TableStyle.Padding.Top=8;
			TableStyle.Padding.Right=8;
			TableStyle.Padding.Bottom=4;
			TableStyle.Padding.Right=8;

			TableStyle.BackgroundColor="#F5F2FF";

			HeaderCellStyle.Padding.AllSides=2;
			HeaderCellStyle.Border.Width.Bottom=2;
			HeaderCellStyle.Border.Color="#C9C9C9";
			HeaderCellStyle.Border.Style="solid";

			FooterCellStyle.Border.Width.AllSides=0;
			FooterCellStyle.Border.Width.Top=2;
			FooterCellStyle.Border.Color="#C9C9C9";
			FooterCellStyle.Border.Style="solid";


			CellStyle.Padding.AllSides=2;
			AlternateRowStyle.BackgroundColor= "#E1EEF4";

			TitleStyle.Padding.AllSides=4;

			FootNoteStyle.TextAlign="left";
			FootNoteStyle.FontSize.Value=90;
			FootNoteStyle.FontSize.Unit="%";
		}
	}


	public class BlueGridStyle:GridStyleBase
	{
		public BlueGridStyle ():base()
		{
			TableStyle.Border= new  TableBorderProperty 
			{
				Width=new BorderWidthProperty(){
					AllSides=0
				},
				Style ="solid",
				AllBorderSpacing=0,
				Radius= new BorderRadiusProperty(){
					AllSides=10
				},
			};

			TableStyle.Padding.Top=8;
			TableStyle.Padding.Right=8;
			TableStyle.Padding.Bottom=4;
			TableStyle.Padding.Right=8;

			TableStyle.BackgroundColor="#E1EEF4";

			HeaderCellStyle.Padding.AllSides=2;
			HeaderCellStyle.Border.Width.Bottom=2;
			HeaderCellStyle.Border.Color="#CAD6DB";
			HeaderCellStyle.Border.Style="solid";

			FooterCellStyle.Border.Width.AllSides=0;
			FooterCellStyle.Border.Width.Top=2;
			FooterCellStyle.Border.Color="#CAD6DB";
			FooterCellStyle.Border.Style="solid";


			CellStyle.Padding.AllSides=2;
			AlternateRowStyle.BackgroundColor= "#F5F2FF";

			TitleStyle.Padding.AllSides=4;

			FootNoteStyle.TextAlign="left";
			FootNoteStyle.FontSize.Value=90;
			FootNoteStyle.FontSize.Unit="%";


		}
	}

	public class WhiteGridStyle:GridStyleBase
	{
		public WhiteGridStyle ():base()
		{
			TableStyle.Border= new  TableBorderProperty 
			{
				Width=new BorderWidthProperty(){
					AllSides=1
				},
				Style ="solid",
				AllBorderSpacing=0,
				Radius= new BorderRadiusProperty(){
					AllSides=10
				},
				Color= "#DFDCE8" 
			};

			TableStyle.Padding.Top=8;
			TableStyle.Padding.Right=8;
			TableStyle.Padding.Bottom=4;
			TableStyle.Padding.Right=8;

			TableStyle.BackgroundColor="white";

			HeaderCellStyle.Padding.AllSides=2;
			HeaderCellStyle.Border.Width.Bottom=2;
			HeaderCellStyle.Border.Color="#DFDCE8";
			HeaderCellStyle.Border.Style="solid";

			FooterCellStyle.Border.Width.AllSides=0;
			FooterCellStyle.Border.Width.Top=2;

			FooterCellStyle.Border.Color="#DFDCE8";
			FooterCellStyle.Border.Style="solid";


			CellStyle.Padding.AllSides=2;
			AlternateRowStyle.BackgroundColor= "#E1EEF4";

			TitleStyle.Padding.AllSides=4;

			FootNoteStyle.TextAlign="left";
			FootNoteStyle.FontSize.Value=90;
			FootNoteStyle.FontSize.Unit="%";
		}
	}

}
