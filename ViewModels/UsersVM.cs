using PALProgrammingWebTest.Models;

using System.Collections.Generic;
using System.Linq;

namespace PALProgrammingWebTest.ViewModels {
    public class UsersVM : HelperVM {

        public UsersVM(int id= 0) {
            if (id > 0) {
                User = (from u in db.Users where u.UserID == id select u).FirstOrDefault() ?? new Users();
            }
        }

        public virtual Users User { get; set; } = new Users();
        public virtual List<Users> All {
            get {
                return (from u in db.Users select u).ToList() ?? new List<Users>();
            }
        }

        public void Save(Users u) {
            db.Users.Update(u);
            db.SaveChanges();
        }
    }
}
