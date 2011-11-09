using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Mvc;

namespace Agathas.Storefront.Controllers.JsonDTOs
{
    [DataContract]
    [ModelBinder(typeof(JsonModelBinder))]
    public class JsonRefinementGroup
    {                
        [DataMember]
        public int GroupId { get; set; }

        [DataMember]
        public int[] SelectedRefinements { get; set; }
    }
}
