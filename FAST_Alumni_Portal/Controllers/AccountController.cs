using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using FAST_Alumni_Portal.Utils;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBModel;
using Newtonsoft.Json;

using System.Net.Http;
using System.Threading.Tasks;

using FAST_Alumni_Portal.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Entity.Validation;

namespace FAST_Alumni_Portal.Controllers
{
    public class AccountController : Controller
    {
        private const string LinkedinUserInfoParameters = "id,first-name,last-name,maiden-name,formatted-name,phonetic-first-name,phonetic-last-name,formatted-phonetic-name,headline,location,picture-url,industry,current-share,num-connections,num-connections-capped,summary,specialties,positions,picture-urls,site-standard-profile-request,api-standard-profile-request,public-profile-url,email-address,languages,skills";

        private Model1Container db = new Model1Container();
        

        public object EntityValidationErrors { get; private set; }

        private async Task<UserInfo> GetUserFromAccessTokenAsync(string token)
        {
           
            var apiClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.linkedin.com")
            };
            var url = $"/v1/people/~:({LinkedinUserInfoParameters})?oauth2_access_token={token}&format=json";
            var response = await apiClient.GetAsync(url);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var r =  JsonConvert.DeserializeObject<UserInfo>(jsonResponse);
            //  return JsonConvert.DeserializeObject<UserInfo>(jsonResponse);
           // var check = db.linkedinAccounts.Where(s => s.url == (r.PublicProfileUrl) );


            
                return r;
            
        }


        private async Task<UserInfo> GetUserFromAccessTokenAsync1(string token)
        {

            var apiClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.linkedin.com")
            };
            var url = $"/v1/people/~:({LinkedinUserInfoParameters})?oauth2_access_token={token}&format=json";
            var response = await apiClient.GetAsync(url);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var r = JsonConvert.DeserializeObject<UserInfo>(jsonResponse);
            //  return JsonConvert.DeserializeObject<UserInfo>(jsonResponse);
            // var check = db.linkedinAccounts.Where(s => s.url == (r.PublicProfileUrl) );

            linkedinAccount lk = new linkedinAccount();
            if (lk.email == r.EmailAddress)
            {

            }

