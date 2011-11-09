using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Agathas.Storefront.Services.Messaging.ProductCatalogueService;
using Agathas.Storefront.Services.Presentation.Model;
using Agathas.Storefront.Services.ViewModels;
using Agathas.Storefront.Infrastructure.Querying;

namespace Agathas.Storefront.Services.Mapping
{
    public static class ProductMapper
    {
        public static GetProductsByCategoryResponse CreateProductSearchResultFrom(this IEnumerable<ProductDto> productsMatchingRefinement, GetProductsByCategoryRequest request)
        {
            GetProductsByCategoryResponse productSearchResultView = new GetProductsByCategoryResponse();

            IEnumerable<ProductSummaryDto> typesOfProductsFound = productsMatchingRefinement.Select(e => new ProductSummaryDto() { Name = e.Name, BrandName = e.BrandName, Id = e.Id, Price = e.Price }).Distinct();
                                               
            
            productSearchResultView.SelectedCategory = request.CategoryId;

            productSearchResultView.NumberOfTitlesFound = typesOfProductsFound.Count();

            productSearchResultView.TotalNumberOfPages = NoOfResultPagesGiven(request.NumberOfResultsPerPage,
                                                                              productSearchResultView.NumberOfTitlesFound);

            productSearchResultView.RefinementGroups = GenerateAvailableProductRefinementsFrom(productsMatchingRefinement);

            productSearchResultView.Products = CropProductListToSatisfyGivenIndex(request.Index, request.NumberOfResultsPerPage, typesOfProductsFound);

            return productSearchResultView;
        }

        private static IEnumerable<ProductSummaryDto> CropProductListToSatisfyGivenIndex(int pageIndex, int numberOfResultsPerPage, IEnumerable<ProductSummaryDto> productsFound)
        {
            if (pageIndex > 1)
            {
                int numToSkip = (pageIndex - 1) * numberOfResultsPerPage;
                return productsFound.Skip(numToSkip).Take(numberOfResultsPerPage);
            }
            else
                return productsFound.Take(numberOfResultsPerPage);
        }

        private static int NoOfResultPagesGiven(int numberOfResultsPerPage, int numberOfTitlesFound)
        {
            if (numberOfTitlesFound < numberOfResultsPerPage)
                return 1;
            else
            {
                return (numberOfTitlesFound / numberOfResultsPerPage) + (numberOfTitlesFound % numberOfResultsPerPage);
            }
        }

        private static IList<RefinementGroup> GenerateAvailableProductRefinementsFrom(IEnumerable<ProductDto> productsFound)
        {            
            var brandsMatching =
                new RefinementGroup()
                    {
                        Refinements = productsFound.Select(p => new Refinement() {Id = p.BrandId, Name = p.BrandName}).Distinct(r => r.Id),
                        GroupId = (int)RefinementGroupings.brand,
                        Name = RefinementGroupings.brand.ToString()
                    };

            var coloursMatching =
                new RefinementGroup()
                {
                    Refinements = productsFound.Select(p => new Refinement() { Id = p.ColourId, Name = p.ColourName }).Distinct(r => r.Id),
                    GroupId = (int)RefinementGroupings.colour,
                    Name = RefinementGroupings.colour.ToString()
                };

            var sizesMatching =
                new RefinementGroup()
                {
                    Refinements = productsFound.Select(p => new Refinement() { Id = p.SizeId, Name = p.SizeName }).Distinct(r => r.Id),
                    GroupId = (int)RefinementGroupings.size,
                    Name = RefinementGroupings.size.ToString()
                };


            //var brandsRefinementGroup = productsFound.Select(p => p.Brand).Distinct().ToList()
            //                           .ConvertAll<IProductAttribute>(b => (IProductAttribute)b).ConvertToRefinementGroup(RefinementGroupings.brand);
            //var coloursRefinementGroup = productsFound.Select(p => p.Colour).Distinct().ToList()
            //                           .ConvertAll<IProductAttribute>(c => (IProductAttribute)c).ConvertToRefinementGroup(RefinementGroupings.colour);
            //var sizesRefinementGroup = (from p in productsFound
            //                            from si in p.Products
            //                            select si.Size).Distinct().ToList()
            //                           .ConvertAll<IProductAttribute>(s => (IProductAttribute)s).ConvertToRefinementGroup(RefinementGroupings.size);

            IList<RefinementGroup> refinementGroups = new List<RefinementGroup>();

            refinementGroups.Add(brandsMatching);
            refinementGroups.Add(coloursMatching);
            refinementGroups.Add(sizesMatching);
            return refinementGroups;
        }        
    }
}
