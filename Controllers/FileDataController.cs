using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using mvcUploadFile.Models;
using Microsoft.AspNetCore.Mvc;

namespace myTestAngular.Controllers {
    [Route ("api/[controller]")]
    public class FileDataController : Controller {

        [HttpPost ("[action]"), DisableRequestSizeLimit]
        public async Task<IEnumerable<CustomerModel>> UploadFile () {
            var file = Request.Form.Files[0];

            List<CustomerModel> customers = new List<CustomerModel> ();
            using (var reader = new StreamReader (file.OpenReadStream ())) {
                while (reader.Peek () >= 0) {
                    var result = await reader.ReadLineAsync ();
                    customers.Add (new CustomerModel {
                        Id = Convert.ToInt32 (result.Split (';') [0]),
                            Name = result.Split (';') [1]
                    });
                }
            }

            return customers;
        }
    }
}