using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dynamitey.DynamicObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReplayProjectTest.Drivers;
using ReplayProjectTest.Setup;
using RestSharp;

namespace ReplayProjectTest.Extensions
{

    public interface IApiLogin
    {
        public void LoginApi();
    }
    public class ApiLogin: IApiLogin
    {
        IWebDriver driver;
        private readonly IDriverFactory _driverFactory;
        private readonly TestSettings _testSettings;

        public ApiLogin(IDriverFactory driverFactory, TestSettings testSettings)
        {
            _driverFactory = driverFactory;
            _testSettings = testSettings;
            driver = driverFactory.Driver;
        }

        public void LoginApi() {
            RestClient restClient = new RestClient(_testSettings.ApplicationUrl);
            var request = new RestRequest("json.php?action=login", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Referer", _testSettings+"login.php?login_module=Home&login_action=index");
            request.AddHeader("Sec-Ch-Ua", "\"Google Chrome\";v=\"119\", \"Chromium\";v=\"119\", \"Not?A_Brand\";v=\"24\"");
            request.AddHeader("Sec-Ch-Ua-Mobile", "?0");
            request.AddHeader("Sec-Ch-Ua-Platform", "Windows");
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Safari/537.36");


            var data = new
            {
                res_width = 1221,
                res_height = 919,
                username = "admin",
                password = "admin",
                remember = "",
                language = "en_us",
                theme = "Claro",
                login_module = "Home",
                login_action = "index",
                login_record = "",
                login_layout = "",
                mobile = "0",
                gmto = -60
            };
            var jsonData = JsonConvert.SerializeObject(data);

            request.AddBody(jsonData);

            var response = restClient.Execute(request);

            dynamic res = JObject.Parse(response.Content);
            var sesionId = res.json_session_id;
            
            List<Cookie> pageCookiese= new List<Cookie>();
            pageCookiese.Add(new Cookie("PHPSESSID", sesionId.ToString()));
            pageCookiese.Add(new Cookie("ck_Claro_style", "default"));
            pageCookiese.Add(new Cookie("ck_login_language", "en_us"));
            pageCookiese.Add(new Cookie("ck_login_forget", "1"));

            _driverFactory.NawigateToAppUrl();
            _driverFactory.SetUpDriver();
            driver.Manage().Cookies.DeleteAllCookies();

            foreach (var cookie in pageCookiese)
            {
                driver.Manage().Cookies.AddCookie(cookie);
            }
            driver.Navigate().GoToUrl(_testSettings.ApplicationUrl + "index.php?module=Home&action=index");

        }

    }
}
