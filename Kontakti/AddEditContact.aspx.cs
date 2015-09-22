using Kontakti.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Kontakti
{
    public partial class AddEditContact : System.Web.UI.Page
    {
        private int _contactId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("Id") != null)
            {
                _contactId = Convert.ToInt32(Request.QueryString.Get("Id"));
            }

            if (!Page.IsPostBack)
            {
                // if this is case, we are editing existing contact
                if (_contactId > 0)
                {

                    Kontakti.BusinessEntities.Contact myContact = ContactManager.GetItem(_contactId);
                    if (myContact != null)
                    {
                        LoadFormControlsFromContact(myContact);
                    }
                }
                else
                {

                }
            }
        }


        private void LoadFormControlsFromContact(Kontakti.BusinessEntities.Contact myContact)
        {
            txtFirstName.Text = myContact.FirstName;
            txtPhone.Text = myContact.Phone;
            txtLastName.Text = myContact.LastName;
            txtEmail.Text = myContact.Email;
            txtDate.Text = myContact.DateCreated.ToString("dd/MM/yyyy HH:mm:ss");
            txtSifra.Text = myContact.Id.ToString();

        }

        private Kontakti.BusinessEntities.Contact LoadContactFromFormControls()
        {
            Kontakti.BusinessEntities.Contact myContact = new BusinessEntities.Contact();
            myContact.Id = _contactId;
            myContact.FirstName = txtFirstName.Text;
            myContact.Phone = txtPhone.Text;
            myContact.LastName = txtLastName.Text;
            myContact.Email = txtEmail.Text;
            myContact.DateCreated = DateTime.Now;
            return myContact;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveContact();
        }

        private void SaveContact()
        {

            if (Page.IsValid)
            {
                Kontakti.BusinessEntities.Contact myContact;
                if (_contactId > 0)
                {
                    // Update existing item
                    myContact = LoadContactFromFormControls();
                }
                else
                {
                    // Create a new Contact

                    myContact = LoadContactFromFormControls();

                }


                if (myContact.Validate())
                {

                    bool uspjeh = ContactManager.Save(myContact);
                    if (uspjeh)
                    {
                        string success = "Uspješno ste pohranili podatke.";
                      
                        Validation.BrokenRule brokenRule = new Validation.BrokenRule("id", success);
                        Validation.BrokenRulesCollection brokenRuleCol = new Validation.BrokenRulesCollection();
                        brokenRuleCol.Add(brokenRule);
                        ErrorList1.BrokenRules = brokenRuleCol;
                        this.ShowSuccessfulNotification(success);
                        //EndEditing();
                    }

                    plcErrors.Visible = true;
                    this.ShowErrorNotification("Dogodila se pogreška prilikom unosa podataka.");
                    // NotificationHelper.ShowErrorNotification(this, "Dogodila se pogreška prilikom unosa podataka.", 3000);

                }
                else
                {
                    ErrorList1.BrokenRules = myContact.BrokenRules;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            EndEditing();
        }

        private void EndEditing()
        {
            Response.Redirect("~/");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            if (txtSifra.Text != "")
            {
                int contactId = Convert.ToInt32(txtSifra.Text);
                bool uspjeh = ContactManager.Delete(contactId);
                if (!uspjeh)
                {
                    string error = "Dogodila se greška prilikom brisanja podataka";
                    Validation.BrokenRule brokenRule = new Validation.BrokenRule("id", error);
                    Validation.BrokenRulesCollection brokenRuleCol = new Validation.BrokenRulesCollection();
                    brokenRuleCol.Add(brokenRule);
                    ErrorList1.BrokenRules = brokenRuleCol;
                    NotificationHelper.ShowErrorNotification(this, error, 3000);
                }
                else
                {
                    string success = "Uspješno ste obrisali kontakt sa šifrom " + contactId;
                    
                    Validation.BrokenRule brokenRule = new Validation.BrokenRule("id", success);
                    Validation.BrokenRulesCollection brokenRuleCol = new Validation.BrokenRulesCollection();
                    brokenRuleCol.Add(brokenRule);
                    ErrorList1.BrokenRules = brokenRuleCol;
                    NotificationHelper.ShowSuccessfulNotification(this, success, 3000);
                }
            }
            else
            {
                string emptyContact = "Ne možete obrisati prazan kontakt";
                Validation.BrokenRule brokenRule = new Validation.BrokenRule("id", emptyContact);
                Validation.BrokenRulesCollection brokenRuleCol = new Validation.BrokenRulesCollection();
                brokenRuleCol.Add(brokenRule);
                ErrorList1.BrokenRules = brokenRuleCol;
            }

        }
    }
}