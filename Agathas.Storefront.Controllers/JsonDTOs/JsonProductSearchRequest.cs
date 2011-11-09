using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web.Mvc;
using Agathas.Storefront.Services.Messaging.ProductCatalogueService;

namespace Agathas.Storefront.Controllers.JsonDTOs
{
    [DataContract]
    [ModelBinder(typeof(JsonModelBinder))]
    public class JsonProductSearchRequest
    {        
        [DataMember]
        public int CategoryId { get; set; }
        [DataMember]
        public int[] ColourIds { get; set; }
        [DataMember]
        public int[] SizeIds { get; set; }
        [DataMember]
        public int[] BrandIds { get; set; }
        [DataMember]
        public ProductsSortBy SortBy { get; set; }
        [DataMember]
        public IEnumerable<JsonRefinementGroup> RefinementGroups { get; set; }
        [DataMember]
        public int Index { get; set; }        
    }    
}
