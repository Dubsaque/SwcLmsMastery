using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SwcLmsMastery.Models;
using SwcLmsMastery.Models.DBModels;
using SwcLmsMastery.Repositories;

namespace SwcLmsMastery.Controllers.api
{
    public class UserSearchController : ApiController
    {
         UserDbRepo _userRepo = new UserDbRepo();

        // GET: Api
        public List<UserSearchViewModel> Post(UserSearchViewModel model)
        {
        var results =_userRepo.Search(model.FirstName, model.LastName, model.Email);
            return results.Select(x => new UserSearchViewModel()
            {
                   Id = x.UserId,
                   FirstName = x.FirstName,
                   LastName = x.LastName,
                   Email = x.Email

            }).ToList();
        }
    }
}