using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using IDAL;

public partial class WebUI_CMD_ProductCategoryEdit : BasePage
{
    protected string strID;
    BLL.BLLBase bll = new BLL.BLLBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        strID = Request.QueryString["ID"] + "";

        if (!IsPostBack)
        {
            BindDropDownList();
            if (strID != "")
            {
                DataTable dt = bll.FillDataTable("Cmd.SelectProductCategory", new DataParameter[] { new DataParameter("{0}", string.Format("CategoryCode='{0}'", strID)) });
                BindData(dt);
                int count = bll.GetRowCount("View_CMD_CELL_ALL", "CategoryCode='" + this.txtID.Text + "'");
                if (count > 0)
                    this.ddlAreaCode.Enabled = false;
                SetTextReadOnly(this.txtID);
            }
            else
            {
                this.txtID.Text = bll.GetNewID("CMD_ProductCategory", "CategoryCode", "1=1");
                this.txtCreator.Text = Session["EmployeeCode"].ToString();
                this.txtUpdater.Text = Session["EmployeeCode"].ToString();
                this.txtCreatDate.Text = ToYMD(DateTime.Now);
                this.txtUpdateDate.Text = ToYMD(DateTime.Now);

            }

            writeJsvar(FormID, SqlCmd, strID);
            SetTextReadOnly(this.txtCreator, this.txtCreatDate, this.txtUpdater, this.txtUpdateDate);

        }
    }

    private void BindDropDownList()
    {
        DataTable dtArea = bll.FillDataTable("Cmd.SelectArea");
        this.ddlAreaCode.DataValueField = "AreaCode";
        this.ddlAreaCode.DataTextField = "AreaName";
        this.ddlAreaCode.DataSource = dtArea;
        this.ddlAreaCode.DataBind();
    }


    private void BindData(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            this.txtID.Text = dt.Rows[0]["CategoryCode"].ToString();
            this.txtProductTypeName.Text = dt.Rows[0]["CategoryName"].ToString();
            this.ddlAreaCode.SelectedValue = dt.Rows[0]["AreaCode"].ToString();
            this.txtMemo.Text = dt.Rows[0]["Memo"].ToString();
            this.txtCreator.Text = dt.Rows[0]["Creator"].ToString();
            this.txtCreatDate.Text = ToYMD(dt.Rows[0]["CreateDate"]);
            this.txtUpdater.Text = dt.Rows[0]["Updater"].ToString();
            this.txtUpdateDate.Text = ToYMD(dt.Rows[0]["UpdateDate"]);

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {


        if (strID == "") //新增
        {
            int Count = bll.GetRowCount("CMD_ProductCategory", string.Format("CategoryCode='{0}'", this.txtID.Text));
            if (Count > 0)
            {
                JScript.Instance.ShowMessage(this.Page, "该类别编码已经存在！");
                return;
            }

            bll.ExecNonQuery("Cmd.InsertProductCategory", new DataParameter[] { 
                                                                                new DataParameter("@CategoryCode", this.txtID.Text.Trim()),
                                                                                new DataParameter("@CategoryName", this.txtProductTypeName.Text.Trim()),
                                                                                new DataParameter("@WarehouseCode", ""),
                                                                                new DataParameter("@AreaCode", this.ddlAreaCode.SelectedValue),
                                                                                new DataParameter("@Memo", this.txtMemo.Text.Trim()),
                                                                                new DataParameter("@Creator", Session["EmployeeCode"].ToString()),
                                                                                new DataParameter("@Updater", Session["EmployeeCode"].ToString())
                                                                              });
        }
        else //修改
        {


            List<string> Comd = new List<string>();
            Comd.Insert(0, "Cmd.UpdateProductCategory");
            Comd.Insert(1, "Cmd.UpdateProductAreaCode");

            List<DataParameter[]> paras = new List<DataParameter[]>();
            paras.Insert(0, new DataParameter[] {  new DataParameter("@CategoryName", this.txtProductTypeName.Text.Trim()),
                                                       new DataParameter("@WarehouseCode", ""),
                                                       new DataParameter("@AreaCode", this.ddlAreaCode.SelectedValue),
                                                       new DataParameter("@Memo", this.txtMemo.Text.Trim()) ,
                                                       new DataParameter("@Updater", Session["EmployeeCode"].ToString()),
                                                       new DataParameter("@CategoryCode", this.txtID.Text.Trim())
                                                     });

            paras.Insert(1, new DataParameter[] { new DataParameter("@AreaCode", this.ddlAreaCode.SelectedValue), 
                                                      new DataParameter("@CategoryCode", this.txtID.Text.Trim()) 
                                                    });
            bll.ExecTran(Comd.ToArray(), paras);


        }

        Response.Redirect(FormID + "View.aspx?SubModuleCode=" + SubModuleCode + "&FormID=" + Server.UrlEncode(FormID) + "&SqlCmd=" + SqlCmd + "&ID=" + Server.UrlEncode(this.txtID.Text));
    }

    protected void ddlAreaCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.strID.Length > 0)
        {
            int count = bll.GetRowCount("View_CMD_CELL_ALL", "ProductTypeCode='" + this.txtID.Text + "'");
            if (count > 0)
            {
                this.ddlAreaCode.SelectedValue = bll.GetFieldValue("CMD_ProductType", "AreaCode", "ProductTypeCode='" + this.txtID.Text + "'");
                JScript.Instance.ShowMessage(this.Page, "该类别已经有产品存放在库区货位上，不能修改库区！");
                return;
            }
        }
    }
}
