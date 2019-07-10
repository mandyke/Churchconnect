namespace ChurchConnectLite.Core.Entities
{
    public class Image
    {

        public int ID { get; set; }
        public string ApplicationUserId { get; set; }
        public string PictureUrl { get; set; }

        public string FileName { get; set; }
        public int? ChurchId { get; set; }
        public int? MinisterId { get; set; }
      
        public Minister Minister { get; set; }
        public Church Church { get; set; }
        //public string Mime { get; set; }

        public ApplicationUser AppUser { get; set; }
    }
}
