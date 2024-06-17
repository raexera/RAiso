using RAiso.Controller;
using System;
using System.Web.UI.WebControls;

namespace RAiso.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    String role = UserController.GetRole(Session["user"].ToString());
                    if (role.Equals("Admin"))
                    {
                        stationeryGV.Columns[3].Visible = true;
                        insertBtn.Visible = true;
                    }
                }
                BindStationery();
            }
        }
        private void BindStationery()
        {
            stationeryGV.DataSource = StationeryController.GetStationeries();
            stationeryGV.DataBind();
        }

        protected void stationeryGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = stationeryGV.Rows[e.RowIndex];
            String id = StationeryController.GetIdByName(row.Cells[0].Text).ToString();

            StationeryController.DeleteStationery(Convert.ToInt32(id));
            BindStationery();
        }

        protected void stationeryGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = stationeryGV.SelectedRow;
            String id = StationeryController.GetIdByName(row.Cells[0].Text).ToString();

            Response.Redirect("~/Views/StationeryDetailPage.aspx?ID=" + id);
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Admin/InsertStationeryPage.aspx");
        }

        protected void stationeryGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = stationeryGV.Rows[e.NewEditIndex];
            String id = StationeryController.GetIdByName(row.Cells[0].Text).ToString();

            Response.Redirect("~/Views/Admin/UpdateStationeryPage.aspx?ID=" + id);
            BindStationery();
        }
    }
}