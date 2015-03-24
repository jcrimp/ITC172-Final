using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FanRegistrationService" in code, svc and config file together.
public class FanRegistrationService : IFanRegistrationService
{
    ShowTrackerEntities1 showTrackerDb = new ShowTrackerEntities1();

    public bool RegisterFan(Fan f, FanLogin fl)
    {
        bool result = true;

        try
        {
            PasswordHash phash = new PasswordHash();
            KeyCode kcode = new KeyCode();
            int key = kcode.GetKeyCode();
            byte[] hash = phash.HashIt(fl.FanLoginPasswordPlain, key.ToString());

            Fan fan = new Fan();
            fan.FanName = f.FanName;
            fan.FanEmail = f.FanEmail;
            fan.FanDateEntered = DateTime.Now;
            showTrackerDb.Fans.Add(fan);

            FanLogin fanLogin = new FanLogin();
            fanLogin.Fan = fan;
            fanLogin.FanLoginUserName = fl.FanLoginUserName;
            fanLogin.FanLoginPasswordPlain = fl.FanLoginPasswordPlain;
            fanLogin.FanLoginHashed = hash;
            fanLogin.FanLoginDateAdded = DateTime.Now;
            fanLogin.FanLoginRandom = key;
            showTrackerDb.FanLogins.Add(fanLogin);

            showTrackerDb.SaveChanges();
        }

        catch
        {
            result = false;
        }

        return result;
    }

    public int Login(string password, string username)
    {
        LoginClass login = new LoginClass(password, username);
        int key = login.ValidateLogin();
        return key;
    }


    public List<Artist> GetArtists()
    {
        List<Artist> artists = new List<Artist>();

        var arts = from a in showTrackerDb.Artists
                   select new { a.ArtistKey, a.ArtistName };

        foreach (var a in arts)
        {
            Artist art = new Artist();
            art.ArtistKey = a.ArtistKey;
            art.ArtistName = a.ArtistName;
            artists.Add(art);
        }

        return artists;
    }


    public List<ShowListByArtist> GetShows(int artKey)
    {
        List<ShowListByArtist> shows = new List<ShowListByArtist>();

        var shw = from s in showTrackerDb.Shows
                  from sd in s.ShowDetails
                  where sd.ArtistKey == artKey
                  select new { s.ShowName, s.ShowDate, s.ShowTime, s.ShowTicketInfo, sd.Artist.ArtistName };

        foreach (var sh in shw)
        {
            ShowListByArtist s = new ShowListByArtist();
            s.ShowName = sh.ShowName;
            s.ShowDate = sh.ShowDate.ToShortDateString();
            s.ShowTime = sh.ShowTime.ToString();
            s.ShowTicketInfo = sh.ShowTicketInfo;
            s.ArtistName = sh.ArtistName;
            shows.Add(s);
        }

        return shows;
    }

}
