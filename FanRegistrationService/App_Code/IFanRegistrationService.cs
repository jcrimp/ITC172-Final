using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFanRegistrationService" in both code and config file together.
[ServiceContract]
public interface IFanRegistrationService
{
    [OperationContract]
    bool RegisterFan(Fan f, FanLogin fl);

    [OperationContract]
    int Login(string password, string username);

   

    [OperationContract]
    List<Artist> GetArtists();

    [OperationContract]
    List<ShowListByArtist> GetShows(int artKey);

}
 [DataContract]
    public class ShowListByArtist
    {
        [DataMember]
        public string ShowName { set; get; }

        [DataMember]
        public string ShowDate { set; get; }

        [DataMember]
        public string ShowTime { set; get; }

        [DataMember]
        public string ShowTicketInfo { set; get; }

        [DataMember]
        public string ArtistName { set; get; }

    }