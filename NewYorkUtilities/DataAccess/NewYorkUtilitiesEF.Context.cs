namespace NewYorkUtilities.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    
    public partial class NewYorkUtilitiesEntities : DbContext
    {
        private static NewYorkUtilitiesEntities instance;

        private NewYorkUtilitiesEntities()
            : base("name=NewYorkUtilitiesEntities")
        {
            tblEducationInfoes = new List<tblEducationInfo>() {
                new tblEducationInfo(){ Id=1,  Name = "Columbia University", Description = "Columbia University Description", LogoName="Logo1.jpg", Type="EC", SiteLink="https://www.usnews.com/best-colleges/columbia-university-2707"  },
                new tblEducationInfo(){ Id=2,  Name = "Cornell University", Description = "Cornell University Description", LogoName="Logo2.jpg", Type="EC", SiteLink="https://www.usnews.com/best-colleges/cornell-university-2711"  },
                new tblEducationInfo(){ Id=3,  Name = "University of Rochester", Description = "University of Rochester Description", LogoName="Logo3.jpg", Type="MC", SiteLink="https://www.usnews.com/best-colleges/university-of-rochester-2894"  }
            };
        }

        public static NewYorkUtilitiesEntities GetInstance()
        {
            if(instance  == null)
                instance    =   new NewYorkUtilitiesEntities();
            return instance;
        }

        public virtual List<tblEducationInfo> tblEducationInfoes { get; set; }
    }
}
