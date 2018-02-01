﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetingWebApp.Models;

namespace BudgetingWebApp.ViewModels
{
    public class MainViewModel
    {
        //public IEnumerable<BudgetModel> Budget { get; set; }
        public BudgetModel Budget { get; set; }
        //public MainCategoryModel MainCategory { get; set; }
        public IEnumerable<MainCategoryModel> MainCategory { get; set; }
        //public List<SubCategoryModel> SubCategory { get; set; }
        //public List<ExpenseModel> Expense { get; set; }
    }
}