using WebStoreCore.Application.Services.Products.Commands.AddNewCategory;
using WebStoreCore.Application.Services.Products.Queries.GetCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreCore.Application.Services.Products.Commands.AddNewProduct;
using WebStoreCore.Application.Services.Products.Queries.GetAllCategories;
using WebStoreCore.Application.Services.Products.Queries.GetProductDetailForAdmin;
using WebStoreCore.Application.Services.Products.Queries.GetProductDetailForSite;
using WebStoreCore.Application.Services.Products.Queries.GetProductForAdmin;
using WebStoreCore.Application.Services.Products.Queries.GetProductForSite;

namespace WebStoreCore.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }
        IGetCategoriesService  GetCategoriesService { get; }
        AddNewProductService AddNewProductService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }
        /// <summary>
        /// دریافت لیست محصولات
        /// </summary>
        IGetProductForAdminService GetProductForAdminService { get; }
        IGetProductDetailForAdminService GetProductDetailForAdminService { get; }
        IGetProductForSiteService GetProductForSiteService { get; }
        IGetProductDetailForSiteService GetProductDetailForSiteService { get; }

    }
}
