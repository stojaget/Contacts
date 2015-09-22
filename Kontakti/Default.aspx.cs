using Kontakti.BLL;
using Kontakti.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kontakti.DAL;
using Newtonsoft.Json;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;


namespace Kontakti
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetContactsPage(1);
            }
        }

        protected void PageSize_Changed(object sender, EventArgs e)
        {
            this.GetContactsPage(1);
        }

        private void GetContactsPage(int pageIndex)
        {
            string sortExp, sortOrder;
            if (this.ViewState["SortExp"] == null)
            {
                sortExp = "id";
            }
            else
            {
                sortExp = this.ViewState["SortExp"].ToString();
            }
            if (this.ViewState["SortOrder"] == null)
            {
                sortOrder = "ASC";
            }
            else
            {
                sortOrder = this.ViewState["SortOrder"].ToString();
            }

            // because the sort command argument will call this method, we must save pageIndex and pageSize

            int pageSize = int.Parse(ddlPageSize.SelectedValue);

            this.ViewState["PageSize"] = pageSize.ToString();
            this.ViewState["PageIndex"] = pageIndex.ToString();
            //   List<Kontakti.BusinessEntities.Contact> myContacts = ContactManager.GetPagedList(pageIndex, pageSize);
            List<Kontakti.BusinessEntities.Contact> myContacts = ContactManager.GetPagedList(pageIndex, pageSize, sortOrder, sortExp, string.Empty, string.Empty);
            gdvKontakti.DataSource = myContacts;
            gdvKontakti.DataBind();
            int recordCount = ContactManager.SelectCountForGetList();
            lblTotalRows.Text = "TOTAL: " + recordCount.ToString();
            this.PopulatePager(recordCount, pageIndex);

        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.GetContactsPage(pageIndex);
        }

        private void PopulatePager(int recordCount, int currentPage)
        {
            double dblPageCount = (double)((decimal)recordCount / decimal.Parse(ddlPageSize.SelectedValue));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            List<ListItem> pages = new List<ListItem>();
            if (pageCount > 0)
            {
                pages.Add(new ListItem("<", "1", currentPage > 1));
                for (int i = 1; i <= pageCount; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
                pages.Add(new ListItem(">", pageCount.ToString(), currentPage < pageCount));

            }
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEditContact.aspx");
        }

        protected void gdvKontakti_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            switch (e.CommandName.ToLower())
            {

                case "edit":

                    int contactId = Convert.ToInt32(e.CommandArgument);
                    Response.Redirect(string.Format("AddEditContact.aspx?Id={0}", contactId.ToString()));


                    break;

                // IF we want to delete contact directy from gridview, currently off
                //case "delete":

                //    contactId = Convert.ToInt32(e.CommandArgument);
                //    bool uspjeh = ContactManager.Delete(contactId);
                //    if (!uspjeh)
                //    {
                //        string error = "Dogodila se greška prilikom brisanja podataka";
                //        NotificationHelper.ShowErrorNotification(this, error, 3000);
                //    }
                //    else
                //    {
                //        string success = "Uspješno ste obrisali kontakt sa šifrom " + contactId;
                //        NotificationHelper.ShowSuccessfulNotification(this, success, 3000);
                //    }
                // break;


                case "sort":
                    if (this.ViewState["SortExp"] == null)
                    {
                        this.ViewState["SortExp"] = e.CommandArgument.ToString();
                        this.ViewState["SortOrder"] = "ASC";
                    }
                    else
                    {
                        if (this.ViewState["SortExp"].ToString() == e.CommandArgument.ToString())
                        {
                            if (this.ViewState["SortOrder"].ToString() == "ASC")
                                this.ViewState["SortOrder"] = "DESC";
                            else
                                this.ViewState["SortOrder"] = "ASC";
                        }
                        else
                        {
                            this.ViewState["SortOrder"] = "ASC";
                            this.ViewState["SortExp"] = e.CommandArgument.ToString();
                        }
                    }
                    // now we can call stored proc to get sorted list of contacts

                    string sortExp, sortOrder;
                    string firstName, lastName;

                    if (this.ViewState["firstName"] == null)
                    {
                        firstName = "";
                    }
                    else
                    {
                        firstName = this.ViewState["firstName"].ToString();
                    }
                    if (this.ViewState["lastName"] == null)
                    {
                        lastName = "";
                    }
                    else
                    {
                        lastName = this.ViewState["lastName"].ToString();
                    }

                    sortExp = this.ViewState["SortExp"].ToString();
                    sortOrder = this.ViewState["SortOrder"].ToString();
                    int pageSize = Convert.ToInt32(this.ViewState["PageSize"]);
                    int pageIndex = Convert.ToInt32(this.ViewState["PageIndex"]);
                    List<Kontakti.BusinessEntities.Contact> myContacts = ContactManager.GetPagedList(pageIndex, pageSize, sortOrder, sortExp, firstName, lastName);
                    gdvKontakti.DataSource = myContacts;
                    gdvKontakti.DataBind();
                    break;

            }

        }

        protected void gdvKontakti_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header && this.ViewState["SortExp"] != null)
            {
                Image ImgSort = new Image();
                if (this.ViewState["SortOrder"].ToString() == "ASC")
                {
                    ImgSort.ImageUrl = "~/Content/Images/downarrow.gif";
                    ImgSort.Width = 16;
                    ImgSort.Height = 16;
                }
                else
                    ImgSort.ImageUrl = "~/Content/Images/uparrow.gif";
                ImgSort.Width = 16;
                ImgSort.Height = 16;
                switch (this.ViewState["SortExp"].ToString())
                {
                    case "id":
                        PlaceHolder placeholderId = (PlaceHolder)e.Row.FindControl("placeholderId");
                        placeholderId.Controls.Add(ImgSort);
                        break;

                    case "FirstName":
                        PlaceHolder placeholderFirstName = (PlaceHolder)e.Row.FindControl("placeholderFirstName");
                        placeholderFirstName.Controls.Add(ImgSort);
                        break;

                    case "LastName":
                        PlaceHolder placeholderLastName = (PlaceHolder)e.Row.FindControl("placeholderLastName");
                        placeholderLastName.Controls.Add(ImgSort);
                        break;

                    case "Email":
                        PlaceHolder placeholderEmail = (PlaceHolder)e.Row.FindControl("placeholderEmail");
                        placeholderEmail.Controls.Add(ImgSort);
                        break;

                    case "Phone":
                        PlaceHolder placeholderPhone = (PlaceHolder)e.Row.FindControl("placeholderPhone");
                        placeholderPhone.Controls.Add(ImgSort);
                        break;
                    case "DateCreated":
                        PlaceHolder placeholderDateCreated = (PlaceHolder)e.Row.FindControl("placeholderDateCreated");
                        placeholderDateCreated.Controls.Add(ImgSort);
                        break;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string firstName = "", lastName = "";

            if (txtFirstName.Text != "")
            {
                firstName = txtFirstName.Text.Trim();
                ViewState["firstName"] = firstName;

            }
            if (txtLastName.Text != "")
            {
                lastName = txtLastName.Text.Trim();
                ViewState["lastName"] = lastName;

            }
            string sortExp, sortOrder;
            if (this.ViewState["SortExp"] == null)
            {
                sortExp = "id";
            }
            else
            {
                sortExp = this.ViewState["SortExp"].ToString();
            }
            if (this.ViewState["SortOrder"] == null)
            {
                sortOrder = "ASC";
            }
            else
            {
                sortOrder = this.ViewState["SortOrder"].ToString();
            }
            int pageSize = Convert.ToInt32(this.ViewState["PageSize"]);
            int pageIndex = Convert.ToInt32(this.ViewState["PageIndex"]);

            List<Kontakti.BusinessEntities.Contact> myContacts = ContactManager.GetPagedList(pageIndex, pageSize, sortOrder, sortExp, firstName, lastName);
            gdvKontakti.DataSource = myContacts;
            gdvKontakti.DataBind();


        }


    }
}