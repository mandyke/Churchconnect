using System;

namespace ChurchConnectLite.Core.Entities
{
    public class MainMinister
    {

        public int ID { get; set; }
        public string ApplicationUserId { get; set; }
        public int ChurchId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string About { get; set; }
        public string FaceBook { get; set; }
        public string Twitter { get; set; }
        public string InstagramProfile { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PictureUrl { get; set; }
        public string PictureBlobName { get; set; }
        public DateTime DateEntered { get; set; }


        public ApplicationUser AppUser { get; set; }
        public Church Church { get; set; }
    }
}
