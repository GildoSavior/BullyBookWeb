using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BullyBookWeb.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BullyBookWeb.Models.ViewModels
{
    public class ProductVM
    {

        public Product Product { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CoverTypeList { get; set; }
    }
}