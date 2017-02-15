// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.ListResourceTypesResult
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CloudinaryDotNet.Actions
{
    [DataContract]
    public class ListResourceTypesResult : BaseResult
    {
        [DataMember(Name = "resource_types")] protected string[] m_resourceTypes;

        public ResourceType[] ResourceTypes { get; protected set; }

        internal static async Task<ListResourceTypesResult> Parse(HttpResponseMessage response)
        {
            var resourceTypesResult = await Parse<ListResourceTypesResult>(response);
            var resourceTypeList = new List<ResourceType>();
            foreach (var resourceType in resourceTypesResult.m_resourceTypes)
                resourceTypeList.Add(Api.ParseCloudinaryParam<ResourceType>(resourceType));
            resourceTypesResult.ResourceTypes = resourceTypeList.ToArray();
            return resourceTypesResult;
        }
    }
}