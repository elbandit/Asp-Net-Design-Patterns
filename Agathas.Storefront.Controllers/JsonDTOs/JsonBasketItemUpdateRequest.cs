using System.Runtime.Serialization;
using System.Web.Mvc;

namespace Agathas.Storefront.Controllers.JsonDTOs
{
    [DataContract]
    [ModelBinder(typeof(JsonModelBinder))]
    public class JsonBasketItemUpdateRequest
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int Qty { get; set; }
    }
}
