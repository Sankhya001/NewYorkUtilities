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

            tblCategories = new List<tblCategory>() {
                new tblCategory(){ Id=1, Category="College" },
                new tblCategory(){ Id=2, Category="Hotel" },
                new tblCategory(){ Id=3, Category="Restaurant" }
            };

            tblAddresses = new List<tblAddress>() { 
                new tblAddress(){ Category=1, City="City1", Description="Description 1", Email="address1@gmail.com", Name="Address 1", Phone="1234567890", Pincode=12345, Street1="Street 1", Street2="Street 21"  },
                new tblAddress(){ Category=2, City="City2", Description="Description 2", Email="address2@gmail.com", Name="Address 2", Phone="1234567891", Pincode=12345, Street1="Street 2", Street2="Street 22"  },
                new tblAddress(){ Category=3, City="City2", Description="Description 3", Email="address3@gmail.com", Name="Address 3", Phone="1234567892", Pincode=12345, Street1="Street 3", Street2="Street 23"  }

            };
        }

        public static NewYorkUtilitiesEntities GetInstance()
        {
            if(instance  == null)
                instance    =   new NewYorkUtilitiesEntities();
            return instance;
        }

        public virtual List<tblEducationInfo> tblEducationInfoes { get; set; }
        public virtual List<tblAddress> tblAddresses { get; set; }
        public virtual List<tblCategory> tblCategories { get; set; }
    }
}