            return r;

        }


        [HttpGet]
        public ActionResult SignOut()
        {
            Session["user"] = null;
            return View("Index");
        }
        [HttpGet]
        public async Task<ActionResult> SaveLinkedinUser(string code, string state, string error, string error_description)
        {
            if (string.IsNullOrEmpty(code))
            {
                return View("Error");
            }

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://www.linkedin.com/")
            };
            var requestUrl = $"oauth/v2/accessToken?grant_type=authorization_code&code={code}&redirect_uri={AppConfig.Get("Linkedin.RedirectUrlazure")}&client_id={AppConfig.Get("Linkedin.ClientID")}&client_secret={AppConfig.Get("Linkedin.SecretKey")}";
            var response = await httpClient.GetAsync(requestUrl);
            var token = JsonConvert.DeserializeObject<TokenResponse>(await response.Content.ReadAsStringAsync());
            Session["user"] = token.Access_token;
          

            return View("User", await GetUserFromAccessTokenAsync(token.Access_token));
        }
        [HttpGet]
        public async Task<ActionResult> SaveLinkedinUser1(string code, string state, string error, string error_description)
        {
            if (string.IsNullOrEmpty(code))
            {
                return View("Error");
            }

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://www.linkedin.com/")
            };
            var requestUrl = $"oauth/v2/accessToken?grant_type=authorization_code&code={code}&redirect_uri={AppConfig.Get("Linkedin.RedirectUrl1")}&client_id={AppConfig.Get("Linkedin.ClientID")}&client_secret={AppConfig.Get("Linkedin.SecretKey")}";
            var response = await httpClient.GetAsync(requestUrl);
            var token = JsonConvert.DeserializeObject<TokenResponse>(await response.Content.ReadAsStringAsync());
            Session["user"] = token.Access_token;


            return View("Details", await GetUserFromAccessTokenAsync1(token.Access_token));
        }


        public ActionResult Usershow()
        {
            return View();
        }

        public ActionResult showdata()
        {
            return View();
        }
        public ActionResult showdata(int? name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(name);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        /*
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Create(UserInfo objUserdt)
                {
                    public static string Constr = ConfigurationManager.ConnectionStrings["Model1Container"].ConnectionString; // Connection string
                     try  
                {  
                    using (var con = private new SqlConnection(Constr))  
                    {  
                        using (var cmd = private new SqlCommand("INSERT INTO Userdetails VALUES(@Fname,@Lname,@Email,@FunctionalArea,@CreatedDate)"))  
                        {  
                            cmd.CommandType = CommandType.Text;  
                            cmd.Parameters.AddWithValue("@Fname", objUserdtl.FName);  
                            cmd.Parameters.AddWithValue("@Lname", objUserdtl.LName);  
                            cmd.Parameters.AddWithValue("@Email", objUserdtl.Email);  
                            cmd.Parameters.AddWithValue("@FunctionalArea", objUserdtl.FunctionalArea);  
                            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);  
                            cmd.Connection = con;  
                            con.Open();  
                            cmd.ExecuteNonQuery();  
                            con.Close();  
                        }
        }  
                }  
                catch (Exception ex)  
                {  
                    throw;  
                }  
                    return View("Index");
                }

            */













        public ActionResult Index()
        {
         //   string token = (string)Session["user"];
        //    if (string.IsNullOrEmpty(token))
        //    {
                return View();
         //   }
           /* else
            {
                return View("User", await GetUserFromAccessTokenAsync(token));
            }*/
        }


        // GET: Account/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }


        
        // GET: Account/Create
        public ActionResult Create()
        {
           // ViewBag.name = HttpContext.Session.SessionID[1].ToString();
            return View();
        }

        public ActionResult MyAccount()
        {
            return View();
        }
        public ActionResult studentlogin1()
        {
            return View();
        }


        [HttpPost]
        public ActionResult studentlogin1(student objUser)
        {
            if (ModelState.IsValid)
            {
                using (Model1Container db = new Model1Container())
                {
                    var obj = db.students.Where(a => a.alumni_id.Equals(objUser.alumni_id) && a.password.Equals(objUser.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.alumni_id.ToString();
                        Session["Alumni_id"] = obj.alumni_id.ToString();
                        return RedirectToAction("Details/"+obj.record_id);
                    }
                }
            }
            return View(objUser);
        }


        // POST: Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "record_id,alumni_id,firstname,lastname,primaryemail,secondaryemail,Campus,linkedinacct,skill_1,skill_2,skill_3,programfast,currentposition,graduationdate,password,comment")] student student)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }


        
        [HttpPost]
        public ActionResult SaveLinkedinData(int studentnumber,string FirstName,string LastName,string pemail,string semail,string campus,string url,string s1,string s2,string s3,string Program_Fast_Name, string position,DateTime date,string password, string picurl)
        {


            student st = new student();

            linkedinAccount lk = new linkedinAccount();
            lk.linkedinAccount_Id = st.record_id;
            lk.firstname = FirstName;
            lk.lastname = LastName;
            lk.positions = position;
            lk.imgurl = picurl;
            lk.url = url;
            lk.email = pemail;
            db.linkedinAccounts.Add(lk);
            db.SaveChanges();


            st.alumni_id = studentnumber;
            st.record_id = lk.linkedinAccount_Id;
           // st.firstname = FirstName;
          //  st.lastname = LastName;
           // st.primaryemail = pemail;
            st.secondaryemail = semail;
            st.Campus = campus;
           // st.linkedinacct = url;
            st.skill_1 = s1;
            st.skill_2 = s2;
            st.skill_3 = s3;
            st.programfast = Program_Fast_Name;
           // st.currentposition = "HardCode";
            st.graduationdate = date;
            st.password = password;
            st.comment = "";
            st.linkedinAccount = lk;


            db.students.Add(st);
            




           
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }



            return RedirectToAction("studentlogin1");
        }
        /*     public ActionResult User()
             {
                 return View();
             }
             [HttpPost]
             [ValidateAntiForgeryToken]
             public ActionResult User([Bind(Include = "Id,firstname,lastname,email,url,positions,skill_3,imgurl")]
             linkedinAccount lk)){

             }
             */
        // GET: Account/Edit/5

            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                student student = db.students.Find(id);
                if (student == null)
                {
                    return HttpNotFound();
                }
                return View(student);
            }
        
       
        // POST: Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "record_id,alumni_id,firstname,lastname,primaryemail,secondaryemail,Campus,linkedinacct,skill_1,skill_2,skill_3,programfast,currentposition,graduationdate,password,comment,linkedinaccount")] student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return View();
            }
            return View("StudentLogin1");
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student student = db.students.Find(id);
            db.students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
