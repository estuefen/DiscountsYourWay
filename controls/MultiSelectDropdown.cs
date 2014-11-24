using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiscountsYourWay.controls
{
	public class MultiSelectDropdown : CheckBoxList
	{
		//First row
		public string Title { get; set; }

		//Arrow Down
		public string ImageURL { get; set; }

		//Expand or hide on start
		public bool OpenOnStart { get; set; }

		//alternative row color:
		public Color AltRowColor { get; set; }

		protected override void OnLoad(EventArgs e)
		{
			if (string.IsNullOrEmpty(ImageURL))
			{
				throw new Exception("ImageURL was not set.");
			}

			base.OnLoad(e);
		}

		/// Display as a dropdown lis
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			//catch ForeColor:
			if (this.ForeColor.IsEmpty)
			{
				this.ForeColor = Color.Black;
			}

			//catch AltRowColor:
			if (this.AltRowColor.IsEmpty)
			{
				this.AltRowColor = Color.GhostWhite;
			}

			//catch border style:
			if (this.BorderStyle.Equals(BorderStyle.NotSet) || this.BorderStyle.Equals(BorderStyle.NotSet))
			{
				this.BorderStyle = BorderStyle.Solid;
			}

			//catch border color:
			if (this.BorderColor.IsEmpty)
			{
				this.BorderColor = Color.Silver;
			}

			//catch border width:
			if (this.BorderWidth.IsEmpty)
			{
				this.BorderWidth = Unit.Pixel(1);
			}

			//catch background width:
			if (this.BackColor.IsEmpty)
			{
				this.BackColor = Color.White;
			}

			StringBuilder sbCss = new StringBuilder();

			//css definition
			sbCss.Append("<style type=\"text/css\">");
			sbCss.Append(".{0}{{");
			
			if (this.Font.Italic)
			{
				sbCss.Append("font-style:italic; ");
			}
			
			if (this.Font.Bold)
			{
				sbCss.Append("font-weight:bold; ");
			}

			string textDecor = string.Empty;
			
			if (Font.Overline || Font.Underline || Font.Strikeout)
			{
				sbCss.Append("text-decoration:");
				
				if (this.Font.Overline)
				{
					sbCss.Append("overline ");
				}
				if (this.Font.Strikeout)
				{
					sbCss.Append("line-through ");
				}
				if (this.Font.Underline)
				{
					sbCss.Append("underline ");
				}

				sbCss.Append("; ");
			}

			if (!ForeColor.IsEmpty)
			{
				sbCss.Append("color:" + ForeColor.Name.Replace("ff", "#") + "; ");
			}
			
			if (!Font.Size.IsEmpty)
			{
				sbCss.Append("font-size:" + Font.Size + "; ");
			}
			
			if (!BackColor.IsEmpty)
			{
				sbCss.Append("background-color: " + BackColor.Name.Replace("ff", "#") + "; ");
			}
			
			sbCss.Append("width: {1}; ");
			sbCss.Append(" border:" + BorderStyle + " " + BorderWidth + " " + this.BorderColor.Name.Replace("ff", "#") + "; min-height: 38px; padding:8px 12px; line-height: 1.428571429; border-top:solid 1px #cccccc; border-radius: 4px; -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075); box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075); -webkit-transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s; transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s; }}.{0} ul  {{overflow:auto; height:{2}; margin:0;  padding:8px 12px; line-height: 1.428571429; border-top:solid 1px #cccccc; border-radius: 4px; -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075); box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075); -webkit-transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s; transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s; ");
			sbCss.Append("}} .{0} li {{list-style: none;}}</style>");

			string css = sbCss.ToString();

			//default css class
			if (string.IsNullOrEmpty(this.CssClass))
			{
				this.CssClass = "ddlchklst";
			}

			//default width and height:
			if (Width.IsEmpty)
			{
				Width = Unit.Percentage(80);
			}

			if (Height.IsEmpty)
			{
				Height = Unit.Pixel(100);
			}

			//first row division: 
			string divFirstRow = @"<div style=""height: 22px;"">   {0} <img id=""{1}"" 
			style=""float: right;"" src=""{2}"" /> </div>";

			//unorder list:
			string ulTag = "<ul style=\"display:{1}\" id=\"{0}\" >";

			//check box:
			string chkBox = "<input id=\"{0}\" name=\"{1}\" type=\"checkbox\" value=\"{2}\"{3}{4}{5} />";

			//attributes to render:
			string attrs = string.Empty;
			foreach (string key in this.Attributes.Keys)
			{
				attrs += " " + key + "=" + "\"" + this.Attributes[key].ToString() + "\"";
			}

			//title for check box:
			string label = "<label for=\"{0}\">{1}</label>";

			//toggle click
			string jqueryToggleFunction = @"<script type=""text/javascript"">  
				$(document).ready(function () {{   $(""#{0}"").click(function () 
				{{ $(""#{1}"").toggle(""fast"");  }});   
				$("".{2} li:even"").css(""background-color"", """ +
				AltRowColor.Name.Replace("ff", "#") + "\") }});  </script>";

			//*************  rendering  ***********************//

			//render css:
			writer.WriteLine(string.Format(css, CssClass, Width, Height));

			//render toggle click function:
			writer.Write(string.Format(jqueryToggleFunction, base.ClientID + "_arrowDown", base.ClientID + "_ul", this.CssClass));

			//render the div start tag:
			writer.WriteLine(string.Format("<div class=\"{0}\">", this.CssClass));

			//render first row with the title:
			writer.Write(string.Format(divFirstRow, this.Title + "  ", base.ClientID + "_arrowDown", ImageURL));
			writer.WriteLine();
			writer.Indent++;

			//render ul start tag:
			writer.WriteLine(string.Format(ulTag, base.ClientID + "_ul", OpenOnStart ? "block" : "none"));

			//render the check box list itself:
			for (int index = 0; index < Items.Count; index++)
			{
				writer.Indent++;
				writer.WriteLine("<li>");
				writer.Indent++;
				writer.WriteLine(string.Format(chkBox,
					base.ClientID + "_" + index.ToString(),
					base.ClientID + "$" + index.ToString(),
					Items[index].Value,
					(Items[index].Selected ? " checked=true" : " "),
					(AutoPostBack ? " onclick=\"" + HttpUtility.HtmlEncode("javascript:setTimeout('__doPostBack(<a href='file://'/'>\\'</a>" + base.ClientID + "$" + index.ToString() + "\\',\\'\\')', 0)") + "\"" : ""), attrs));
				writer.WriteLine(string.Format(label, base.ClientID + "_" + index.ToString(), Items[index].Text + " "));
				writer.Indent--;

				writer.WriteLine("</li>");
				writer.WriteLine();
				writer.Indent--;
			}

			//render end ul tag:
			writer.WriteLine("</ul>");

			//render end div tag:
			writer.WriteLine("</div>");
		}
	}
}