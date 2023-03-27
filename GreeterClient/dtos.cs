/* Options:
Date: 2023-03-27 23:09:42
Version: 6.70
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: https://localhost:5001

//GlobalNamespace: 
//MakePartial: True
//MakeVirtual: True
//MakeInternal: False
//MakeDataContractsExtensible: False
//AddNullableAnnotations: False
//AddReturnMarker: True
//AddDescriptionAsComments: True
//AddDataContractAttributes: False
//AddIndexesToDataMembers: False
//AddGeneratedCodeAttributes: False
//AddResponseStatus: False
//AddImplicitVersion: 
//InitializeCollections: True
//ExportValueTypes: False
//IncludeTypes: 
//ExcludeTypes: 
//AddNamespaces: 
//AddDefaultXmlNamespace: http://schemas.servicestack.net/types
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;
using ServiceStack.DataAnnotations;
using Contracts;

namespace Contracts
{
    [Route("/hello")]
    [Route("/hello/{Name}")]
    [DataContract]
    public partial class Hello
        : IReturn<HelloResponse>
    {
        [DataMember(Order=1)]
        public virtual string Name { get; set; }
    }

    [DataContract]
    public partial class HelloResponse
    {
        [DataMember(Order=1)]
        public virtual string Result { get; set; }

        [DataMember(Order=2)]
        public virtual ResponseStatus ResponseStatus { get; set; }
    }

}

