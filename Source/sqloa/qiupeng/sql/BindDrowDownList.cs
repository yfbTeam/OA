namespace qiupeng.sql
{
    using System;
    using System.Collections;
    using System.Web.UI.WebControls;

    public class BindDrowDownList
    {
        private Db List = new Db();

        public void Bind_DropDownList(DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string sql = SQL;
            MyDropDownList.DataSource = this.List.GetGrid(sql, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();
            ListItem item = new ListItem();
            item.Text = "请选择";
            item.Value = "请选择";
            MyDropDownList.Items.Insert(0, item);
        }

        public void Bind_DropDownList_Age(DropDownList MyDropDownList)
        {
            ArrayList list = new ArrayList();
            list.Add("[请选择年龄]");
            for (int i = 20; i < 50; i++)
            {
                list.Add(i.ToString());
            }
            MyDropDownList.DataSource = list;
            MyDropDownList.DataBind();
        }

        public void Bind_DropDownList_CheckBoxList(CheckBoxList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string sql = SQL;
            MyDropDownList.DataSource = this.List.GetGrid(sql, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();
        }

        public void Bind_DropDownList_Date(DropDownList MyDropDownList)
        {
            ArrayList list = new ArrayList();
            for (int i = 1; i < 0x20; i++)
            {
                list.Add(i.ToString());
            }
            MyDropDownList.DataSource = list;
            MyDropDownList.DataBind();
        }

        public void Bind_DropDownList_Hour(DropDownList MyDropDownList)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < 0x18; i++)
            {
                list.Add(i.ToString());
            }
            MyDropDownList.DataSource = list;
            MyDropDownList.DataBind();
        }

        public void Bind_DropDownList_kong(DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string sql = SQL;
            MyDropDownList.DataSource = this.List.GetGrid(sql, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();
            ListItem item = new ListItem();
            item.Text = "";
            item.Value = "";
            MyDropDownList.Items.Insert(0, item);
        }

        public void Bind_DropDownList_Kq(DropDownList MyDropDownList)
        {
            ArrayList list = new ArrayList();
            for (int i = 1; i < 0x1d; i++)
            {
                list.Add(i.ToString());
            }
            MyDropDownList.DataSource = list;
            MyDropDownList.DataBind();
        }

        public void Bind_DropDownList_ListBox(ListBox MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string sql = SQL;
            MyDropDownList.DataSource = this.List.GetGrid(sql, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();
        }

        public void Bind_DropDownList_Mini(DropDownList MyDropDownList)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < 60; i++)
            {
                list.Add(i.ToString());
            }
            MyDropDownList.DataSource = list;
            MyDropDownList.DataBind();
        }

        public void Bind_DropDownList_Month(DropDownList MyDropDownList)
        {
            ArrayList list = new ArrayList();
            list.Add("----");
            for (int i = 1; i < 13; i++)
            {
                list.Add(i.ToString());
            }
            MyDropDownList.DataSource = list;
            MyDropDownList.DataBind();
        }

        public void Bind_DropDownList_MonthForSa(DropDownList MyDropDownList)
        {
            ArrayList list = new ArrayList();
            for (int i = 1; i < 13; i++)
            {
                list.Add(i.ToString());
            }
            MyDropDownList.DataSource = list;
            MyDropDownList.DataBind();
        }

        public void Bind_DropDownList_nothing(DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string sql = SQL;
            MyDropDownList.DataSource = this.List.GetGrid(sql, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();
            ListItem item = new ListItem();
        }

        public void Bind_DropDownList_nothing1(RadioButtonList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string sql = SQL;
            MyDropDownList.DataSource = this.List.GetGrid(sql, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();
            ListItem item = new ListItem();
        }

        public void Bind_DropDownList_unit(DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string sql = SQL;
            MyDropDownList.DataSource = this.List.GetGrid(sql, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();
            ListItem item = new ListItem();
            item.Text = "根节点";
            item.Value = "0";
            MyDropDownList.Items.Insert(0, item);
        }

        public void Bind_DropDownList_Year(DropDownList MyDropDownList, int _Begin, int _End)
        {
            ArrayList list = new ArrayList();
            list.Add("----");
            for (int i = _Begin; i <= _End; i++)
            {
                list.Add(i.ToString());
            }
            MyDropDownList.DataSource = list;
            MyDropDownList.DataBind();
        }

        public void Bind_DropDownList_YearForSa(DropDownList MyDropDownList, int _Begin, int _End)
        {
            ArrayList list = new ArrayList();
            for (int i = _Begin; i <= _End; i++)
            {
                list.Add(i.ToString());
            }
            MyDropDownList.DataSource = list;
            MyDropDownList.DataBind();
        }

        public void Bind_DropDownListBuwei(DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string sql = SQL;
            MyDropDownList.DataSource = this.List.GetGrid(sql, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();
            ListItem item = new ListItem();
            item.Text = "不明确部位";
            item.Value = "0";
            MyDropDownList.Items.Insert(0, item);
        }

        public void Bind_DropDownListCar(DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string sql = SQL;
            MyDropDownList.DataSource = this.List.GetGrid(sql, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();
            ListItem item = new ListItem();
            item.Text = "全部车辆";
            item.Value = "0";
            MyDropDownList.Items.Insert(0, item);
        }

        public void Bind_DropDownListFlow(DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string sql = SQL;
            MyDropDownList.DataSource = this.List.GetGrid(sql, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();
            ListItem item = new ListItem();
            item.Text = "所有表单类型";
            item.Value = "0";
            MyDropDownList.Items.Insert(0, item);
        }

        public void Bind_DropDownListFlowBh(DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string sql = SQL;
            MyDropDownList.DataSource = this.List.GetGrid(sql, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();
            ListItem item = new ListItem();
            item.Text = "开始";
            item.Value = "0";
            MyDropDownList.Items.Insert(0, item);
        }

        public void Bind_DropDownListForm(DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string sql = SQL;
            MyDropDownList.DataSource = this.List.GetGrid(sql, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();
            ListItem item = new ListItem();
            item.Text = "表单字段";
            item.Value = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "";
            MyDropDownList.Items.Insert(0, item);
        }

        public void Bind_DropDownListFormCh(DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string sql = SQL;
            MyDropDownList.DataSource = this.List.GetGrid(sql, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();
            ListItem item = new ListItem();
            item.Text = "已创建公式";
            item.Value = "";
            MyDropDownList.Items.Insert(0, item);
        }

        public void Bind_DropDownListFormZd(DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string sql = SQL;
            MyDropDownList.DataSource = this.List.GetGrid(sql, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();
            ListItem item = new ListItem();
            item.Text = "选择字段";
            item.Value = "";
            MyDropDownList.Items.Insert(0, item);
        }

        public void Bind_DropDownListHeTong(DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string sql = SQL;
            MyDropDownList.DataSource = this.List.GetGrid(sql, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();
            ListItem item = new ListItem();
            item.Text = "全部合同";
            item.Value = "0";
            MyDropDownList.Items.Insert(0, item);
        }

        public void Bind_DropDownListLiuCheng(DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string sql = SQL;
            MyDropDownList.DataSource = this.List.GetGrid(sql, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();
            ListItem item = new ListItem();
            item.Text = "所有流程";
            item.Value = "0";
            MyDropDownList.Items.Insert(0, item);
        }

        public void Bind_DropDownListMetting(DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string sql = SQL;
            MyDropDownList.DataSource = this.List.GetGrid(sql, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();
            ListItem item = new ListItem();
            item.Text = "全部会议室";
            item.Value = "0";
            MyDropDownList.Items.Insert(0, item);
        }

        public void Bind_DropDownListmodle(DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string sql = SQL;
            MyDropDownList.DataSource = this.List.GetGrid(sql, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();
            ListItem item = new ListItem();
            item.Text = "全部类型";
            item.Value = "0";
            MyDropDownList.Items.Insert(0, item);
        }

        public void Bind_DropDownListNodeName(DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string sql = SQL;
            MyDropDownList.DataSource = this.List.GetGrid(sql, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();
            ListItem item = new ListItem();
            item.Text = "全部步骤";
            item.Value = "全部步骤";
            MyDropDownList.Items.Insert(0, item);
        }
    }
}

