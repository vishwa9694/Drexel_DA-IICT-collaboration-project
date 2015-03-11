using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using DayPilot.Web.Ui.Events;
using System.Globalization;

namespace Collaboration_LLS.Panel
{
    public partial class Calendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Browser.Browser == "Firefox") Response.Cache.SetNoStore();

            if (!IsPostBack)
            {
                DayPilotMonth1.StartDate = MonthPicker1.StartDate;
                SqlDataSourceEvents.SelectParameters["emailId"].DefaultValue = Session["LLS_EmailId"].ToString();
                DataBind();
            }
        }

        protected void DayPilotMonth1_EventMenuClick(object sender, EventMenuClickEventArgs e)
        {
            if (e.Command == "Delete")
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM [events] WHERE [id] = @id", con);

                    cmd.Parameters.AddWithValue("id", e.Value);

                    cmd.ExecuteNonQuery();

                }

                DayPilotMonth1.DataBind();
                DayPilotMonth1.Update();
            }
            if (e.Command == "Open")
            {
                EventDetail.ChangeMode(DetailsViewMode.Edit);
                SqlDataSourceDetail.SelectParameters["id"].DefaultValue = e.Value;
                //SqlDataSourceDetail.InsertParameters.Add("@emailId", Session["LLS_EmailId"].ToString());
                EventDetail.DataBind();
                TextBox startTextBox = (TextBox)EventDetail.Rows[1].Cells[1].Controls[0];
                startTextBox.Text = Convert.ToDateTime(e.Start, CultureInfo.CurrentCulture).ToString("MM/dd/yyyy");

                TextBox endTextBox = (TextBox)EventDetail.Rows[2].Cells[1].Controls[0];
                endTextBox.Text = Convert.ToDateTime(e.End, CultureInfo.CurrentCulture).ToString("MM/dd/yyyy");

                UpdatePanelDetail.Update();
                ModalPopup.Show();
            }
        }

        protected void EventDetail_ItemUpdated(object sender, System.Web.UI.WebControls.DetailsViewUpdatedEventArgs e)
        {
            UpdatePanelDetail.Update();
            ModalPopup.Hide();

            DayPilotMonth1.DataBind();

            bool iWantNoFlickering = true;
            if (iWantNoFlickering)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "init", "window.setTimeout(function() { dpm.commandCallBack('refresh'); }, 0);", true);
            }
            else
            {
                UpdatePanelCalendar.Update();
            }
        }

        protected void EventDetail_ItemCommand(object sender, System.Web.UI.WebControls.DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                ModalPopup.Hide();
            }
        }

        protected void EventDetail_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            // example as a response to http://forums.daypilot.org/Topic.aspx/583/changing_culture_from_enus_in_sqldemo_breaks_update
            /*
                e.NewValues["eventstart"] = Convert.ToDateTime(e.NewValues["eventstart"], new CultureInfo("da-DK"));
                e.NewValues["eventend"] = Convert.ToDateTime(e.NewValues["eventend"], new CultureInfo("da-DK"));
             */
        }


        protected void EventDetail_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            ModalPopup.Hide();
            UpdatePanelDetail.Update();
            //SqlDataSourceDetail.InsertParameters.Add("@emailId", Session["LLS_EmailId"].ToString());
            DayPilotMonth1.DataBind();

            UpdatePanelCalendar.Update();
        }
        protected void DayPilotMonth1_Command(object sender, DayPilot.Web.Ui.Events.CommandEventArgs e)
        {
            if (e.Command == "refresh")
            {
                DayPilotMonth1.DataBind();
                DayPilotMonth1.Update();
            }
        }

        protected void DayPilotMonth1_EventMove(object sender, EventMoveEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE [events] SET [eventstart] = @start, [eventend] = @end WHERE [id] = @id", con);


                cmd.Parameters.AddWithValue("id", e.Value);
                cmd.Parameters.AddWithValue("start", e.NewStart);
                cmd.Parameters.AddWithValue("end", e.NewEnd);
                cmd.ExecuteNonQuery();


            }

            DayPilotMonth1.DataBind();
            DayPilotMonth1.Update();
        }

        protected void DayPilotMonth1_EventResize(object sender, EventResizeEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand("UPDATE [events] SET [eventstart] = @start, [eventend] = @end WHERE [id] = @id", con);


                cmd.Parameters.AddWithValue("id", e.Value);
                cmd.Parameters.AddWithValue("start", e.NewStart);
                cmd.Parameters.AddWithValue("end", e.NewEnd);
                cmd.ExecuteNonQuery();



            }

            DayPilotMonth1.DataBind();
            DayPilotMonth1.Update();

        }

        protected void DayPilotMonth1_EventClick(object sender, EventClickEventArgs e)
        {
            EventDetail.ChangeMode(DetailsViewMode.Edit);
            SqlDataSourceDetail.SelectParameters["id"].DefaultValue = e.Value;

            // SqlDataSourceDetail.InsertParameters.Add("@emailId", Session["LLS_EmailId"].ToString());
            // SqlDataSourceDetail.InsertParameters["emailId"].DefaultValue = Session["LLS_EmailId"].ToString();

            // SqlDataSourceDetail.Insert();
            EventDetail.DataBind();
            TextBox startTextBox = (TextBox)EventDetail.Rows[1].Cells[1].Controls[0];
            startTextBox.Text = Convert.ToDateTime(e.Start, CultureInfo.CurrentCulture).ToString("MM/dd/yyyy");

            TextBox endTextBox = (TextBox)EventDetail.Rows[2].Cells[1].Controls[0];
            endTextBox.Text = Convert.ToDateTime(e.End, CultureInfo.CurrentCulture).ToString("MM/dd/yyyy");


            UpdatePanelDetail.Update();
            ModalPopup.Show();
        }

        protected void DayPilotMonth1_TimeRangeSelected(object sender, TimeRangeSelectedEventArgs e)
        {
            //SqlDataSourceEvents.SelectParameters["emailId"].DefaultValue = Session["LLS_EmailId"].ToString();
            // SqlDataSourceDetail.Insert();
            EventDetail.ChangeMode(DetailsViewMode.Insert);

            EventDetail.DataBind();

            TextBox startTextBox = (TextBox)EventDetail.Rows[1].Cells[1].Controls[0];
            startTextBox.Text = Convert.ToDateTime(e.Start, CultureInfo.CurrentCulture).ToString("MM/dd/yyyy");

            TextBox endTextBox = (TextBox)EventDetail.Rows[2].Cells[1].Controls[0];
            endTextBox.Text = Convert.ToDateTime(e.End, CultureInfo.CurrentCulture).ToString("MM/dd/yyyy");

            UpdatePanelDetail.Update();
            ModalPopup.Show();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DayPilotMonth1.StartDate = MonthPicker1.StartDate;
            DayPilotMonth1.DataBind();
            UpdatePanelCalendar.Update();
        }
    }
}