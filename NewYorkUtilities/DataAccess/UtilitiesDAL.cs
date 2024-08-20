using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewYorkUtilities.DataAccess
{
    public class UtilitiesDAL
    {
        private NewYorkUtilitiesEntities _db;
        public UtilitiesDAL(NewYorkUtilitiesEntities db)
        {
            _db = db;
        }
        public List<tblEducationInfo> GetAllEngineeringColleges()
        {
            var result = _db.tblEducationInfoes.Where(x => x.Type == "EC").ToList();
            return result;
        }

        public List<tblEducationInfo> GetAllMedicalColleges()
        {
            var result = _db.tblEducationInfoes.Where(x => x.Type == "MC").ToList();
            return result;
        }


    }
}