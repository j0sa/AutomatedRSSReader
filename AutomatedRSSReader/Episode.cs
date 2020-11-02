//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AutomatedRSSReader
//{
//    [Serializable]
//    public class Episode : Entity, ITitleable
//    {
//        public string Title { get; set; }
//        public string Description { get; set; }
//        public string UploadDate { get; set; }

//        public override string EntityType()
//        {
//            return "An episode.\n";
//        }

//        public Episode(string title, string description, DateTimeOffset uploadDate)
//        {
//            Title = title;
//            Description = description;
//            UploadDate = uploadDate.ToString();
//        }

//        public Episode()
//        {

//        }
//    }
//}
