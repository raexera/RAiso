using RAiso.Controller;
using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace RAiso.Views.Customer
{
    public partial class TransactionHistoryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    String role = UserController.GetRole(Session["user"].ToString());
                    if (!role.Equals("Customer"))
                    {
                        Response.Redirect("~/Views/Home.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Views/Home.aspx");
                }
                BindTransaction();
            }
        }
        private void BindTransaction()
        {
            List<TransactionHeader> tHs = TransactionController.GetAllTh(Convert.ToInt32(Session["user"]));
            List<dynamic> tr = new List<dynamic>();
            foreach (var th in tHs)
            {
                MsUser user = UserController.GetUserById((Session["user"]).ToString());
                tr.Add(new
                {
                    TransactionID = th.TransactionID,
                    TransactionDate = th.TransactionDate.ToShortDateString(),
                    UserName = user.UserName,
                });
            }
            transactionGV.DataSource = tr;
            transactionGV.DataBind();
        }

        protected void viewDetailBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            String id = row.Cells[0].Text;

            Response.Redirect("~/Views/Customer/TransactionDetailPage.aspx?ID=" + id);
        }
    }
}
