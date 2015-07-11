using System;
using Xunit;

namespace OEmbedProxy.Core.Tests
{
    public class Class1
    {
        [Fact]
        public void UriTestWildcards()
        {
            const string vimeoScheme = "http://vimeo.com/groups/*/videos/*";

            var uri = new Uri(vimeoScheme);

            UriBuilder uriBuilder = new UriBuilder(vimeoScheme);
            uriBuilder.Password = "sdgf";

            //uriBuilder.
        }
    }
}
