using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FanRegistrationReference;

public partial class searchbyartist : System.Web.UI.Page
{
    FanRegistrationServiceClient registrationClient = new FanRegistrationServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["fanKey"] == null)
        {
            Response.Redirect("Default.aspx");
        }

        if(!IsPostBack)
        {
            FillArtistCheckboxes();
        }
           
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillShowList();
        //need to pass artist key to fill show list?
    }

    private void FillArtistCheckboxes()
    {
       
        List<Artist> artists = registrationClient.GetArtists().ToList();
        CheckBoxList1.DataSource = artists;
        CheckBoxList1.DataTextField = "ArtistName";
        CheckBoxList1.DataValueField = "ArtistKey";
        CheckBoxList1.DataBind();
        //need to return artist key to pass to FillShowList?
    }

    private void FillShowList()
    {
        foreach (ListItem i in CheckBoxList1.Items)
        {
            if (i.Selected)
            {
                int artKey = int.Parse(CheckBoxList1.SelectedItem.Value.ToString());
                List<ShowListByArtist> shwList = registrationClient.GetShows(artKey).ToList();
                ListView list1 = new ListView();
                list1.DataSource = shwList;
                list1.DataBind();
               // ListView1.DataSource = shwList;
               // ListView1.DataBind();
            }
        }

        //int artKey = int.Parse(CheckBoxList1.SelectedItem.Value.ToString());
        //List<ShowListByArtist> shwList = registrationClient.GetShows(artKey).ToList();
        //ListView1.DataSource = shwList;
        //ListView1.DataBind();
    }
}