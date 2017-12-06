namespace xyoa.InfoManage.zhiao
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class taitou : UserControl
    {
        protected ImageButton ImageButton1;
        protected RadioButtonList RadioButtonList1;
        protected TextBox Search;

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (this.Search.Text.Trim() == "")
            {
                base.Response.Write("<script language=javascript>alert('搜索内容不能为空！'); </script>");
            }
            else if (this.RadioButtonList1.SelectedValue == "问题")
            {
                base.Response.Redirect("wenti_search.aspx?title=" + this.Search.Text + "");
            }
            else
            {
                base.Response.Redirect("ziliao_search.aspx?title=" + this.Search.Text + "");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}

