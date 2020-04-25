using Newtonsoft.Json.Serialization;

namespace MapOpennet.App_Code
{
    #region Convert json key to lowercase

    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }

        #endregion Convert json key to lowercase
    }
}