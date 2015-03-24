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
            FillRadioBtnArt();
        }
           
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillShowList();
        //need to pass artist key to fill show list?
    }

    private void FillRadioBtnArt()
    {
       
        List<Artist> artists = registrationClient.GetArtists().ToList();
        radioListArt.DataSource = artists;
        radioListArt.DataTextField = "ArtistName";
        radioListArt.DataValueField = "ArtistKey";
        radioListArt.DataBind();
        //need to return artist key to pass to FillShowList?
    }

    private void FillShowList()
    {
        //foreach (ListItem i in CheckBoxList1.Items)
        //{
        //    if (i.Selected)
        //    {
        //        int artKey = int.Parse(CheckBoxList1.SelectedItem.Value.ToString());
        //        List<ShowListByArtist> shwList = registrationClient.GetShows(artKey).ToList();
        //        ListView list1 = new ListView();
        //        list1.DataSource = shwList;
        //        list1.DataBind();
        //    }
        //}

        int artKey = int.Parse(radioListArt.SelectedItem.Value.ToString());
        List<ShowListByArtist> shwList = registrationClient.GetShows(artKey).ToList();
        ListView1.DataSource = shwList;
        ListView1.DataBind();
    }

    protected void lbLogOut_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
}